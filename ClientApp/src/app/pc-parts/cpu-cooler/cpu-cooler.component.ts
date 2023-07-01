import { CommonModule } from '@angular/common';
import {
  Component,
  DestroyRef,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import {
  FormGroup,
  FormGroupDirective,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { Observable } from 'rxjs';
import { CpuCoolerAddRequest } from 'src/app/core/models/cpu-cooler.model';
import { CpuCoolerService } from 'src/app/core/services/cpu-cooler.service';
import { MessageService } from 'primeng/api';
import { SocketService } from 'src/app/core/services/socket.service';
import { SocketGetResponse } from 'src/app/core/models/socket.model';
import { ManufacturerComponent } from '../manufacturer/manufacturer.component';
import { ImageComponent } from '../image/image.component';
import { PcPartsService } from 'src/app/core/services/pc-parts.service';
@Component({
  selector: 'app-cpuCooler',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
    CommonModule,
    ManufacturerComponent,
    ImageComponent,
  ],
  templateUrl: './cpu-cooler.component.html',
  styleUrls: ['../shared-pc-part.scss'],
})
export class CpuCoolerComponent implements OnInit, OnDestroy {
  //* Injecting dependencies
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private cpuCoolerService: CpuCoolerService = inject(CpuCoolerService);
  private messageService: MessageService = inject(MessageService);
  private socketService: SocketService = inject(SocketService);
  private pcPartService: PcPartsService = inject(PcPartsService);

  @ViewChild('imageComponentRef') imageComponentRef?: ImageComponent;

  manufacturers: string[] = [
    'Noctua',
    'Cooler Master',
    'Corsair',
    'be quiet',
    'NZXT',
    'Arctic',
    'Scythe',
    'Fractal Design',
    'Phanteks',
    'Thermaltake',
  ];
  cpuCoolerForm?: FormGroup;

  socket$?: Observable<SocketGetResponse[]>;

  ngOnInit(): void {
    this.cpuCoolerForm = this.rootFormGroup.control;
    this.cpuCoolerForm.get('cpuCooler')?.addValidators(Validators.required);
    this.socket$ = this.socketService.getAll();
    this.cpuCoolerForm.patchValue({
      manufacturer: '',
    });
  }

  checkFormValidity(): boolean {
    if (
      !this.cpuCoolerForm?.controls['cpuCooler'].valid ||
      !this.cpuCoolerForm.controls['manufacturer'].valid ||
      !this.cpuCoolerForm.controls['model'].valid ||
      !this.cpuCoolerForm.controls['imageUrl'].valid
    ) {
      return true;
    }
    return false;
  }

  onResetForm(): void {
    this.pcPartService.resetForm(this.cpuCoolerForm!);
    this.imageComponentRef?.onResetImage();
    this.cpuCoolerForm?.get('cpuCooler')?.removeValidators(Validators.required);
  }

  onCreateComponent(): void {
    if (!this.cpuCoolerForm) return;
    const body: CpuCoolerAddRequest = {
      manufacturer: this.cpuCoolerForm.get('manufacturer')?.value,
      model: this.cpuCoolerForm.get('model')?.value,
      imageUrl: this.cpuCoolerForm.get('imageUrl')?.value,
      socketIds: [
        ...this.cpuCoolerForm.get('cpuCooler')?.get('socketIds')?.value,
      ],
      type: this.cpuCoolerForm.get('cpuCooler')?.get('type')?.value,
      tdp: this.cpuCoolerForm.get('cpuCooler')?.get('tdp')?.value,
      maxRPM: this.cpuCoolerForm.get('cpuCooler')?.get('maxRPM')?.value,
      noiseLevel: this.cpuCoolerForm.get('cpuCooler')?.get('noiseLevel')?.value,
    };
    this.cpuCoolerService
      .add(body)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((resp: any) => {
        this.messageService.add({
          key: 'tc',
          severity: 'success',
          detail: 'Cpu Cooler was added successfully!',
          life: 3000,
        });
        this.onResetForm();
      });
  }

  ngOnDestroy(): void {
    this.onResetForm();
  }
}

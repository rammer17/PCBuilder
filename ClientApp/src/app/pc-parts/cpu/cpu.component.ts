import {
  Component,
  DestroyRef,
  OnDestroy,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import {
  FormGroup,
  FormGroupDirective,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { CommonModule } from '@angular/common';
import { CpuAddRequest } from 'src/app/core/models/cpu.model';
import { CpuService } from 'src/app/core/services/cpu.service';
import { MessageService } from 'primeng/api';
import { ManufacturerComponent } from '../manufacturer/manufacturer.component';
import { ImageComponent } from '../image/image.component';
import { PcPartsService } from 'src/app/core/services/pc-parts.service';

@Component({
  selector: 'app-cpu',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
    CommonModule,
    ManufacturerComponent,
    ImageComponent,
  ],
  templateUrl: './cpu.component.html',
  styleUrls: ['../shared-pc-part.scss'],
})
export class CpuComponent implements OnInit, OnDestroy {
  //* Injecting dependecies
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private cpuService: CpuService = inject(CpuService);
  private pcPartService: PcPartsService = inject(PcPartsService);
  private messageService: MessageService = inject(MessageService);

  @ViewChild('imageComponentRef') imageComponentRef?: ImageComponent;

  manufacturers: string[] = ['AMD', 'Intel'];
  cpuForm?: FormGroup;

  ngOnInit(): void {
    this.cpuForm = this.rootFormGroup.control;
    this.cpuForm.get('cpu')?.addValidators(Validators.required);
    this.cpuForm.patchValue({
      manufacturer: '',
    });
  }

  checkFormValidity(): boolean {
    if (
      !this.cpuForm?.controls['cpu'].valid ||
      !this.cpuForm.controls['manufacturer'].valid ||
      !this.cpuForm.controls['model'].valid ||
      !this.cpuForm.controls['imageUrl'].valid
    ) {
      return true;
    }
    return false;
  }

  onResetForm(): void {
    this.pcPartService.resetForm(this.cpuForm!);
    this.imageComponentRef?.onResetImage();
    this.cpuForm?.get('cpu')?.removeValidators(Validators.required);
  }

  onCreateComponent(): void {
    if (!this.cpuForm) return;
    const body: CpuAddRequest = {
      manufacturer: this.cpuForm.get('manufacturer')?.value,
      model: this.cpuForm.get('model')?.value,
      imageUrl: this.cpuForm.get('imageUrl')?.value,
      cores: this.cpuForm.get('cpu')?.get('cores')?.value,
      threads: this.cpuForm.get('cpu')?.get('threads')?.value,
      baseClock: this.cpuForm.get('cpu')?.get('baseClock')?.value,
      maxBoostClock: this.cpuForm.get('cpu')?.get('maxBoostClock')?.value,
      socketId: this.cpuForm.get('cpu')?.get('socketId')?.value,
    };
    this.cpuService
      .add(body)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((resp: any) => {
        this.messageService.add({
          key: 'tc',
          severity: 'success',
          detail: 'CPU was added successfully!',
          life: 3000,
        });
      });
  }

  ngOnDestroy(): void {
    this.onResetForm();
  }
}

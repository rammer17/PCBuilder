import { CommonModule } from '@angular/common';
import {
  Component,
  DestroyRef,
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
import { GpuAddRequest } from 'src/app/core/models/gpu.model';
import { GpuService } from 'src/app/core/services/gpu.service';
import { MessageService } from 'primeng/api';
import { ManufacturerComponent } from '../manufacturer/manufacturer.component';
import { ImageComponent } from '../image/image.component';
import { PcPartsService } from 'src/app/core/services/pc-parts.service';

@Component({
  selector: 'app-gpu',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
    CommonModule,
    ManufacturerComponent,
    ImageComponent,
  ],
  templateUrl: './gpu.component.html',
  styleUrls: ['../shared-pc-part.scss'],
})
export class GpuComponent implements OnInit, OnDestroy {
  //* Injecting dependencies
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private gpuService: GpuService = inject(GpuService);
  private pcPartService: PcPartsService = inject(PcPartsService);
  private messageService: MessageService = inject(MessageService);

  @ViewChild('imageComponentRef') imageComponentRef?: ImageComponent;

  manufacturers: string[] = [
    'ASUS',
    'EVGA',
    'MSI',
    'Gigabyte',
    'Sapphire',
    'Zotac',
    'XFX',
    'Palit',
    'PNY',
    'PowerColor',
    'Inno3D',
    'Gainward',
    'Biostar',
    'ASRock',
  ];

  gpuForm?: FormGroup;

  ngOnInit(): void {
    this.gpuForm = this.rootFormGroup.control;
    this.gpuForm.get('gpu')?.addValidators(Validators.required);
    this.gpuForm.patchValue({
      manufacturer: '',
    });
  }

  checkFormValidity(): boolean {
    if (
      !this.gpuForm?.controls['gpu'].valid ||
      !this.gpuForm.controls['manufacturer'].valid ||
      !this.gpuForm.controls['model'].valid ||
      !this.gpuForm.controls['imageUrl'].valid
    ) {
      return true;
    }
    return false;
  }

  onResetForm(): void {
    this.pcPartService.resetForm(this.gpuForm!);
    this.imageComponentRef?.onResetImage();
    this.gpuForm?.get('gpu')?.removeValidators(Validators.required);
  }

  onCreateComponent(): void {
    if (!this.gpuForm) return;
    const body: GpuAddRequest = {
      manufacturer: this.gpuForm.get('manufacturer')?.value,
      model: this.gpuForm.get('model')?.value,
      imageUrl: this.gpuForm.get('imageUrl')?.value,
      baseClock: this.gpuForm.get('gpu')?.get('baseClock')?.value,
      maxBoostClock: this.gpuForm.get('gpu')?.get('maxBoostClock')?.value,
      memorySize: this.gpuForm.get('gpu')?.get('memorySize')?.value,
      memoryType: this.gpuForm.get('gpu')?.get('memoryType')?.value,
      memoryBus: this.gpuForm.get('gpu')?.get('memoryBus')?.value,
      tdp: this.gpuForm.get('gpu')?.get('tdp')?.value,
      height: this.gpuForm.get('gpu')?.get('height')?.value,
      width: this.gpuForm.get('gpu')?.get('width')?.value,
    };
    this.gpuService
      .add(body)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((resp: any) => {
        this.messageService.add({
          key: 'tc',
          severity: 'success',
          detail: 'GPU was added successfully!',
          life: 3000,
        });
        this.onResetForm();
      });
  }

  ngOnDestroy(): void {
    this.onResetForm();
  }
}

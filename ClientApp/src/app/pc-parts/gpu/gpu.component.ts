import { CommonModule } from '@angular/common';
import { HttpEvent, HttpEventType } from '@angular/common/http';
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
import { tap } from 'rxjs';
import { ImgbbUploadService } from 'src/app/core/services/imgbb-upload.service';
import { Image } from '../image.model';
import { GpuAddRequest } from 'src/app/core/models/gpu.model';
import { GpuService } from 'src/app/core/services/gpu.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-gpu',
  standalone: true,
  imports: [ReactiveFormsModule, ButtonModule, RippleModule, CommonModule],
  templateUrl: './gpu.component.html',
  styleUrls: ['../shared-pc-part.scss'],
})
export class GpuComponent implements OnInit, OnDestroy {
  //* Injecting dependencies
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private imgUploadService: ImgbbUploadService = inject(ImgbbUploadService);
  private gpuService: GpuService = inject(GpuService);
  private messageService: MessageService = inject(MessageService);

  @ViewChild('componentImgInput') componentImgInput?: ElementRef;

  gpuForm?: FormGroup;
  progress: number = 0;
  componentImage?: Image;

  ngOnInit(): void {
    this.gpuForm = this.rootFormGroup.control;
    this.gpuForm.get('gpu')?.addValidators(Validators.required);
  }

  onUploadImage() {
    const file = this.componentImgInput?.nativeElement.files[0];
    this.componentImage = {
      size: file.size,
      loaded: false,
      title: file.name,
    };
    this.imgUploadService
      .upload(file)
      .pipe(
        tap((event: HttpEvent<any>) => {
          switch (event.type) {
            case HttpEventType.UploadProgress: {
              this.progress = Math.round((event.loaded / event.total!) * 100);
              break;
            }
            case HttpEventType.Response: {
              const url = event.body.data.url;
              this.gpuForm?.patchValue({
                imageUrl: url,
              });
              this.componentImage!.loaded = true;
            }
          }
        }),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe();
  }
  onRemoveImage(): void {
    this.componentImage = undefined;
    this.gpuForm?.controls['imageUrl'].setErrors({ incorrect: true });
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
    this.gpuForm?.reset({
      manufacturer: this.gpuForm.get('manufacturer')?.value,
    });
    this.gpuForm?.controls['gpu'].reset({
      memoryType: '',
    });
    this.componentImage = undefined;
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

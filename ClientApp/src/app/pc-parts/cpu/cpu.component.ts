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
import {
  FormGroup,
  FormGroupDirective,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { tap } from 'rxjs';
import { ImgbbUploadService } from 'src/app/core/services/imgbb-upload.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { CommonModule } from '@angular/common';
import { Image } from '../image.model';
import { CpuAddRequest } from 'src/app/core/models/cpu.model';
import { CpuService } from 'src/app/core/services/cpu.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-cpu',
  standalone: true,
  imports: [ReactiveFormsModule, ButtonModule, RippleModule, CommonModule],
  templateUrl: './cpu.component.html',
  styleUrls: ['../shared-pc-part.scss'],
})
export class CpuComponent implements OnInit, OnDestroy {
  //* Injecting dependecies
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private imgUploadService: ImgbbUploadService = inject(ImgbbUploadService);
  private cpuService: CpuService = inject(CpuService);
  private messageService: MessageService = inject(MessageService);

  @ViewChild('componentImgInput') componentImgInput?: ElementRef;

  cpuForm?: FormGroup;
  progress: number = 0;
  componentImage?: Image;

  ngOnInit(): void {
    this.cpuForm = this.rootFormGroup.control;
    this.cpuForm.get('cpu')?.addValidators(Validators.required);
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
              this.cpuForm?.patchValue({
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
    this.cpuForm?.reset({
      manufacturer: this.cpuForm.get('manufacturer')?.value,
    });
    this.cpuForm?.controls['cpu'].reset({
      socketId: '',
    });
    this.componentImage = undefined;
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

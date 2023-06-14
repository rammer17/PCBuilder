import { HttpEvent, HttpEventType } from '@angular/common/http';
import {
  Component,
  DestroyRef,
  ElementRef,
  EventEmitter,
  Output,
  ViewChild,
  inject,
} from '@angular/core';
import {
  FormBuilder,
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
import { CpuService } from 'src/app/core/services/cpu.service';
import { CpuAddRequest } from 'src/app/core/models/cpu.model';

@Component({
  selector: 'app-cpu',
  standalone: true,
  imports: [ReactiveFormsModule, ButtonModule, RippleModule, CommonModule],
  templateUrl: './cpu.component.html',
  styleUrls: ['./cpu.component.scss'],
})
export class CpuComponent {
  //* Injecting dependecies
  private fb: FormBuilder = inject(FormBuilder);
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private imgUploadService: ImgbbUploadService = inject(ImgbbUploadService);
  private cpuService: CpuService = inject(CpuService);

  @Output() test: EventEmitter<void> = new EventEmitter<void>();
  @ViewChild('componentImgInput') componentImgInput?: ElementRef;

  cpuForm?: FormGroup;

  proggress: number = 0;

  componentImage?: Image;

  ngOnInit(): void {
    const test = this.rootFormGroup.control;
    // console.log(this.rootFormGroup.control.get('cpu'));

    this.cpuForm = this.rootFormGroup.control;
    this.cpuForm.get('cpu')?.addValidators(Validators.required);
    // console.log(this.rootFormGroup.control.get('manufacturer'))

    // console.log(this.cpuForm);
  }

  testing() {
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
              this.proggress = Math.round((event.loaded / event.total!) * 100);
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
    // if (!this.cpuForm) return;
    console.log(this.cpuForm?.value);
    // const body: CpuAddRequest = {
    //   manufacturer: this.cpuForm.get('manufacturer')?.value,
    //   model: this.cpuForm.get('model')?.value,
    //   imageUrl: this.componentImage!.url,

    // };
    // this.cpuService.add(body).pipe(takeUntilDestroyed()).subscribe();
  }
}

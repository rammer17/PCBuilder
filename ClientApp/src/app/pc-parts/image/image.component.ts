import {
  Component,
  DestroyRef,
  ElementRef,
  ViewChild,
  inject,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { Image } from '../image.model';
import { HttpEvent, HttpEventType } from '@angular/common/http';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { tap } from 'rxjs';
import { ImgbbUploadService } from 'src/app/core/services/imgbb-upload.service';
import { FormGroupDirective } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';

@Component({
  selector: 'app-image',
  standalone: true,
  imports: [CommonModule, ButtonModule, RippleModule],
  templateUrl: './image.component.html',
  styles: [],
})
export class ImageComponent {
  //* Injecting dependencies
  private imgUploadService: ImgbbUploadService = inject(ImgbbUploadService);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);

  @ViewChild('componentImgInput') componentImgInput?: ElementRef;

  componentImage?: Image;
  progress: number = 0;

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
              this.rootFormGroup.control.patchValue({
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
    this.rootFormGroup.control.controls['imageUrl'].setErrors({
      incorrect: true,
    });
  }

  onResetImage(): void {
    this.componentImage = undefined;
  }
}

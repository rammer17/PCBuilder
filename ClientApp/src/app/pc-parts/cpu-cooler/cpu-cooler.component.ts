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
import { Observable, tap } from 'rxjs';
import { ImgbbUploadService } from 'src/app/core/services/imgbb-upload.service';
import { Image } from '../image.model';
import { CpuCoolerAddRequest } from 'src/app/core/models/cpu-cooler.model';
import { CpuCoolerService } from 'src/app/core/services/cpu-cooler.service';
import { MessageService } from 'primeng/api';
import { SocketService } from 'src/app/core/services/socket.service';
import { SocketGetResponse } from 'src/app/core/models/socket.model';
import { MultiSelectModule } from 'primeng/multiselect';
@Component({
  selector: 'app-cpuCooler',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
    CommonModule,
    MultiSelectModule,
  ],
  templateUrl: './cpu-cooler.component.html',
  styleUrls: ['../shared-pc-part.scss'],
})
export class CpuCoolerComponent implements OnInit, OnDestroy {
  //* Injecting dependencies
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);
  private destroyRef: DestroyRef = inject(DestroyRef);
  private imgUploadService: ImgbbUploadService = inject(ImgbbUploadService);
  private cpuCoolerService: CpuCoolerService = inject(CpuCoolerService);
  private messageService: MessageService = inject(MessageService);
  private socketService: SocketService = inject(SocketService);

  @ViewChild('componentImgInput') componentImgInput?: ElementRef;

  cpuCoolerForm?: FormGroup;
  progress: number = 0;
  componentImage?: Image;

  socket$?: Observable<SocketGetResponse[]>;

  ngOnInit(): void {
    this.cpuCoolerForm = this.rootFormGroup.control;
    this.cpuCoolerForm.get('cpuCooler')?.addValidators(Validators.required);
    this.socket$ = this.socketService.getAll();
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
              this.cpuCoolerForm?.patchValue({
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
    this.cpuCoolerForm?.controls['imageUrl'].setErrors({ incorrect: true });
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
    this.cpuCoolerForm?.reset({
      manufacturer: this.cpuCoolerForm.get('manufacturer')?.value,
    });
    this.cpuCoolerForm?.controls['cpuCooler'].reset({
      socketIds: '',
      type: '',
    });
    this.cpuCoolerForm?.get('cpuCooler')?.removeValidators(Validators.required);
    this.componentImage = undefined;
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

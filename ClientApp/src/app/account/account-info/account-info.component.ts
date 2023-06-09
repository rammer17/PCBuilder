import { Component, ElementRef, ViewChild, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RippleModule } from 'primeng/ripple';
import { ButtonModule } from 'primeng/button';
import { InputTextareaModule } from 'primeng/inputtextarea';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { UserService } from 'src/app/core/services/user.service';
import { Observable, ReplaySubject, of, switchMap, takeUntil, tap } from 'rxjs';
import {
  Account,
  UserChangeAvatarRequest,
  UserChangeDescriptionRequest,
  UserChangePasswordRequest,
} from 'src/app/core/models/user.model';
import { MessageService } from 'primeng/api';
import { AuthService } from 'src/app/core/services/communication/auth.service';
import { Router } from '@angular/router';
import { AccountStoreService } from 'src/app/core/services/communication/account.store.service';
import { ImgbbUploadService } from 'src/app/core/services/imgbb-upload.service';
import { HttpEvent, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-account-info',
  standalone: true,
  imports: [
    CommonModule,
    ButtonModule,
    RippleModule,
    InputTextareaModule,
    FormsModule,
    PasswordModule,
    ReactiveFormsModule,
  ],
  templateUrl: './account-info.component.html',
  styleUrls: ['./account-info.component.scss'],
})
export class AccountInfoComponent {
  //* Injecting dependencies
  private fb: FormBuilder = inject(FormBuilder);
  private userService: UserService = inject(UserService);
  private messageService: MessageService = inject(MessageService);
  private authService: AuthService = inject(AuthService);
  private router: Router = inject(Router);
  private accountStoreService: AccountStoreService =
    inject(AccountStoreService);
  private imgUploadService: ImgbbUploadService = inject(ImgbbUploadService);

  @ViewChild('descInput') descInput?: ElementRef;
  @ViewChild('avatarInput') avatarInput?: ElementRef;

  descValue = 'This is an example description';
  isDescInputVisible: boolean = false;
  isAvatarVisible: boolean = false;
  isPasswordVisible: boolean = false;

  passwordForm: FormGroup = this.fb.group({
    password: this.fb.control('', Validators.required),
  });
  descriptionForm: FormGroup = this.fb.group({
    description: this.fb.control('', Validators.required),
  });

  accountInfo$?: Observable<Account | null>;
  destroy$: ReplaySubject<void> = new ReplaySubject<void>(1);

  ngOnInit(): void {
    this.accountInfo$ = this.accountStoreService.accountInfo;
  }

  onToggleDescriptionEdit(): void {
    this.isDescInputVisible = !this.isDescInputVisible;
    if (this.isDescInputVisible)
      setTimeout(() => {
        this.descInput?.nativeElement.focus();
      }, 10);
  }
  onToggleAvatarEdit(): void {
    this.isAvatarVisible = !this.isAvatarVisible;
  }
  onTogglePasswordEdit(): void {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  onChangePassword(): void {
    const body: UserChangePasswordRequest = {
      newPassword: this.passwordForm.get('password')?.value,
    };
    this.userService
      .changePassword(body)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        complete: () => {
          this.messageService.add({
            key: 'tc',
            severity: 'success',
            summary: 'Success',
            detail: `Your password has been updated!`,
            life: 3000,
          });
          this.onTogglePasswordEdit();
          this.passwordForm.reset();
        },
      });
  }
  onDeleteAccount(): void {
    this.userService
      .delete()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        complete: () => {
          this.messageService.add({
            key: 'tc',
            severity: 'success',
            summary: 'Success',
            detail: `Your Successfully deleted your account`,
            life: 3000,
          });
          localStorage.removeItem('token');
          this.authService.update();
          this.router.navigateByUrl('builder');
        },
      });
  }

  onSaveDescription(): void {
    this.isDescInputVisible = !this.isDescInputVisible;
    const body: UserChangeDescriptionRequest = {
      newDescription: this.descriptionForm.get('description')?.value,
    };
    this.userService
      .changeDescription(body)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        complete: () => {
          this.messageService.add({
            key: 'tc',
            severity: 'success',
            summary: 'Success',
            detail: `Description was updated successfuly`,
            life: 3000,
          });
          this.accountStoreService.update({ description: body.newDescription });
        },
      });
  }
  onUploadAvatar(): void {
    const file = this.avatarInput?.nativeElement.files[0];
    this.imgUploadService
      .upload(file)
      .pipe(
        tap((event: HttpEvent<any>) => {
          switch (event.type) {
            case HttpEventType.UploadProgress: {
              const progress = Math.round((event.loaded / event.total!) * 100);
              console.log(progress);
              break;
            }
            case HttpEventType.Response: {
              const url = event.body.data.url;
              this.accountStoreService.update({
                imageUrl: url,
              });
            }
          }
        }),
        switchMap((event: HttpEvent<any>) => {
          if (event.type == HttpEventType.Response) {
            console.log('response event');
            const body: UserChangeAvatarRequest = {
              imageUrl: event.body['data']['url'],
            };
            return this.userService.changeAvatar(body);
          }
          return of(event);
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}

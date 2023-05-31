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
import { Observable, ReplaySubject, takeUntil } from 'rxjs';
import {
  Account,
  UserChangeDescriptionRequest,
  UserChangePasswordRequest,
} from 'src/app/core/models/user.model';
import { MessageService } from 'primeng/api';
import { AuthService } from 'src/app/core/services/communication/auth.service';
import { Router } from '@angular/router';
import { AccountStoreService } from 'src/app/core/services/communication/account.store.service';

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
    const newAvatar = this.avatarInput?.nativeElement.files[0];
    console.log(newAvatar);
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}

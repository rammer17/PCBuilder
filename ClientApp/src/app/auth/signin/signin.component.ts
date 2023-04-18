import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { InputTextModule } from 'primeng/inputtext';
import { UserService } from 'src/app/core/services/user.service';
import { take } from 'rxjs';
import { UserSignInRequest } from 'src/app/core/models/user.model';
import { Router } from '@angular/router';
import { FormValidationComponent } from 'src/app/shared/form-validation/form-validation.component';

@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [
    FormValidationComponent,
    CommonModule,
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
    InputTextModule,
  ],
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
})
export class SignInComponent {
  signInForm: FormGroup = this.fb.group({
    email: this.fb.control('', [Validators.required]),
    password: this.fb.control('', [Validators.required]),
  });

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {}

  onSignIn(): void {
    const body: UserSignInRequest = {
      email: this.signInForm.get('email')?.value,
      password: this.signInForm.get('password')?.value,
    };

    this.userService
      .signIn(body)
      .pipe(take(1))
      .subscribe({
        next: (resp) => {
          localStorage.setItem('token', resp);
        },
        complete: () => {
          this.signInForm.reset();
          this.router.navigateByUrl('/builder');
        },
      });
  }
}

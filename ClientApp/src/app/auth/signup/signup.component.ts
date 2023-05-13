import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormGroup,
  Validators,
  FormBuilder,
  ReactiveFormsModule,
} from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { InputTextModule } from 'primeng/inputtext';
import { UserService } from 'src/app/core/services/user.service';
import { UserSignUpRequest } from 'src/app/core/models/user.model';
import { finalize, take } from 'rxjs';
import { FormValidationComponent } from 'src/app/shared/form-validation/form-validation.component';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [
    FormValidationComponent,
    CommonModule,
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
    InputTextModule,
  ],
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignUpComponent {
  //* Injecting dependencies
  private fb: FormBuilder = inject(FormBuilder);
  private userService: UserService = inject(UserService);

  signUpForm: FormGroup = this.fb.group({
    name: this.fb.control('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(40),
    ]),
    email: this.fb.control('', [
      Validators.required,
      Validators.email,
      Validators.maxLength(40),
    ]),
    password: this.fb.control('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(30),
    ]),
  });

  onSignUp(): void {
    const body: UserSignUpRequest = {
      fullName: this.signUpForm.get('name')?.value,
      email: this.signUpForm.get('email')?.value,
      password: this.signUpForm.get('password')?.value,
    };

    this.userService
      .signUp(body)
      .pipe(
        take(1),
        finalize(() => this.signUpForm.reset())
      )
      .subscribe((resp) => console.log(resp));
  }
}

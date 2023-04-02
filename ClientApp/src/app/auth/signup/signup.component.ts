import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, Validators, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ButtonModule, RippleModule, InputTextModule],
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignUpComponent {
  signUpForm: FormGroup = this.fb.group({
    name: this.fb.control('', [Validators.required]),
    email: this.fb.control('', [Validators.required]),
    password: this.fb.control('', [Validators.required]),
  });

  constructor(private fb: FormBuilder) {}

  onSignUp(): void {}
}

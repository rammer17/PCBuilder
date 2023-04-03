import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import {
  FormGroup,
  Validators,
  FormBuilder,
  ReactiveFormsModule,
} from "@angular/forms";
import { ButtonModule } from "primeng/button";
import { RippleModule } from "primeng/ripple";
import { InputTextModule } from "primeng/inputtext";
import { UserService } from "src/app/core/services/user.service";
import { UserSignUpRequest } from "src/app/core/models/user.model";
import { take } from "rxjs";

@Component({
  selector: "app-signup",
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
    InputTextModule,
  ],
  templateUrl: "./signup.component.html",
  styleUrls: ["./signup.component.scss"],
})
export class SignUpComponent {
  signUpForm: FormGroup = this.fb.group({
    name: this.fb.control("", [Validators.required]),
    email: this.fb.control("", [Validators.required]),
    password: this.fb.control("", [Validators.required]),
  });

  constructor(private fb: FormBuilder, private userService: UserService) {}

  onSignUp(): void {
    const body: UserSignUpRequest = {
      fullName: this.signUpForm.get("name")?.value,
      email: this.signUpForm.get("email")?.value,
      password: this.signUpForm.get("password")?.value,
    };

    this.userService.signUp(body).pipe(take(1)).subscribe((resp) => console.log(resp));
  }
}

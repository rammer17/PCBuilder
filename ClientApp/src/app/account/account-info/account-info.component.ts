import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RippleModule } from 'primeng/ripple';
import { ButtonModule } from 'primeng/button';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-account-info',
  standalone: true,
  imports: [CommonModule, ButtonModule, RippleModule, InputTextareaModule, FormsModule],
  templateUrl: './account-info.component.html',
  styleUrls: ['./account-info.component.scss'],
})
export class AccountInfoComponent {
  value = '';

  onEditDescription(): void {}
  onChangeAvatar(): void {}
  onChangeEmail(): void {}
  onChangePassword(): void {}
  onDeleteAccount(): void {}
}

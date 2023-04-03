import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'form-validation',
  templateUrl: './form-validation.html',
  standalone: true,
  imports: [CommonModule],
})
export class FormValidationComponent {
  @Input() control?: AbstractControl;
  @Input() controlName?: string;
  @Input() minLength?: number;
  @Input() maxLength?: number;
}

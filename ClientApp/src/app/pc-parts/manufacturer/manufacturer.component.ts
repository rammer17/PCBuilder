import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ControlContainer,
  FormGroupDirective,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-manufacturer',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './manufacturer.component.html',
  styleUrls: ['../shared-pc-part.scss'],
  viewProviders: [
    {
      provide: ControlContainer,
      useExisting: FormGroupDirective,
    },
  ],
})
export class ManufacturerComponent {
  @Input('manufacturers') manufacturers?: string[];
  @Input('controlName') controlName?: string;
}

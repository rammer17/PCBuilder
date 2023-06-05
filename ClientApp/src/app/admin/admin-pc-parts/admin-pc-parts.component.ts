import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddPcPartComponent } from 'src/app/pc-parts/add-pc-part/add-pc-part.component';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CpuComponent } from 'src/app/pc-parts/cpu/cpu.component';

@Component({
  selector: 'app-admin-pc-parts',
  standalone: true,
  imports: [
    CommonModule,
    AddPcPartComponent,
    ReactiveFormsModule,
    CpuComponent,
  ],
  templateUrl: './admin-pc-parts.component.html',
  styleUrls: ['./admin-pc-parts.component.scss'],
})
export class AdminPcPartsComponent {
  //* Injecting dependecies
  private fb: FormBuilder = inject(FormBuilder);

  pcPartBaseForm: FormGroup = this.fb.group({
    manufacturer: this.fb.control('', [Validators.required]),
    model: this.fb.control('', [Validators.required]),
    imageUrl: this.fb.control('', [Validators.required]),
  });
}

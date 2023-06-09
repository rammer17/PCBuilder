import { Component, EventEmitter, Output, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormGroupDirective,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-cpu',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './cpu.component.html',
  styleUrls: ['./cpu.component.scss'],
})
export class CpuComponent {
  //* Injecting dependecies
  private fb: FormBuilder = inject(FormBuilder);
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);

  @Output() test: EventEmitter<void> = new EventEmitter<void>();

  cpuForm?: FormGroup;

  ngOnInit(): void {

    const test = this.rootFormGroup.control;
    console.log(this.rootFormGroup.control.get('cpu'));

    this.cpuForm = this.rootFormGroup.control;
    this.cpuForm.get('cpu')?.addValidators(Validators.required);
    // console.log(this.rootFormGroup.control.get('manufacturer'))

    console.log(this.cpuForm)
  }
}

import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroupDirective, Validators } from '@angular/forms';
import { PCPartComponent } from '../pc-part.interface';

@Component({
  selector: 'app-cpu',
  standalone: true,
  imports: [],
  templateUrl: './cpu.component.html',
  styleUrls: ['./cpu.component.scss'],
})
export class CpuComponent implements OnInit, PCPartComponent {

  //* Injecting dependecies
  private fb: FormBuilder = inject(FormBuilder);
  private rootFormGroup: FormGroupDirective = inject(FormGroupDirective);

  ngOnInit(): void {
    const test = this.rootFormGroup.control;
    test.addControl('cores', this.fb.control('', [Validators.required]));
    test.addControl('threads', this.fb.control('', [Validators.required]));
    test.addControl('baseClock', this.fb.control('', [Validators.required]));
    test.addControl(
      'maxBoostClock',
      this.fb.control('', [Validators.required])
    );
    test.addControl('socketId', this.fb.control('', [Validators.required]));

    console.log(test);
    // console.log(this.rootFormGroup.control.get('manufacturer'))
  }

  add(): void {
    console.log(1)
  }
}

import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PCParts } from './pc-parts.enum';
import { Router, RouterModule } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  FormGroupDirective,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CpuComponent } from './cpu/cpu.component';

@Component({
  selector: 'app-pc-part-selection',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  providers: [FormGroupDirective],
  templateUrl: './pc-parts.component.html',
  styleUrls: ['./pc-parts.component.scss'],
})
export class PcPartsComponent {
  //* Injecting Dependencies
  private router: Router = inject(Router);
  private fb: FormBuilder = inject(FormBuilder);

  partsForm: FormGroup = this.fb.group({
    manufacturer: this.fb.control('', [Validators.required]),
    model: this.fb.control('', [Validators.required]),
    imageUrl: this.fb.control('', [Validators.required]),
    cpu: this.fb.group({
      cores: this.fb.control('', [Validators.required]),
      threads: this.fb.control('', [Validators.required]),
      baseClock: this.fb.control('', [Validators.required]),
      maxBoostClock: this.fb.control('', [Validators.required]),
      socketId: this.fb.control('', [Validators.required]),
    }),
    cpuCooler: this.fb.group({
      type: this.fb.control('', [Validators.required]),
      tdp: this.fb.control('', [Validators.required]),
      socketIds: this.fb.control([], [Validators.required]),
      maxRPM: this.fb.control('', [Validators.required]),
      noiseLevel: this.fb.control('', [Validators.required]),
    }),
    motherboard: this.fb.group({
      formFactor: this.fb.control('', [Validators.required]),
      socketId: this.fb.control('', [Validators.required]),
      chipsetId: this.fb.control('', [Validators.required]),
      memorySlots: this.fb.control('', [Validators.required]),
      memoryType: this.fb.control('', [Validators.required]),
      memorySpeed: this.fb.control('', [Validators.required]),
      wifi: this.fb.control(false, [Validators.required]),
      portIds: this.fb.control([], [Validators.required]),
      connectorIds: this.fb.control([], [Validators.required]),
      storageSlotIds: this.fb.control([], [Validators.required]),
    }),
    memory: this.fb.group({
      capacity: this.fb.control('', [Validators.required]),
      frequency: this.fb.control('', [Validators.required]),
      type: this.fb.control('', [Validators.required]),
      timing: this.fb.control('', [Validators.required]),
    }),
    storage: this.fb.group({
      type: this.fb.control('', [Validators.required]),
      capacity: this.fb.control('', [Validators.required]),
      formFactor: this.fb.control('', [Validators.required]),
      readSpeed: this.fb.control('', [Validators.required]),
      writeSpeed: this.fb.control('', [Validators.required]),
      interface: this.fb.control('', [Validators.required]),
    }),
    gpu: this.fb.group({
      baseClock: this.fb.control('', [Validators.required]),
      maxBoostClock: this.fb.control('', [Validators.required]),
      memorySize: this.fb.control('', [Validators.required]),
      memoryType: this.fb.control('', [Validators.required]),
      memoryBus: this.fb.control('', [Validators.required]),
      tdp: this.fb.control('', [Validators.required]),
      height: this.fb.control('', [Validators.required]),
      width: this.fb.control('', [Validators.required]),
    }),
    case: this.fb.group({
      type: this.fb.control('', [Validators.required]),
      formFactor: this.fb.control('', [Validators.required]),
      maxGpuHeight: this.fb.control('', [Validators.required]),
      maxGpuWidth: this.fb.control('', [Validators.required]),
    }),
    psu: this.fb.group({
      type: this.fb.control('', [Validators.required]),
      efficiencyRating: this.fb.control('', [Validators.required]),
      formFactor: this.fb.control('', [Validators.required]),
      wattage: this.fb.control('', [Validators.required]),
      internalConnectorIds: this.fb.control([], [Validators.required]),
    }),
  });

  onSelectPart(pcPart: PCParts): void {
    switch (pcPart) {
      case 0: {
        this.router.navigateByUrl('/components/cpu');
        break;
      }
      case 1: {
        this.router.navigateByUrl('/components/cooler');
        break;
      }
      case 2: {
        this.router.navigateByUrl('/components/motherboard');
        break;
      }
      case 3: {
        this.router.navigateByUrl('/components/memory');
        break;
      }
      case 4: {
        this.router.navigateByUrl('/components/storage');
        break;
      }
      case 5: {
        this.router.navigateByUrl('/components/gpu');
        break;
      }
      case 6: {
        this.router.navigateByUrl('/components/case');
        break;
      }
      case 7: {
        this.router.navigateByUrl('/components/psu');
        break;
      }
    }
  }
}

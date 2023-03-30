import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { CpuService } from '../core/services/cpu.service';
import { take } from 'rxjs';
import { CommonModule } from '@angular/common';
import { PcAddComponentComponent } from './pc-add-component/pc-add-component.component';

@Component({
  selector: 'app-pc-builder',
  standalone: true,
  imports: [CommonModule, TableModule, ButtonModule, RippleModule, DialogModule, PcAddComponentComponent],
  templateUrl: './pc-builder.component.html',
  styleUrls: ['./pc-builder.component.scss'],
})
export class PcBuilderComponent {
  components = [
    {
      name: 'CPU',
    },
    {
      name: 'CPU Cooler',
    },
    {
      name: 'Motherboard',
    },
    {
      name: 'Memory',
    },
    {
      name: 'Storage',
    },
    {
      name: 'Graphics Card',
    },
    {
      name: 'Case',
    },
    {
      name: 'Power Supply',
    },
  ];

  visible = false;
  currentComponent: string = '';

  constructor(private cpuService: CpuService) {}

  onAddComponent(component: string) {
    this.visible = true;
    this.currentComponent = component;

    switch (component) {
      case 'CPU': {
        this.cpuService
          .getCompatible({
            CpuCoolerId: 0,
            MotherboardId: 0,
          })
          .pipe(take(1))
          .subscribe((value) => console.log(value));
        break;
      }
      case 'CPU Cooler': {
        break;
      }
      case 'Motherboard': {
        break;
      }
      case 'Memory': {
        break;
      }
      case 'Graphics Card': {
        break;
      }
      case 'Case': {
        break;
      }
      case 'Power Supply': {
        break;
      }
    }
  }
}

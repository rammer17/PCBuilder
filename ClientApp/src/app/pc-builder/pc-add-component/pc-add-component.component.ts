import {
  AfterViewInit,
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
  Renderer2,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { CpuService } from 'src/app/core/services/cpu.service';
import { CpuCoolerService } from 'src/app/core/services/cpu-cooler.service';
import { MotherboardService } from 'src/app/core/services/motherboard.service';
import { RamService } from 'src/app/core/services/ram.service';
import { StorageService } from 'src/app/core/services/storage.service';
import { GpuService } from 'src/app/core/services/gpu.service';
import { CaseService } from 'src/app/core/services/case.service';
import { PowerSupplyService } from 'src/app/core/services/power-supply.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-pc-add-component',
  standalone: true,
  imports: [CommonModule, DialogModule],
  templateUrl: './pc-add-component.component.html',
  styleUrls: ['./pc-add-component.component.scss'],
})
export class PcAddComponentComponent
  implements OnInit, AfterViewInit, OnDestroy
{
  @Output() closeAddComponent: EventEmitter<boolean> =
    new EventEmitter<boolean>();
  @Input() component: any;

  component$: any;

  private listenerFn?: () => void;

  visible: boolean = true;

  constructor(
    private renderer: Renderer2,
    private cpuService: CpuService,
    private cpuCoolerService: CpuCoolerService,
    private motherboardService: MotherboardService,
    private ramService: RamService,
    private storageService: StorageService,
    private gpuService: GpuService,
    private caseService: CaseService,
    private psuService: PowerSupplyService
  ) {}

  ngOnInit(): void {
    this.onAddComponent();
  }

  ngAfterViewInit(): void {
    const closeBtn = document.querySelector(
      '.p-dialog .p-dialog-header .p-dialog-header-icon'
    );
    this.listenerFn = this.renderer.listen(
      closeBtn,
      'click',
      this.onCloseComponent
    );
  }

  private onCloseComponent: () => void = () => {
    this.visible = false;
    setTimeout(() => {
      this.closeAddComponent.emit(this.visible);
    }, 100);
  };

  onAddComponent(): void {
    switch (this.component) {
      case 'CPU': {
        this.component$ = this.cpuService
          .getCompatible({
            cpuCoolerId: 2,
            motherboardId: 0,
          })
          .pipe(take(1));
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
      case 'Storage': {
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

  ngOnDestroy(): void {
    if (this.listenerFn) this.listenerFn();
  }
}

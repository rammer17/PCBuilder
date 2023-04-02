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
import { Observable, ReplaySubject, take, takeUntil } from 'rxjs';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { PCComponent } from 'src/app/core/models/pc-component.model';
import { PcBuildService } from 'src/app/core/services/communication/pc-build.service';
import { PC } from 'src/app/core/models/pc.model';

@Component({
  selector: 'app-pc-add-component',
  standalone: true,
  imports: [CommonModule, DialogModule, ButtonModule, RippleModule],
  templateUrl: './pc-add-component.component.html',
  styleUrls: ['./pc-add-component.component.scss'],
})
export class PcAddComponentComponent
  implements OnInit, AfterViewInit, OnDestroy
{
  @Output() addedComponent: EventEmitter<PCComponent> =
    new EventEmitter<PCComponent>();
  @Output() closeAddComponent: EventEmitter<boolean> =
    new EventEmitter<boolean>();
  @Input() component: any;

  component$?: Observable<any>;
  destroy$: ReplaySubject<void> = new ReplaySubject<void>(1);

  private listenerFn?: () => void;

  visible: boolean = true;

  pc: PC = {
    cpuId: 0,
    cpuCoolerId: 0,
    motherboardId: 0,
    ramId: 0,
    storageId: 0,
    gpuId: 0,
    caseId: 0,
    powerSupplyId: 0,
  };

  constructor(
    private renderer: Renderer2,
    private cpuService: CpuService,
    private cpuCoolerService: CpuCoolerService,
    private motherboardService: MotherboardService,
    private ramService: RamService,
    private storageService: StorageService,
    private gpuService: GpuService,
    private caseService: CaseService,
    private psuService: PowerSupplyService,
    private pcComService: PcBuildService
  ) {}

  ngOnInit(): void {
    this.pcComService.pc.pipe(takeUntil(this.destroy$)).subscribe({
      next: (resp: PC | null) => {
        if (resp) {
          this.pc = resp;
        }
      },
      error: (err) => console.log(err),
    });

    this.fetchComponents();
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

  fetchComponents(): void {
    switch (this.component) {
      case 'CPU': {
        this.component$ = this.cpuService
          .getCompatible({
            cpuCoolerId:
              this.pc.cpuCoolerId !== undefined ? this.pc.cpuCoolerId : 0,
            motherboardId:
              this.pc.motherboardId !== undefined ? this.pc.motherboardId : 0,
          })
          .pipe(take(1));
        break;
      }
      case 'CPU Cooler': {
        this.component$ = this.cpuCoolerService
          .getCompatible({
            cpuId: this.pc.cpuId !== undefined ? this.pc.cpuId : 0,
          })
          .pipe(take(1));
        break;
      }
      case 'Motherboard': {
        this.component$ = this.motherboardService
          .getCompatible({
            cpuId: this.pc.cpuId !== undefined ? this.pc.cpuId : 0,
            caseId: this.pc.caseId !== undefined ? this.pc.caseId : 0,
            ramId: this.pc.ramId !== undefined ? this.pc.ramId : 0,
          })
          .pipe(take(1));
        break;
      }
      case 'Memory': {
        this.component$ = this.ramService
          .getCompatible({
            motherboardId:
              this.pc.motherboardId !== undefined ? this.pc.motherboardId : 0,
          })
          .pipe(take(1));
        break;
      }
      case 'Storage': {
        this.component$ = this.storageService.getAll().pipe(take(1));
        break;
      }
      case 'Graphics Card': {
        this.component$ = this.gpuService
          .getCompatible({
            caseId: this.pc.caseId !== undefined ? this.pc.caseId : 0,
          })
          .pipe(take(1));
        break;
      }
      case 'Case': {
        this.component$ = this.caseService
          .getCompatible({
            motherboardId:
              this.pc.motherboardId !== undefined ? this.pc.motherboardId : 0,
            powerSupplyId:
              this.pc.powerSupplyId !== undefined ? this.pc.powerSupplyId : 0,
            gpuId: this.pc.gpuId !== undefined ? this.pc.gpuId : 0,
          })
          .pipe(take(1));
        break;
      }
      case 'Power Supply': {
        this.component$ = this.psuService
          .getCompatible({
            caseId: this.pc.caseId !== undefined ? this.pc.caseId : 0,
          })
          .pipe(take(1));
        break;
      }
    }
  }

  onAddComponent(component: PCComponent): void {
    this.addedComponent.emit(component);
    this.onCloseComponent();
  }

  ngOnDestroy(): void {
    if (this.listenerFn) this.listenerFn();
    this.destroy$.next();
    this.destroy$.complete();
  }
}

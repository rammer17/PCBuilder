import {
  Component,
  ElementRef,
  QueryList,
  Renderer2,
  ViewChildren,
} from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { CommonModule } from '@angular/common';
import { PcAddComponentComponent } from './pc-add-component/pc-add-component.component';
import { PCComponent } from '../core/models/pc-component.model';
import { PC } from '../core/models/pc.model';
import { PcBuildService } from '../core/services/communication/pc-build.service';
import { ShareDialogComponent } from './share-dialog/share-dialog.component';

@Component({
  selector: 'app-pc-builder',
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    RippleModule,
    DialogModule,
    PcAddComponentComponent,
    ShareDialogComponent
  ],
  templateUrl: './pc-builder.component.html',
  styleUrls: ['./pc-builder.component.scss'],
})
export class PcBuilderComponent {
  @ViewChildren('componentSites') componentSites?: QueryList<ElementRef>;

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
  isDialogVisible: boolean = false;
  isShareDialogVisible: boolean = false;
  showAddBtns: boolean[] = [true, true, true, true, true, true, true, true];
  currentComponent: string = '';
  chosenComponent: string = '';
  

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
    private pcComService: PcBuildService
  ) {}

  onAddComponent(component: string): void {
    this.pcComService.setPC(this.pc);

    this.isDialogVisible = true;
    this.currentComponent = component;
    this.chosenComponent = component;
  }

  onComponentAdded(component: PCComponent): void {
    let details: string = '';
    if ('cores' in component) {
      details = `${component.manufacturer} ${component.model} ${component.socket} ${component.cores}-Core Processor`;
      this.renderComponent(0, details);
      this.pc.cpuId = component.id;
      return;
    } else if ('maxRPM' in component) {
      details = `${component.manufacturer} ${component.model} ${component.type} Cooler`;
      this.renderComponent(1, details);
      this.pc.cpuCoolerId = component.id;
      return;
    } else if ('wifi' in component) {
      details = `${component.manufacturer} ${component.model} ${component.chipset} ${component.formFactor} ${component.socket}`;
      this.renderComponent(2, details);
      this.pc.motherboardId = component.id;
      return;
    } else if ('frequency' in component) {
      details = `${component.manufacturer} ${component.model} ${component.type} ${component.capacity}GB ${component.frequency}MHz`;
      this.renderComponent(3, details);
      this.pc.ramId = component.id;
      return;
    } else if ('readSpeed' in component) {
      details = `${component.manufacturer} ${component.model} ${component.type} ${component.formFactor}" ${component.capacity}MB ${component.interface}`;
      this.renderComponent(4, details);
      this.pc.storageId = component.id;
      return;
    } else if ('height' in component) {
      details = `${component.manufacturer} ${component.model} ${component.memoryType} ${component.memorySize}GB`;
      this.renderComponent(5, details);
      this.pc.gpuId = component.id;
      return;
    } else if ('maxGpuWidth' in component) {
      details = `${component.manufacturer} ${component.model} ${component.formFactor} ${component.type}`;
      this.renderComponent(6, details);
      this.pc.caseId = component.id;
      return;
    } else if ('wattage' in component) {
      details = `${component.manufacturer} ${component.model} ${component.wattage}W ${component.formFactor} ${component.efficiencyRating} ${component.type}`;
      this.renderComponent(7, details);
      this.pc.powerSupplyId = component.id;
      return;
    }
  }

  private renderComponent(index: number, details: string): void {
    const componentWrapperEl = this.renderer.createElement('div');
    const imgContainerEl = this.renderer.createElement('div');
    const imgEl = this.renderer.createElement('img');
    const descriptionEl = this.renderer.createElement('span');
    const descriptionText = this.renderer.createText(details);
    const newElementSite = this.componentSites?.get(index);

    this.showAddBtns[index] = false;

    this.renderer.setAttribute(componentWrapperEl, 'class', 'd-flex');
    this.renderer.setAttribute(imgContainerEl, 'class', 'img-container mx-2');
    this.renderer.setAttribute(imgEl, 'alt', 'Not found');
    this.renderer.setAttribute(descriptionEl, 'class', 'mx-2');

    this.renderer.appendChild(imgContainerEl, imgEl);
    this.renderer.appendChild(componentWrapperEl, imgContainerEl);
    this.renderer.appendChild(descriptionEl, descriptionText);
    this.renderer.appendChild(componentWrapperEl, descriptionEl);
    this.renderer.appendChild(
      newElementSite?.nativeElement,
      componentWrapperEl
    );
  }

  onRemoveComponent(index: number): void {
    const component = this.componentSites?.get(index);

    this.renderer.removeChild(
      component?.nativeElement,
      component?.nativeElement.firstElementChild
    );

    this.showAddBtns[index] = true;

    const objPropName = Object.keys(this.pc)[index] as keyof typeof this.pc;
    this.pc[objPropName] = 0;
  }

  onCloseAddComponent(e: boolean): void {
    this.isDialogVisible = e;
  }

  onCloseShareDialog(e: boolean): void {
    this.isShareDialogVisible = e;
  }

  onShare(): void {
    this.isShareDialogVisible = true;
  }
}

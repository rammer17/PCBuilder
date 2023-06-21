import {
  Component,
  ElementRef,
  QueryList,
  Renderer2,
  ViewChildren,
  inject,
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
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { TooltipModule } from 'primeng/tooltip';
import { ImgbbUploadService } from '../core/services/imgbb-upload.service';
import { tap } from 'rxjs';

@Component({
  selector: 'app-pc-builder',
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    RippleModule,
    DialogModule,
    TooltipModule,
    PcAddComponentComponent,
    ShareDialogComponent,
  ],
  templateUrl: './pc-builder.component.html',
  styleUrls: ['./pc-builder.component.scss'],
})
export class PcBuilderComponent {
  //* Injecting dependencies
  private pcComService: PcBuildService = inject(PcBuildService);
  private fb: FormBuilder = inject(FormBuilder);
  private renderer: Renderer2 = inject(Renderer2);
  private imgbbUploadService = inject(ImgbbUploadService);

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

  isShareDisabled: boolean = true;

  pcForm = this.fb.group({
    cpuId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    cpuCoolerId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    motherboardId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    ramId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    storageId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    gpuId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    caseId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    powerSupplyId: this.fb.control(0, [Validators.required, Validators.min(1)]),
  });

  onAddComponent(component: string): void {
    const data: PC = {
      cpuId: this.pcForm.get('cpuId')?.value,
      cpuCoolerId: this.pcForm.get('cpuCoolerId')?.value,
      motherboardId: this.pcForm.get('motherboardId')?.value,
      ramId: this.pcForm.get('ramId')?.value,
      storageId: this.pcForm.get('storageId')?.value,
      gpuId: this.pcForm.get('gpuId')?.value,
      caseId: this.pcForm.get('caseId')?.value,
      powerSupplyId: this.pcForm.get('powerSupplyId')?.value,
    };

    this.pcComService.setPC(data);

    this.isDialogVisible = true;
    this.currentComponent = component;
    this.chosenComponent = component;
  }

  onComponentAdded(component: PCComponent): void {
    let details: string = '';
    if ('cores' in component) {
      details = `${component.manufacturer} ${component.model} ${component.socket} ${component.cores}-Core Processor`;
      this.renderComponent(0, details, component.imageUrl);
      this.pcForm.patchValue({
        cpuId: component.id,
      });
      return;
    } else if ('maxRPM' in component) {
      details = `${component.manufacturer} ${component.model} ${component.type} Cooler`;
      this.renderComponent(1, details, component.imageUrl);
      this.pcForm.patchValue({
        cpuCoolerId: component.id,
      });
      return;
    } else if ('wifi' in component) {
      details = `${component.manufacturer} ${component.model} ${component.chipset} ${component.formFactor} ${component.socket}`;
      this.renderComponent(2, details, component.imageUrl);
      this.pcForm.patchValue({
        motherboardId: component.id,
      });
      return;
    } else if ('frequency' in component) {
      details = `${component.manufacturer} ${component.model} ${component.type} ${component.capacity}GB ${component.frequency}MHz`;
      this.renderComponent(3, details, component.imageUrl);
      this.pcForm.patchValue({
        ramId: component.id,
      });
      return;
    } else if ('readSpeed' in component) {
      details = `${component.manufacturer} ${component.model} ${component.type} ${component.formFactor}" ${component.capacity}MB ${component.interface}`;
      this.renderComponent(4, details, component.imageUrl);
      this.pcForm.patchValue({
        storageId: component.id,
      });
      return;
    } else if ('height' in component) {
      details = `${component.manufacturer} ${component.model} ${component.memoryType} ${component.memorySize}GB`;
      this.renderComponent(5, details, component.imageUrl);
      this.pcForm.patchValue({
        gpuId: component.id,
      });
      return;
    } else if ('maxGpuWidth' in component) {
      details = `${component.manufacturer} ${component.model} ${component.formFactor} ${component.type}`;
      this.renderComponent(6, details, component.imageUrl);
      this.pcForm.patchValue({
        caseId: component.id,
      });
      return;
    } else if ('wattage' in component) {
      details = `${component.manufacturer} ${component.model} ${component.wattage}W ${component.formFactor} ${component.efficiencyRating} ${component.type}`;
      this.renderComponent(7, details, component.imageUrl);
      this.pcForm.patchValue({
        powerSupplyId: component.id,
      });
      return;
    }
  }

  private renderComponent(
    index: number,
    details: string,
    imageUrl: string
  ): void {
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
    this.renderer.setAttribute(imgEl, 'src', imageUrl);
    this.renderer.setAttribute(imgEl, 'class', 'img');
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

  onRemoveComponent(componentName: string, index: number): void {
    const component = this.componentSites?.get(index);

    this.renderer.removeChild(
      component?.nativeElement,
      component?.nativeElement.firstElementChild
    );

    this.showAddBtns[index] = true;

    const objPropName = this.convertToObjePropName(componentName);

    this.pcForm.patchValue({
      [objPropName]: 0,
    });
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

  private convertToObjePropName(string: string) {
    return (
      string
        .toLowerCase()
        .trim()
        .split(/[.\-_\s]/g)
        .reduce(
          (string, word) => string + word[0].toUpperCase() + word.slice(1)
        ) + 'Id'
    );
  }

  test(e: any) {
    this.imgbbUploadService
      .upload(e.target.files[0])
      .pipe(tap((resp) => console.log('tap ', resp)))
      .subscribe((resp) => console.log(resp));
  }
}

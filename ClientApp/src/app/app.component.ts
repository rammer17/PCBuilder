import { Component } from '@angular/core';
import { LoaderComponent } from './shared/loader/loader.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  private url: string = 'http://localhost:5001';
  public loaderComponent = LoaderComponent;
  filteredUrls: string[] = [
    `${this.url}/Cpu/GetCompatible`,
    `${this.url}/CpuCooler/GetCompatible`,
    `${this.url}/Motherboard/GetCompatible`,
    `${this.url}/Ram/GetCompatible`,
    `${this.url}/Storage/GetCompatible`,
    `${this.url}/Gpu/GetCompatible`,
    `${this.url}/Case/GetCompatible`,
    `${this.url}/PowerSupply/GetCompatible`,
  ]
}

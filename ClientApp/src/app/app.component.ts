import { Component, inject } from '@angular/core';
import { LoaderComponent } from './shared/loader/loader.component';
import { AuthService } from './core/services/communication/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  private authService = inject(AuthService);

  private url: string = 'http://localhost:5001';
  public loaderComponent = LoaderComponent;
  filteredUrls: string[] = [
    `${this.url}/Cpu/GetCompatible`,
    `${this.url}/CpuCooler/GetCompatible`,
    `${this.url}/Motherboard/GetCompatible`,
    `${this.url}/Ram/GetCompatible`,
    `${this.url}/Storage/GetAll`,
    `${this.url}/Gpu/GetCompatible`,
    `${this.url}/Case/GetCompatible`,
    `${this.url}/PowerSupply/GetCompatible`,
  ]

  ngOnInit(): void {
    this.authService.onLoadApplication();
  }
}

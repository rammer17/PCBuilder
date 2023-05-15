import { Component, inject } from '@angular/core';
import { LoaderComponent } from './shared/loader/loader.component';
import { AuthService } from './core/services/communication/auth.service';
import { ToastModule } from 'primeng/toast';
import { PcCommunityBuildsComponent } from './pc-community-builds/pc-community-builds.component';
import { FooterComponent } from './shared/layout/footer/footer.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    ToastModule,

    HeaderComponent,
    FooterComponent,
    LoaderComponent,
    PcCommunityBuildsComponent,
  ],
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
  ];

  ngOnInit(): void {
    this.authService.onLoadApplication();
  }
}

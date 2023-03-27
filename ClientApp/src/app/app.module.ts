import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { FooterComponent } from './shared/layout/footer/footer.component';
import { CpuComponent } from './pc-parts/cpu/cpu.component';
import { GpuComponent } from './pc-parts/gpu/gpu.component';
import { PcBuildComponent } from './pc-build/pc-build.component';
import { ComponentListComponent } from './pc-build/component-list/component-list.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    CpuComponent,
    GpuComponent,
    PcBuildComponent,
    ComponentListComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

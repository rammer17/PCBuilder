import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './shared/layout/footer/footer.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { SharedModule } from './shared/shared.module';
import { PcCommunityBuildsComponent } from './pc-community-builds/pc-community-builds.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HeaderComponent,
    FooterComponent,
    PcCommunityBuildsComponent,
    
    BrowserModule,
    AppRoutingModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

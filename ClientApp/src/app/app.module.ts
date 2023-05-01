import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './shared/layout/footer/footer.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { SharedModule } from './shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PcCommunityBuildsComponent } from './pc-community-builds/pc-community-builds.component';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { LoaderComponent } from './shared/loader/loader.component';
import { NgHttpLoaderModule } from 'ng-http-loader';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ErrorInterceptor } from './error.interceptor';
import { ToastModule } from 'primeng/toast';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';

const initializeAppFactory = (primeConfig: PrimeNGConfig) => () => {
  primeConfig.ripple = true;
};

@NgModule({
  declarations: [AppComponent],
  imports: [
    HeaderComponent,
    FooterComponent,
    LoaderComponent,
    PcCommunityBuildsComponent,

    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgHttpLoaderModule.forRoot(),
    ToastModule,
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeAppFactory,
      deps: [PrimeNGConfig],
      multi: true,
    },
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS }, JwtHelperService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    MessageService
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

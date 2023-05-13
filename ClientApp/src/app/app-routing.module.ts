import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PcBuilderComponent } from './pc-builder/pc-builder.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', component: PcBuilderComponent },
  {
    path: 'signin',
    loadComponent: () =>
      import('./auth/signin/signin.component').then((c) => c.SignInComponent),
    canActivate: [AuthGuard],
  },
  {
    path: 'signup',
    loadComponent: () =>
      import('./auth/signup/signup.component').then((c) => c.SignUpComponent),
    canActivate: [AuthGuard],
  },
  { path: 'builder', component: PcBuilderComponent },
  {
    path: 'community',
    loadComponent: () =>
      import('./pc-community-builds/pc-community-builds.component').then(
        (c) => c.PcCommunityBuildsComponent
      ),
  },
  {
    path: 'account',
    loadComponent: () =>
      import('./account/account.component').then(
        (c) => c.AccountComponent
      ),
  },
  { path: '**', redirectTo: 'builder', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

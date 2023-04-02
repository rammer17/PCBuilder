import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PcBuilderComponent } from './pc-builder/pc-builder.component';
import { PcCommunityBuildsComponent } from './pc-community-builds/pc-community-builds.component';
import { SignUpComponent } from './auth/signup/signup.component';
import { SignInComponent } from './auth/signin/signin.component';

const routes: Routes = [
  { path: '', component: PcBuilderComponent },
  { path: 'signin', component: SignInComponent },
  { path: 'signup', component: SignUpComponent },
  { path: 'builder', component: PcBuilderComponent },
  { path: 'community', component: PcCommunityBuildsComponent },
  { path: '**', redirectTo: 'builder', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

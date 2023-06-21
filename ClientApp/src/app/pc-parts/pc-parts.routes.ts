import { Route } from '@angular/router';
import { PcPartsComponent } from './pc-parts.component';
import { CpuComponent } from './cpu/cpu.component';
import { GpuComponent } from './gpu/gpu.component';

export const PC_PARTS_ROUTES: Route[] = [
  {
    path: '',
    component: PcPartsComponent,
    children: [
      { path: '', children: [] },
      { path: 'cpu', component: CpuComponent },
      { path: 'cooler', component: CpuComponent },
      { path: 'motherboard', component: CpuComponent },
      { path: 'memory', component: CpuComponent },
      { path: 'storage', component: CpuComponent },
      { path: 'gpu', component: GpuComponent },
      { path: 'case', component: CpuComponent },
      { path: 'psu', component: CpuComponent },
      { path: '**', redirectTo: 'cpu', pathMatch: 'full' },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

import { Route } from '@angular/router';
import { PcPartSelectionComponent } from './pc-part-selection/pc-part-selection.component';

export const PC_PARTS_ROUTES: Route[] = [
  { path: '', component: PcPartSelectionComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

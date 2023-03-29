import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-pc-builder',
  standalone: true,
  imports: [TableModule, ButtonModule, RippleModule],
  templateUrl: './pc-builder.component.html',
  styleUrls: ['./pc-builder.component.scss']
})
export class PcBuilderComponent {
  products = [
    {
      component: 'CPU'
    },
    {
      component: 'CPU Cooler'
    }
  ]

  constructor() {}
}

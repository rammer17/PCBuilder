import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';

@Component({
  selector: 'app-pc-add-component',
  standalone: true,
  imports: [CommonModule, DialogModule],
  templateUrl: './pc-add-component.component.html',
  styleUrls: ['./pc-add-component.component.scss']
})
export class PcAddComponentComponent {

}

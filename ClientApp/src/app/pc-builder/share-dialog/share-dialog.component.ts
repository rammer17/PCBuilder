import {
  Component,
  ElementRef,
  EventEmitter,
  Output,
  Renderer2,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';

@Component({
  selector: 'app-share-dialog',
  standalone: true,
  imports: [
    CommonModule,
    DialogModule,
    InputTextModule,
    CheckboxModule,
    RadioButtonModule,
    ButtonModule,
    RippleModule,
  ],
  templateUrl: './share-dialog.component.html',
  styleUrls: ['./share-dialog.component.scss'],
})
export class ShareDialogComponent {
  @Output() closeShareDialog: EventEmitter<boolean> =
    new EventEmitter<boolean>();

  @ViewChild('link') linkInput?: ElementRef;

  visible: boolean = true;
  listenerFn?: () => void;
  buttonLabel: string = 'Copy';

  constructor(private renderer: Renderer2) {}

  ngAfterViewInit(): void {
    const closeBtn = document.querySelector(
      '.p-dialog .p-dialog-header .p-dialog-header-icon'
    );
    this.listenerFn = this.renderer.listen(
      closeBtn,
      'click',
      this.onCloseDialog
    );
  }

  private onCloseDialog: () => void = () => {
    this.visible = false;
    setTimeout(() => {
      this.closeShareDialog.emit(this.visible);
    }, 100);
  };

  onCopy(e: any): void {
    e.currentTarget.classList.replace('p-button-primary', 'p-button-success');
    this.buttonLabel = 'Copied';
    navigator.clipboard.writeText(this.linkInput?.nativeElement.value)
  }
}

import { Component, OnInit, inject } from '@angular/core';
import { SharedModule } from '../../shared.module';
import { AuthService } from 'src/app/core/services/communication/auth.service';
import { Observable } from 'rxjs';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [SharedModule, ButtonModule, RippleModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  //* Injecting dependencies
  private authService: AuthService = inject(AuthService);

  isSignedIn$?: Observable<boolean>;

  ngOnInit(): void {
    this.isSignedIn$ = this.authService.test();
  }

  onSignOut(): void {
    localStorage.removeItem('token');
    this.authService.update();
  }
}

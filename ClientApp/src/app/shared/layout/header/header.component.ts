import { Component, OnInit, inject } from '@angular/core';
import { AuthService } from 'src/app/core/services/communication/auth.service';
import { Observable } from 'rxjs';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [ButtonModule, RippleModule, RouterModule, CommonModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  //* Injecting dependencies
  private authService: AuthService = inject(AuthService);
  private router: Router = inject(Router);

  isSignedIn$?: Observable<boolean>;

  ngOnInit(): void {
    this.isSignedIn$ = this.authService.test();
  }

  onSignOut(): void {
    localStorage.removeItem('token');
    this.authService.update();
    this.router.navigateByUrl('/builder')
  }
}

import { Observable } from 'rxjs';
import { AuthService } from './../auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: [
    `.angular-logo {
        margin: 0 4px 3px 0;
        height: 35px;
        vertical-align: middle;
    }
    .fill-remaining-space {
      flex: 1 1 auto;
    }
    .mat-button-flex {
      flex: 1 1 auto;
    }
    .mat-button-flex-large {
      width: 120px;
    }
    `
  ]
})
export class HeaderComponent implements OnInit {
  isRedirectingToLogin = false;
  constructor(private authService: AuthService, private jwtHelper: JwtHelperService, private router: Router) {
    localStorage.removeItem("jwt");
  }


  ngOnInit() {
  }

  onLogout() {
    this.authService.logout();
  }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
    if (token) {
      if (!this.jwtHelper.isTokenExpired(token)) {
        return true;
      }
      // else {
      //   if (!this.isRedirectingToLogin) {
      //     this.isRedirectingToLogin = true;
      //     this.router.navigate(['/login']).then(() => {
      //       this.isRedirectingToLogin = false;
      //     });
      //   }
      // }
    }

    return false;
  }
}
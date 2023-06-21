import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { User } from './user';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AuthService {
  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private apiurl = 'https://localhost:7170/api/AuthenticationController/Login'
  private authHttpOptions: any;
  static generalHttpOptions: any;
  static token: string;
  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
  // invalidLogin: boolean;

  constructor(
    private router: Router,
    private http: HttpClient
  ) {
    this.authHttpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
  }

  login(user: User) {
    if (user.username !== '' && user.password !== '') {
      return this.http.post(this.apiurl, user, this.authHttpOptions).subscribe(
        (response) => {
          const token = (<any>response).token;
          localStorage.setItem("jwt", token);
          
          this.loggedIn.next(true);
          this.router.navigate(['/']);
        },err=>{
          this.loggedIn.next(false);
        }
      )
    }
  }

  logout() {
    localStorage.removeItem("jwt");
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }
}
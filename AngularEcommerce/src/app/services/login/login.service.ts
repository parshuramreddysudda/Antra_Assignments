import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginResponse } from '../../components/types/login';
import { environment } from '../../../environments/environment.development';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  loginStatusChange = this.loggedIn.asObservable();

  constructor(
    private http: HttpClient,
    private cookieService: SsrCookieService,
    private toast: NgToastService,
    private router:Router
  ) {
    // Initialize login status based on existing token
    this.loggedIn.next(this.userIsLoggedIn());
  }

  login(credentials: any): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(environment.loginURl + "login", credentials);
  }

  userIsLoggedIn(): boolean {
    const token = this.getToken();
    const isLoggedIn = !!token;
    return isLoggedIn;
  }

  getToken(): string | null {
    return this.cookieService.get(environment.Token);
  }

  setToken(token: string): void {
    this.cookieService.set(environment.Token, token);
    // Emit login status change
    this.loggedIn.next(true);
    this.router.navigate(['home'])
    this.toast.success("User Login Successfully ");
  }

  logoutUser(): void {
    this.cookieService.delete(environment.Token);
    this.router.navigate(['login'])
    this.toast.warning("User Logged Out Successfully ");
    // Emit login status change
    this.loggedIn.next(false);
  }
}

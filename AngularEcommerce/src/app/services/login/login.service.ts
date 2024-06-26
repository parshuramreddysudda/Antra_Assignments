import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { LoginResponse } from '../../components/types/login';
import { environment } from '../../../environments/environment.development';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
import { Register } from '../../components/types/register';
import { Store } from '@ngrx/store';
import { addLoginInfo, removeLoginInfo } from '../../states/user/user.action';

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
    private router: Router,
    private store: Store
  ) {
    this.loggedIn.next(this.userIsLoggedIn());
  }

  login(credentials: any): void {
    this.http.post<LoginResponse>(`${environment.loginURl}login`, credentials)
      .pipe(
        tap(data => this.handleLoginSuccess(data)),
        catchError(err => this.handleError(err, 'Login failed'))
      )
      .subscribe();
  }

  register(credentials: any): void {
    this.http.post<Register>(`${environment.loginURl}login/register`, credentials)
      .pipe(
        tap(data => this.handleLoginSuccess(data)),
        catchError(err => this.handleError(err, 'Registration failed'))
      )
      .subscribe();
  }

   handleLoginSuccess(data: LoginResponse): void {
    this.setToken(data.token);
    this.store.dispatch(addLoginInfo({ user: data }));
    this.toast.success('User Login Successfully');
  }

   handleError(error: any, defaultMessage: string): Observable<never> {
    const message = error.status === 0 ? 'Service is unavailable. Please try again later.' : error.error?.[0]?.description || error.error || defaultMessage;
    this.toast.danger(message);
    console.error(defaultMessage, error);
    throw error;
  }

  userIsLoggedIn(): boolean {
    return !!this.getToken();
  }

   getToken(): string | null {
    return this.cookieService.get(environment.Token);
  }

   setToken(token: string): void {
    this.cookieService.set(environment.Token, token);
    this.loggedIn.next(true);
    this.router.navigate(['home']);
  }

  logoutUser(): void {
    this.cookieService.delete(environment.Token);
    this.store.dispatch(removeLoginInfo());
    this.loggedIn.next(false);
    this.router.navigate(['login']);
    this.toast.warning('User Logged Out Successfully');
  }
}

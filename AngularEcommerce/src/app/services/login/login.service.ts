import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginResponse } from '../../components/types/login';
import { environment } from '../../../environments/environment.development';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
import { Register } from '../../components/types/register';
import { Store } from '@ngrx/store';
import { addLoginInfo } from '../../states/user/user.action';

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
    private router:Router,
    private store:Store
  ) {
    // Initialize login status based on existing token
    this.loggedIn.next(this.userIsLoggedIn());
  }

  login(credentials: any) {
    this.http.post<LoginResponse>(environment.loginURl + "login", credentials).subscribe(
      (data)=>{
        // console.log(data);
        // this.toast.danger('Wrong Email and Password');
        this.setToken(data.token);
        // var user:LoginResponse;
        // user.email=data.email;
        this.store.dispatch(addLoginInfo({user:data}))
      },
      
      (err) =>{
        if (err.status === 0) {
          // Handle network error (service is down or unreachable)
          console.log("Service is unavailable.");
          this.toast.danger('Service is unavailable. Please try again later.');
        }
        else{
        console.log("Authentication Failed ",err.error);
        this.toast.danger(' '+err.error);
        }
      }
    );
  }

  register(credentials: any){
    return this.http.post<Register>(environment.loginURl + "login/register", credentials).subscribe(
      (data)=>{
        // console.log(data);
        // this.toast.danger('Wrong Email and Password');
        this.setToken(data.token);
        // var user:LoginResponse;
        // user.email=data.email;
        this.store.dispatch(addLoginInfo({user:data}))
      },
      
      (err) =>{
        if (err.status === 0) {
          // Handle network error (service is down or unreachable)
          console.log("Service is unavailable.");
          this.toast.danger('Service is unavailable. Please try again later.');
        }
        else{
        console.log("Authentication Failed ",err.error);
        this.toast.danger('',err.error[0]?.description);
        }
      }
    );
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

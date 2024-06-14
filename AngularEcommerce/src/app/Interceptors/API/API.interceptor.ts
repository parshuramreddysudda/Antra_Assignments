import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { isPlatformBrowser } from '@angular/common';
import { environment } from '../../../environments/environment.development';
import { LoginService } from '../../services/login/login.service';

@Injectable()
export class APIInterceptor implements HttpInterceptor {
  constructor(
    @Inject(PLATFORM_ID) private platformId: any,
    private loginService: LoginService     
  ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log("Interceptor is called"); // Log to check if interceptor is called
    let token: string | null = null;
    
    if (isPlatformBrowser(this.platformId)) {
      token = localStorage.getItem(environment.Token) || this.loginService.getToken();
      console.log("Token in Interceptor (Browser): " + token);
    } else {
      token = this.loginService.getToken();
      console.log("Token in Interceptor (Server): " + token);
    }

    if (token) {
      const cloneRequest = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
      return next.handle(cloneRequest);
    }

    return next.handle(req);
  }
}

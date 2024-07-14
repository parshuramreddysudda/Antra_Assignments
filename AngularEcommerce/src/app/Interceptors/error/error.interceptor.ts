import { Inject, Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
import { RoutesEnums } from '../../components/types/Enums';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log("Errors ",error);
        
        if (error.status === 401) {
          // Redirect to login or any other page
          this.router.navigate(['/login']);
        }
        else if (error.status === 403) {
          // Redirect to login or any other page
          this.router.navigate([RoutesEnums.notAuthorized]);
        }
        else{
          this.router.navigate([RoutesEnums.serviceUnavailable])
        }
        return throwError((error));
      })
    );
  }
}

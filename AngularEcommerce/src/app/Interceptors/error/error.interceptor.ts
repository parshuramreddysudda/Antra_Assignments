import { Inject, Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NgToastService } from 'ng-angular-popup';

export const ErrorInterceptor: HttpInterceptor = {
    
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const toast = Inject(NgToastService)

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An unknown error occurred!';
        if (error.error instanceof ErrorEvent) {
          // A client-side or network error occurred
          errorMessage = `An error occurred: ${error.error.message}`;
          toast.error(errorMessage);
        } else {
          // The backend returned an unsuccessful response code
          errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
          toast.error(errorMessage);
        }
        console.error(errorMessage);
        return throwError(() => new Error(errorMessage));
      })
    );
  }
};

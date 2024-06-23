import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { provideClientHydration } from '@angular/platform-browser';
import { routes } from './app.routes';
import { APIInterceptor } from './Interceptors/API/API.interceptor';
import { ErrorInterceptor } from './Interceptors/error/error.interceptor';
import { provideState, provideStore } from '@ngrx/store';
import { loginReducer } from './states/user/user.reducer';
import { provideStoreDevtools, StoreDevtools, StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment.development';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideClientHydration(),
    provideHttpClient(withInterceptorsFromDi()),
    provideAnimations(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: APIInterceptor,
      multi: true
    },
    provideStore(),
    provideStoreDevtools({
      maxAge:25,
      features:{
        persist:true,
      }
    }),
    provideState({name:"user",reducer:loginReducer})
  ]
};

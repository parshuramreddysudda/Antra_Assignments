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
import { provideStoreDevtools, StoreDevtools, StoreDevtoolsModule } from '@ngrx/store-devtools';
import { hydrationMetaReducer } from './states/Hydration/hyderation.reducer';
import { appStoreConfig } from './states/app.state';
import { EffectsModule, provideEffects } from '@ngrx/effects';
import { AuthEffects } from './services/Helper/auth.effects';

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
      maxAge:2500,
      features:{
        persist:true,
      }
    }),
    provideEffects([AuthEffects]),
    provideStore(appStoreConfig.reducers, {
      // metaReducers: appStoreConfig.metaReducers
    }),
  ]
};
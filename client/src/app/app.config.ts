import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { routes } from './app.routes';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { jwtInterceptor } from './_interceptors/jwt.interceptor';
import { authGuard } from './_guards/auth.guard';
import { ToastrModule, provideToastr } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { loadingInterceptor } from './_interceptors/loading.interceptor';
import { errorInterceptor } from './_interceptors/error.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideAnimations(),
    provideRouter(routes),
    importProvidersFrom(
      HttpClientModule,
      BsDropdownModule.forRoot(),
      NgxSpinnerModule.forRoot({
        type:'ball-clip-rotate'
      })),
    provideToastr({positionClass: 'toast-bottom-right'} ),
    provideHttpClient(withInterceptors([jwtInterceptor,loadingInterceptor,errorInterceptor])),
    
  ]
};

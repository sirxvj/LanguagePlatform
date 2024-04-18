import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { routes } from './app.routes';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { jwtInterceptor } from './_interceptors/jwt.interceptor';
import { authGuard } from './_guards/auth.guard';
import { ToastrModule, provideToastr } from 'ngx-toastr';

export const appConfig: ApplicationConfig = {
  providers: [
    provideAnimations(),
    provideRouter(routes),
    importProvidersFrom(HttpClientModule,BsDropdownModule.forRoot()),
    provideToastr({positionClass: 'toast-bottom-right'} ),
    provideHttpClient(withInterceptors([jwtInterceptor])),
    
  ]
};

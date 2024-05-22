import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError, of, throwError } from 'rxjs';
import { AccountService } from '../_services/account.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router)
  const toastr = inject(ToastrService)
  const accountService = inject(AccountService)
  return next(req).pipe(
    catchError(error=>{
      if(error){
        switch(error.status){
          case 400:
            if(error.error.errors){
                const modalStateErrors = []
                for (const key in error.error.errors){
                  if(error.error.errors[key]){
                    modalStateErrors.push(error.error.errors[key])
                  }
                }
                throw modalStateErrors.flat() 
            }else{
            toastr.error("BadRequest",error.status)
            } 
            break;
          
            case 401:
              accountService.currentUser$ = of(null)
              localStorage.removeItem('user')
              router.navigateByUrl('/')
              toastr.error("Unauthorized",error.status)
              break;
            case 404:
              router.navigateByUrl('/not-found')
              break;
            case 500:
              const extras : NavigationExtras = {state:{error:error.error}}
              router.navigateByUrl('/server-error',extras)
              break;
        default:
            toastr.error("Something unexpected goes wrong",error.status)
          break;
        }
      }
      return throwError(()=>error)
    }))
};

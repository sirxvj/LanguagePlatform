import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { map, take } from 'rxjs';

export const authGuard: CanActivateFn = () => {
  const accountService = inject(AccountService)

  return accountService.currentUser$.pipe(
    map(user=>{
      if(user) return true
      return false
    })
  );
};

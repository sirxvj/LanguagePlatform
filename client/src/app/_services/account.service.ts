import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators'

import { Observable, ReplaySubject } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { User } from '../_models/User';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.BASE_URL_HTTP+'/api/';

  private currentUserSource = new ReplaySubject<User | null>(1);
 
  currentUser$ = this.currentUserSource.asObservable()


  constructor(private http:HttpClient) { }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((response: any) => {
        const result: User = response as User; // Explicitly cast the response to User type
        if (result) {
          localStorage.setItem('user', JSON.stringify(result));
          this.currentUserSource.next(result);
        }
      })
    );
  }

  login(model:any){
    return this.http.post(this.baseUrl+'account/login',model).pipe(
      map((response:any)=>{
        const user = response as User
        if(user){
          localStorage.setItem('user',JSON.stringify(user))
          this.currentUserSource.next(user)
        }
      })
    );
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user)
  }

  logout(){
    localStorage.removeItem('user')
    this.currentUserSource.next(null)
  }
}

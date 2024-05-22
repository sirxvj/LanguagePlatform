import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { UserFrom } from '../_models/UserForm';
import { Observable } from 'rxjs';
import { UserFromUser } from '../_models/UserFormUser';

@Injectable({
  providedIn: 'root'
})
export class CommunityService {
  baseUrl = environment.BASE_URL_HTTP+'/api/community/';
  constructor(private http:HttpClient) { }

  getUsersUserForm(id:string){
    return this.http.get(this.baseUrl + 'userform/'+id)
  }
  getUserFormsFilter(lang: string|undefined,cat: string|undefined):Observable<UserFromUser[]>{
    return this.http.get(this.baseUrl + 'userform/?' + (cat!==undefined?'catId='+cat:'') +
    '&&'+ (lang!==undefined?'langId='+lang:'') )as Observable<UserFromUser[]>
  }
  updateUserForm(userForm:UserFrom){
    return this.http.put(this.baseUrl + 'userform',userForm)
  }

  getUsersFriends(id:string){
    return this.http.get(this.baseUrl+id+'/friends')
  }
  makeFriends(userId:string,friendId:string){
    return this.http.post(this.baseUrl + 'friends',{
      userId:userId,
      user2Id:friendId
    })
  }
}

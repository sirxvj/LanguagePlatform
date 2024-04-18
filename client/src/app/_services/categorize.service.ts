import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CategorizeService {

  baseUrl = environment.BASE_URL_HTTP+'/api/';

  constructor(private http:HttpClient) { }

  getCategories(){
    return this.http.get(this.baseUrl+'categories')
  }

  getLangs(){
    return this.http.get(this.baseUrl+'categories/lang')
  }

}

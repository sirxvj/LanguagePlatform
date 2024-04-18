import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  baseUrl = environment.BASE_URL_HTTP+'/api/';

  constructor(private http:HttpClient) { }

  getAllRaw(){
    return this.http.get(this.baseUrl+'articles')
  }
}

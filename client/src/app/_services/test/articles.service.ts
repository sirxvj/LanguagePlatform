import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Article } from '../../_models/Article';
import { CreateArticle } from '../../_models/CreateArticle';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  baseUrl = environment.BASE_URL_HTTP+'/api/';

  constructor(private http:HttpClient) { }

  getAllRaw(){
    return this.http.get(this.baseUrl+'articles')
  }

  getDetailed(id:string){
    return this.http.get(this.baseUrl+'articles/'+id)
  }
  postArticle(article:CreateArticle){
    return this.http.post(this.baseUrl+'articles',article)
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class LessonsService {
  baseUrl = environment.BASE_URL_HTTP+'/api/';

  constructor(private http:HttpClient) { }

  getAllUnaprooved(){
    
  }

  getReviews(id:string){
    return this.http.get(this.baseUrl+'lessons/'+id+'/reviews')
  }
  postReview( review:any){
    return this.http.post(this.baseUrl+'lessons/'+review.LessonId+'/reviews',review)
  }
}

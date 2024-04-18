import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import {Cringe} from '../../_models/Cringe';

@Injectable({
  providedIn: 'root'
})
export class TestsService {
  baseUrl = environment.BASE_URL_HTTP+'/api/';

  constructor(private http:HttpClient) { }

  getAllRaw(){
    return this.http.get(this.baseUrl+'')
  }
  postCringe(cringe:Cringe){
    return this.http.post(this.baseUrl+'tests',cringe)
  }
}

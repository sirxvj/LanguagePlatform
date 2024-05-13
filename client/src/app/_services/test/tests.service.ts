import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import {Cringe} from '../../_models/Cringe';
import { CreateTest } from '../../_models/tests/CreateTest';

@Injectable({
  providedIn: 'root'
})
export class TestsService {
  baseUrl = environment.BASE_URL_HTTP+'/api/';

  constructor(private http:HttpClient) { }

  getAllRaw(){
    return this.http.get(this.baseUrl+'tests')
  }
  getDetailed(id:string){
    return this.http.get(this.baseUrl+'tests/'+id)
  }
  checkAccuracy(id:string){
    return this.http.get(this.baseUrl + 'tests/answers/'+id+'/accuracy')
  }
  postTest(test:CreateTest){
    return this.http.post(this.baseUrl+'tests',test)
  }
}

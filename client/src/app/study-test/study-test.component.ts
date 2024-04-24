import { Component, OnInit } from '@angular/core';
import { TestsService } from '../_services/test/tests.service';
import { Cringe } from '../_models/Cringe';

@Component({
  selector: 'app-study-test',
  standalone: true,
  imports: [],
  templateUrl: './study-test.component.html',
  styleUrl: './study-test.component.css'
})
export class StudyTestComponent implements OnInit {
  
  cringe: Cringe = {
    title: new ArrayBuffer(3)
  }
  constructor(private testService:TestsService){
    
  } 
 

  ngOnInit(): void {
    this.testService.postCringe(this.cringe).subscribe(
        resp=>{
          console.log(resp)
        }

    )
  }
}

import { Component, OnInit } from '@angular/core';
import { TestsService } from '../../_services/test/tests.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Test } from '../../_models/tests/Test';
import { ImageService } from '../../_services/image.service';
import { CommonModule } from '@angular/common';
import { TestQuestionComponent } from "./test-question/test-question.component";

@Component({
    selector: 'app-test-detailed',
    standalone: true,
    templateUrl: './test-detailed.component.html',
    styleUrl: './test-detailed.component.css',
    imports: [CommonModule, TestQuestionComponent]
})
export class TestDetailedComponent implements OnInit {

  test:Test | undefined
  imgUrl = ''
  startTest = false

  constructor(private testService:TestsService,
    private router:ActivatedRoute,
    private imageService:ImageService
  ){}
  ngOnInit(): void {
    this.testService.getDetailed(this.router.snapshot.paramMap.get('id')??'').subscribe(
      res=>{
        this.test = res
        console.log(this.test)
        this.imageService.getImage(this.test.lesson?.media).then(x=>{
          console.log(x)
          if(x!=='')
            
            this.imgUrl = x;
        })
      }
    )
    if(this.test){
    console.log(this.test)
  }
  }

  


}

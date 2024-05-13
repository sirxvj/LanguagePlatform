import { Component, Input, OnInit } from '@angular/core';
import { Test } from '../../../_models/tests/Test';
import { Question } from '../../../_models/tests/Question';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ImageService } from '../../../_services/image.service';
import { TestsService } from '../../../_services/test/tests.service';
import { ToastrService } from 'ngx-toastr';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-test-question',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './test-question.component.html',
  styleUrl: './test-question.component.css'
})
export class TestQuestionComponent implements OnInit{

  @Input() test :Test|undefined
  currentQuestion : Question|undefined
  index=0
  correctCounter=0
  imgUrl=''
  constructor(private imageService:ImageService,
    private testService:TestsService,
    private toastr:ToastrService
  ){}
  ngOnInit(): void {
    this.currentQuestion = this.test?.questions[0]
    this.imageService.getImage(this.currentQuestion?.media).then(res=>{
      this.imgUrl = res
    })
    console.log(this.currentQuestion)
  }
  checkAnswer(id: string){
    this.testService.checkAccuracy(id).subscribe(res=>{
      if(res){ 
        this.toastr.success('Correct')
        this.correctCounter++
      }
        else this.toastr.error('Wrong')
      this.currentQuestion = this.test?.questions[++this.index]
      if(this.currentQuestion===undefined){
        this.index=-1
      }
    })
  }
}

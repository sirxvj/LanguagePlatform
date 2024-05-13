import { Component } from '@angular/core';
import { CategorizeService } from '../../_services/categorize.service';
import { Category } from '../../_models/lesson/Category';
import { Language } from '../../_models/lesson/Language';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreateLessonComponent } from "../create-lesson/create-lesson.component";
import { CreateLesson } from '../../_models/lesson/CreateLesson';
import { Question } from '../../_models/tests/Question';
import { Answer } from '../../_models/tests/Answer';
import { CreateAnswer } from '../../_models/tests/CreateAnswer';
import { CreateQuestion } from '../../_models/tests/CreateQuestion';
import { CreateTest } from '../../_models/tests/CreateTest';
import { TestsService } from '../../_services/test/tests.service';
import { ToastrService } from 'ngx-toastr';
import { Media } from '../../_models/lesson/Media';
import { ImageService } from '../../_services/image.service';

@Component({
    selector: 'app-create-test',
    standalone: true,
    templateUrl: './create-test.component.html',
    styleUrl: './create-test.component.css',
    imports: [CommonModule, FormsModule, CreateLessonComponent]
})
export class CreateTestComponent {



  
  lesson:CreateLesson = {
    title: '',
    media: undefined,
    creatorId: '',
    categoryId:'',
    languageId: ''
  }
  description = ''
  questions:CreateQuestion[] = []

  constructor(private categoryService:CategorizeService,
    private testService:TestsService,
    private toastr:ToastrService,
    private imgService:ImageService
  ){}

  addQuestion(){
    this.questions.push({
      title: '',
      description: '',
      media: undefined,
      answers: []
    })
  }
  addAnswer(target:CreateAnswer[]){
    target.push({
      answerBody: '',
      accuracy:false
    })
  }
  postTest(){
    const test: CreateTest={
      description: this.description,
      lesson: this.lesson,
      questions: this.questions
    } 
    this.testService.postTest(test).subscribe(res=>{
      this.toastr.success('Test published','OK')
    },err=>{
      this.toastr.error(err.error.error,'Error')
    })
  }
  deleteQuestion(index:number){
    this.questions.splice(index,1)
  }
  deleteAnswer(question:CreateQuestion,index:number){

  }
  uploadFile($event: any,target: any) {
  
    const file:File = $event?.target?.files[0]
        let media:Media = {   
          bytes: undefined,
          FileType: '',
          FileName: ''
        }
        if(file){
          file.arrayBuffer().then(res=>{
            this.imgService.arrayBufferToBase64String(res).then(res=>
              media.bytes = res
            )
          })
          
          media.FileName = file.name
          media.FileType = file.type
        }
        target.media = media
  }
}

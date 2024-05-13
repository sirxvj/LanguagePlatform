import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../../_models/lesson/Category';
import { Language } from '../../_models/lesson/Language';
import { CategorizeService } from '../../_services/categorize.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Lesson } from '../../_models/lesson/Lesson';
import { CreateLesson } from '../../_models/lesson/CreateLesson';
import { Media } from '../../_models/lesson/Media';
import { ArticlesService } from '../../_services/test/articles.service';
import { AccountService } from '../../_services/account.service';
import { take } from 'rxjs';
import { ImageService } from '../../_services/image.service';

@Component({
  selector: 'app-create-lesson',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './create-lesson.component.html',
  styleUrl: './create-lesson.component.css'
})
export class CreateLessonComponent implements OnInit{
  
  @Input() lesson:CreateLesson = {
    title: '',
    media: undefined,
    creatorId: '',
    categoryId: '',
    languageId: ''
  }
  @Input() greetingString = ''  
  langs:Language[] = []
  categories:Category[] = []
  
  language = ""
  category = ""
  constructor(private categoryService:CategorizeService,
    private accountService:AccountService,
    private imageService:ImageService
  ){}
  ngOnInit(): void {
    this.accountService.currentUser$.pipe(take(1)).subscribe(resp=>{
      this.lesson.creatorId = resp?.id ?? ""
    })
    this.getParams()
  }
  getParams(){
    this.categoryService.getLangs().subscribe(resp=>{
      this.langs = resp as Language[]
      this.lesson.languageId = this.langs[0].id
  })  
  this.categoryService.getCategories().subscribe(
    resp=>{
      this.categories = resp as Category[]
      this.lesson.categoryId = this.categories[0].id
    }
  )
  }
  changeLangSelector(value:string){
    this.langs.forEach(element => {
        if(element.name==value && this.lesson!==undefined)
          this.lesson.languageId = element.id
    });
  }
  changeCategorySelector(value:string){
    this.categories.forEach(element => {
        if(element.name==value && this.lesson !== undefined)
          this.lesson.categoryId = element.id
    });
  }
  uploadFile(event : any,target:any){
    const file:File = event.target.files[0]
    let media:Media = {   
      bytes: undefined,
      FileType: '',
      FileName: ''
    }
    if(file){
      file.arrayBuffer().then(res=>{
        media.bytes = this.imageService.arrayBufferToBase64String(res)
      })
      
      media.FileName = file.name
      media.FileType = file.type
    }
    target.media = media
}
  
}

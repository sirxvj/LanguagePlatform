import { Component, OnInit } from '@angular/core';
import { CategorizeService } from '../../_services/categorize.service';
import { Language } from '../../_models/Language';
import { Category } from '../../_models/Category';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Section } from '../../_models/Section';
import { FormsModule } from '@angular/forms';
import { Lesson } from '../../_models/Lesson';
import { Media } from '../../_models/Media';
import { ArticlesService } from '../../_services/test/articles.service';
import { Article } from '../../_models/Article';
import { ImageService } from '../../_services/image.service';
import { CreateArticle } from '../../_models/CreateArticle';
import { CreateLesson } from '../../_models/CreateLesson';
import { AccountService } from '../../_services/account.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-create-article',
  standalone: true,
  imports: [CommonModule,BsDropdownModule,FormsModule],
  templateUrl: './create-article.component.html',
  styleUrl: './create-article.component.css'
})
export class CreateArticleComponent implements OnInit {

  langs:Language[] = []
  categories:Category[] = []

  sections:Section[] = [{
    order: 0,
    title: '',
    rawText: '',
    mediaTopic: undefined
  }]
  lesson:CreateLesson = {
    title: '',
    media: undefined,
    creatorId: '',
    categoryId: '',
    languageId: ''
  }
  constructor(private categoryService:CategorizeService,
    private articleService:ArticlesService,
    public imageService:ImageService,
    private accountService:AccountService
  ){}
  
  ngOnInit(): void {
    this.lesson.categoryId = 'Difficulty'
    this.accountService.currentUser$.pipe(take(1)).subscribe(resp=>{
      this.lesson.creatorId = resp?.id ?? ""
    })
    this.getParams()
  }
  getParams(){
    this.categoryService.getLangs().subscribe(resp=>{
      this.langs = resp as Language[]
  })  
  this.categoryService.getCategories().subscribe(
    resp=>{
      this.categories = resp as Category[]
    }
  )
  }
  addSection(){
    this.sections.push({
      order: 0,
      title: '',
      rawText: '',
      mediaTopic: undefined
    })
  }
  deleteSection(index:number){
    this.sections.splice(index,1)
  }
  uploadFile(event : any,target:any){
    console.log("asddas")
      const file:File = event.target.files[0]
      let media:Media = {   
        Bytes: undefined,
        FileType: '',
        FileName: ''
      }
      if(file){
        // file.arrayBuffer().then(res=>{
        //   media.Bytes = res
        // })
         file.stream().getReader().read().then(RES=>{
          media.Bytes = Array.from(RES.value??new Uint8Array)
         })
        media.FileName = file.name
        media.FileType = file.type
      }
      this.lesson.media = media
  }
  postArticle(){
    const article:CreateArticle = {
      lesson: this.lesson,
      sections: this.sections
    }
    console.log(article)
    this.articleService.postArticle(article).subscribe(
      resp=>{
        console.log(resp)
      }
    )
    
  }
}

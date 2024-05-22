import { Component, Input } from '@angular/core';
import { ImageService } from '../../_services/image.service';
import { Lesson } from '../../_models/Lesson';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AccountService } from '../../_services/account.service';
import { LessonsService } from '../../_services/test/lessons.service';

@Component({
  selector: 'app-unapproved-article-card',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './unapproved-article-card.component.html',
  styleUrl: './unapproved-article-card.component.css'
})
export class UnapprovedArticleCardComponent {
  @Input() lesson : Lesson | undefined;
  @Input() filter:any | undefined;

  imgUrl : any = {}
  approveButon = false
  constructor(public imageService:ImageService,
    private accountService:AccountService,
    private lessonService:LessonsService
  ){
  }
  ngOnInit(): void {
    this.imageService.getImage(this.lesson?.media).then(x=>{
      this.imgUrl = x;
    })
    this.approveButon = this.accountService.isAdmin()
  }
  getDate(){

    if(this.lesson!==undefined){
      const date_Object : Date = new Date(Date.parse(this.lesson?.createdAt))
      var date_String = date_Object.getHours() +
      ":" +
      +date_Object.getMinutes()+" "+
      date_Object.getDate() +
         "/" +
         (date_Object.getMonth() + 1) +
         "/" +
         +date_Object.getFullYear();
      return date_String;
    }
    return undefined
   
  }
  checkFilter(){
    
    if(!this.filter || this.filter.bar === undefined ) return true 

    return this.lesson?.title.toLowerCase().includes(this.filter.bar.toLowerCase()) ||
       this.lesson?.creator.username.toLowerCase().includes(this.filter.bar.toLowerCase())
  }

  approve(){
    this.lessonService.approve(this.lesson?.id??'')
  }
}

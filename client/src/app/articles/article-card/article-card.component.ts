import { Component, Input, OnInit } from '@angular/core';
import { Lesson } from '../../_models/Lesson';
import { RouterLink } from '@angular/router';
import { ImageService } from '../../_services/image.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-article-card',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './article-card.component.html',
  styleUrl: './article-card.component.css'
})
export class ArticleCardComponent implements OnInit {
  @Input() lesson : Lesson | undefined;
  @Input() filter:any | undefined;

  imgUrl : any = {}
  
  constructor(public imageService:ImageService){
  }
  ngOnInit(): void {
    this.imageService.getImage(this.lesson?.media).then(x=>{
      this.imgUrl = x;
    })
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
}

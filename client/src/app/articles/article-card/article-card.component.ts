import { Component, Input } from '@angular/core';
import { Lesson } from '../../_models/Lesson';
import { RouterLink } from '@angular/router';
import { ImageService } from '../../_services/image.service';

@Component({
  selector: 'app-article-card',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './article-card.component.html',
  styleUrl: './article-card.component.css'
})
export class ArticleCardComponent {
  @Input() lesson : Lesson | undefined;

  constructor(public imageService:ImageService){}
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
}

import { Component, Input } from '@angular/core';
import { Review } from '../../../_models/Review';

@Component({
  selector: 'app-comment',
  standalone: true,
  imports: [],
  templateUrl: './comment.component.html',
  styleUrl: './comment.component.css'
})
export class CommentComponent {
  @Input() review: Review | undefined
  getDate(){

    if(this.review!==undefined){
      const date_Object : Date = new Date(Date.parse(this.review?.createdAt))
      return date_Object.toUTCString()
    }
    return undefined
   
  }
}

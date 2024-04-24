import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ArticlesService } from '../_services/test/articles.service';
import { Lesson } from '../_models/Lesson';
import { Observable, map } from 'rxjs';
import { ArticleCardComponent } from "../articles/article-card/article-card.component";

@Component({
    selector: 'app-teach',
    standalone: true,
    templateUrl: './teach.component.html',
    styleUrl: './teach.component.css',
    imports: [BsDropdownModule, CommonModule, RouterLink, ArticleCardComponent]
})
export class TeachComponent implements OnInit{


  lessons: Observable<Lesson[]> | undefined

  constructor(private articleService:ArticlesService){}

  ngOnInit(): void {
    this.lessons = this.articleService.getAllUnaprooved().pipe(
      map(
        res=>{
          return res as Lesson[]
        }
      )

    )
  }


}

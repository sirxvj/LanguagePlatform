import { Component, OnInit } from '@angular/core';
import { ArticlesService } from '../_services/test/articles.service';
import { Lesson } from '../_models/Lesson';
import { CommonModule } from '@angular/common';
import { ArticleCardComponent } from "./article-card/article-card.component";
import { ImageService } from '../_services/image.service';

@Component({
    selector: 'app-articles',
    standalone: true,
    templateUrl: './articles.component.html',
    styleUrl: './articles.component.css',
    imports: [CommonModule, ArticleCardComponent]
})
export class ArticlesComponent implements OnInit {

    stuff:Lesson[] = []

    constructor(public articlesService:ArticlesService
    ){}

  ngOnInit(): void {
  
    this.articlesService.getAllRaw().subscribe(
      resp=>{
        this.stuff = resp as Lesson[]
        console.log(this.stuff)
      }
      
    )
  }


}

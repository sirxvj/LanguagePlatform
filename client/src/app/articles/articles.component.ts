import { Component, OnInit } from '@angular/core';
import { ArticlesService } from '../_services/test/articles.service';
import { Lesson } from '../_models/Lesson';
import { CommonModule } from '@angular/common';
import { ArticleCardComponent } from "./article-card/article-card.component";
import { ImageService } from '../_services/image.service';
import { FormsModule } from '@angular/forms';
import { Observable, delay, map, shareReplay } from 'rxjs';
import { CategorizeService } from '../_services/categorize.service';
import { Category } from '../_models/Category';
import { Language } from '../_models/Language';

@Component({
    selector: 'app-articles',
    standalone: true,
    templateUrl: './articles.component.html',
    styleUrl: './articles.component.css',
    imports: [CommonModule, ArticleCardComponent,FormsModule]
})
export class ArticlesComponent implements OnInit {

    stuff:Observable<Lesson[]> | undefined
    empty = true
    filter:any = {}
    langs:Language[]= []
    categories: Observable<Category[]> | undefined
    languages: Observable<Language[]> | undefined
    
    constructor(public articlesService:ArticlesService,
      public categoryService:CategorizeService
    ){}

  ngOnInit(): void {
    this.stuff = this.articlesService.getAllRaw().pipe(
      map(
        res=>{
          return res as Lesson[]
        }),
        shareReplay(1)
    )
    
    this.stuff.subscribe(x=>{
      setTimeout(()=>{
        this.empty = false
      },1000)
     
    })
    this.categories = this.categoryService.getCategories().pipe(
      map(
        res=>{
          return res as Category[]
        }
      )
    )
    this.languages = this.categoryService.getLangs().pipe(
      map(
        res=>{
          return res as Language[]
        }
      )
    )
    this.languages.subscribe(
      x=>{
        this.langs = x
        console.log(this.langs)
      }
    )
  }
  

}

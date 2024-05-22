import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ArticlesService } from '../_services/test/articles.service';
import { Lesson } from '../_models/Lesson';
import { Observable, map } from 'rxjs';
import { ArticleCardComponent } from "../articles/article-card/article-card.component";
import { AccountService } from '../_services/account.service';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { UnapprovedArticleCardComponent } from "./unapproved-article-card/unapproved-article-card.component";
import { TestsService } from '../_services/test/tests.service';
import { UnapprovedTestCardComponent } from "./unapproved-test-card/unapproved-test-card.component";

@Component({
    selector: 'app-teach',
    standalone: true,
    templateUrl: './teach.component.html',
    styleUrl: './teach.component.css',
    imports: [BsDropdownModule, CommonModule, RouterLink, ArticleCardComponent, TabsModule, UnapprovedArticleCardComponent, UnapprovedTestCardComponent]
})
export class TeachComponent implements OnInit{

  isAdmin = false
  articles: Observable<Lesson[]> | undefined
  tests: Observable<Lesson[]> | undefined
  constructor(
    private articleService:ArticlesService,
    private testService:TestsService,
    public accountService:AccountService
  ){}

  ngOnInit(): void {
    this.articles = this.articleService.getAllUnaprooved() as Observable<Lesson[]>
    this.tests = this.testService.getAllUnaprooved() as Observable<Lesson[]>
    this.isAdmin = this.accountService.isAdmin()
  }



}

import { Component, OnInit } from '@angular/core';
import { TestsService } from '../_services/test/tests.service';
import { Cringe } from '../_models/Cringe';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Category } from '../_models/Category';
import { Language } from '../_models/Language';
import { CategorizeService } from '../_services/categorize.service';
import { FormsModule } from '@angular/forms';
import { Lesson } from '../_models/Lesson';
import { TestCardComponent } from "./test-card/test-card.component";

@Component({
    selector: 'app-study-test',
    standalone: true,
    templateUrl: './study-test.component.html',
    styleUrl: './study-test.component.css',
    imports: [CommonModule, FormsModule, TestCardComponent]
})
export class StudyTestComponent implements OnInit {
  
  showFilter = false
  filter:any = {}
  categories: Observable<Category[]> | undefined
  languages: Observable<Language[]> | undefined

  lessons : Observable<Lesson[]> | undefined

  constructor(private testService:TestsService,
    private categorizeService:CategorizeService
  ){} 
 
  ngOnInit(): void {
    this.categories = this.categorizeService.getCategories() as Observable<Category[]>
    this.languages = this.categorizeService.getLangs() as Observable<Language[]>
    this.lessons = this.testService.getAllRaw() as Observable<Lesson[]>
    this.lessons.subscribe(
      res=>{
        console.log(res)
      }
    )
  }
}

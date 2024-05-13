import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { Observable } from 'rxjs';
import { Language } from '../_models/Language';
import { Category } from '../_models/lesson/Category';
import { CategorizeService } from '../_services/categorize.service';

@Component({
  selector: 'app-community',
  standalone: true,
  imports: [TabsModule,CommonModule,FormsModule],
  templateUrl: './community.component.html',
  styleUrl: './community.component.css'
})
export class CommunityComponent implements OnInit {
 

  communityUser:any = {}

  languages:Observable<Language[]> | undefined
  categories:Observable<Category[]> | undefined

  constructor(private categorizeService:CategorizeService) {}
  ngOnInit(): void {
    this.languages = this.categorizeService.getLangs() as Observable<Language[]>
    this.categories = this.categorizeService.getCategories() as Observable<Category[]>
  }


  changeLangSelector(value:string){
    console.log(this.communityUser.language)
  }
  changeCategorySelector(value:string){
   
  }
}

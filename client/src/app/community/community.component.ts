import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { Observable, map } from 'rxjs';
import { Language } from '../_models/Language';
import { Category } from '../_models/lesson/Category';
import { CategorizeService } from '../_services/categorize.service';
import { UserFrom } from '../_models/UserForm';
import { User } from '../_models/User';
import { AccountService } from '../_services/account.service';
import { CommunityService } from '../_services/community.service';
import { ToastrService } from 'ngx-toastr';
import { UserformCardComponent } from "./userform-card/userform-card.component";
import { UserFromUser } from '../_models/UserFormUser';

@Component({
    selector: 'app-community',
    standalone: true,
    templateUrl: './community.component.html',
    styleUrl: './community.component.css',
    imports: [TabsModule, CommonModule, FormsModule, UserformCardComponent]
})
export class CommunityComponent implements OnInit {
 

  communityUser:UserFrom = {
    greeting: '',
    visible: false,
    userId:'',
    languageId: '',
    categoryId: ''
  };

  tabsSwitcher = false

  userForms: Observable<UserFromUser[]> | undefined
  languages:Observable<Language[]> | undefined
  categories:Observable<Category[]> | undefined

  constructor(private categorizeService:CategorizeService,
    private accountService:AccountService,
    private communityService:CommunityService,
    private toastr:ToastrService
  ) {}
  ngOnInit(): void {
    this.languages = this.categorizeService.getLangs() as Observable<Language[]>
    this.categories = this.categorizeService.getCategories() as Observable<Category[]>
     this.accountService.currentUser$.subscribe(res=>{
      this.communityUser.userId = res?.id ?? ''
      this.getUser(this.communityUser.userId)
      console.log('where is harry')
    })
    //CHNAGE!!!!!
    this.userForms = this.communityService.getUserFormsFilter(undefined,undefined).pipe(
      map(
        res=>res.filter(x=>x.userId!==this.communityUser.userId)
      )
    ) as Observable<UserFromUser[]>
  }

  getUser(id:string){
    this.communityService.getUsersUserForm(id).subscribe(res=>{
      if(res)
        this.communityUser = res as UserFrom
        console.log(this.communityUser)
    })
  }
  updateUser(){
    console.log(this.communityUser)
    this.communityService.updateUserForm(this.communityUser).subscribe(
      res=>{
        this.toastr.success('Form Updated','Ok')
      },err=>{
        this.toastr.error('Something went wrong','Error')
      }
    )
  }

  changeTab(sw:any){
    this.tabsSwitcher = true
  }
  
}

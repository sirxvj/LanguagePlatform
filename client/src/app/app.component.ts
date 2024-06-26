import { Component, OnInit, importProvidersFrom } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./navbar/navbar.component";
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { AccountService } from './_services/account.service';
import { User } from './_models/User';
import { HomeComponent } from './home/home.component';
import { BsDropdownModule,BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Toast, ToastrModule, ToastrService } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { RegisterComponent } from './home/register/register.component';


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [
      CommonModule,
      RouterOutlet, 
      NavbarComponent, 
      HomeComponent, 
      RegisterComponent,
      HttpClientModule,
      RouterModule,
      NgxSpinnerModule
      ],
    
})
export class AppComponent implements OnInit{
  
  title = 'LangGang';
  
  constructor(private accountService:AccountService,
    private router:Router,
  private toastr:ToastrService){}
  
  ngOnInit(): void {
    this.setCurrentUser()
  } 
  setCurrentUser(){
    const itemStorage = localStorage.getItem('user')
    if(itemStorage !== null){
      const user: User = JSON.parse(itemStorage) 
      this.accountService.setCurrentUser(user)
    }
    
    
  }
}

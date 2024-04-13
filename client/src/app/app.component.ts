import { Component, OnInit, importProvidersFrom } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./navbar/navbar.component";
import { RegisterComponent } from './register/register.component';
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { AccountService } from './_services/account.service';
import { User } from './_models/User';
import { HomeComponent } from './home/home.component';
import { BsDropdownModule,BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';


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
      RouterModule],
    
})
export class AppComponent implements OnInit{
  
  title = 'client';
  
  constructor(private accountService:AccountService,private router:Router){}
  
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

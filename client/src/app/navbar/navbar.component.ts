import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule,BsDropdownModule,RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(public accountService:AccountService,private router:Router){}

  logout(){
    this.accountService.logout()
    alert("logout")
    this.router.navigateByUrl('/')
  }

  
}

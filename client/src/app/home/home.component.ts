import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';

import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { User } from '../_models/User';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';


@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [NavbarComponent, RegisterComponent, CommonModule, FormsModule, LoginComponent]
})
export class HomeComponent implements OnInit {
    


    registerMode = SignMode.Info
    SignType = SignMode

    constructor(private accountService:AccountService,private router:Router){}
    async ngOnInit(): Promise<void> {
        const itemStorage = localStorage.getItem('user')
        if(itemStorage !== null){
            const user: User = JSON.parse(itemStorage) 
            this.accountService.setCurrentUser(user)
            this.router.navigateByUrl('tests')
        }
    }

    setToggle(mode : SignMode) {
        this.registerMode = mode
    }

}
enum SignMode{
    Info,
    Reg,
    Log
}

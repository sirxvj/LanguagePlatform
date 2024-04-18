import { Component, EventEmitter, Output } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { FormsModule }   from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';



@Component({
    selector: 'app-register',
    standalone: true,
    templateUrl: './register.component.html',
    styleUrl: './register.component.css',
    imports: [NavbarComponent,FormsModule]
})
export class RegisterComponent {
    @Output() cancelRegistration = new EventEmitter()
    model: any= {}
    
    constructor(private accountService:AccountService,private router:Router){}
    register() {
        this.accountService.register(this.model).subscribe(
            responce=>{
                this.router.navigateByUrl('/tests')
            }
        )
    }
    cancel() {
        this.cancelRegistration.emit()
    }

}

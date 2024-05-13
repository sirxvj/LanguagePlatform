import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../_services/account.service';
import { NavbarComponent } from '../../navbar/navbar.component';



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
    
    constructor(private accountService:AccountService,private router:Router,private toastr:ToastrService){}
    register() {
        this.accountService.register(this.model).subscribe(
            responce=>{
                this.toastr.success('OK','Registration Complete')
                this.router.navigateByUrl('/tests')
            },
            err=>{
                this.toastr.error('Error','Something went wrong')
            }
        )
    }
    cancel() {
        this.cancelRegistration.emit()
    }

}

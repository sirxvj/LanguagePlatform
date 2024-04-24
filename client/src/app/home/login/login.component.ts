import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  @Output() cancelRegistration = new EventEmitter()

  model: any ={}

  constructor(public accountService:AccountService,
    private router:Router,
    private toastr:ToastrService
  ){}
  cancel() {
      this.cancelRegistration.emit()
  }
  
login() {
  console.log(this.model)
  this.accountService.login(this.model).subscribe(responce=>{
    this.toastr.success('OK','Logged In')
    this.router.navigateByUrl('/tests')
  },error=>{
    this.toastr.error(error.error,'Error')
   
  })
}


}

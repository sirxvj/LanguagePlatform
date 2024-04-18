import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';

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

  constructor(public accountService:AccountService,private router:Router){}
  cancel() {
      this.cancelRegistration.emit()
  }
  
login() {
  console.log(this.model)
  this.accountService.login(this.model).subscribe(responce=>{
    this.router.navigateByUrl('/tests')
  },error=>{
    console.log(error)
   
  })
}


}

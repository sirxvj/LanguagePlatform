import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserFrom } from '../../_models/UserForm';
import { UserFromUser } from '../../_models/UserFormUser';

@Component({
  selector: 'app-userform-card',
  standalone: true,
  imports: [],
  templateUrl: './userform-card.component.html',
  styleUrl: './userform-card.component.css'
})
export class UserformCardComponent {
  @Input() form : UserFromUser | undefined
  @Output() sendMessageEvent = new EventEmitter()

  sendMesage(){
    this.sendMessageEvent.emit()
  }
}

import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-teach',
  standalone: true,
  imports: [BsDropdownModule,CommonModule,RouterLink],
  templateUrl: './teach.component.html',
  styleUrl: './teach.component.css'
})
export class TeachComponent {

}

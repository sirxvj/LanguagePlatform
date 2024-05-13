import { Component, Input, OnInit } from '@angular/core';
import { Lesson } from '../../_models/lesson/Lesson';
import { ImageService } from '../../_services/image.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-test-card',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './test-card.component.html',
  styleUrl: './test-card.component.css'
})
export class TestCardComponent implements OnInit{
  @Input() lesson:Lesson | undefined

  imgUrl = './../../../assets/img-placeholder.jpg'
  constructor(private imageService:ImageService){}
  ngOnInit(): void {
    this.imageService.getImage(this.lesson?.media).then(x=>{
      if(x!=='')
        console.log(x)
        this.imgUrl = x;
    })
  }
}

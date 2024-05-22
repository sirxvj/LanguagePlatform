import { Component, Input } from '@angular/core';
import { Lesson } from '../../_models/Lesson';
import { ImageService } from '../../_services/image.service';
import { RouterLink } from '@angular/router';
import { LessonsService } from '../../_services/test/lessons.service';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../_services/account.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-unapproved-test-card',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './unapproved-test-card.component.html',
  styleUrl: './unapproved-test-card.component.css'
})
export class UnapprovedTestCardComponent {
  @Input() lesson:Lesson | undefined
  
  apButton = false

  imgUrl = './../../../assets/img-placeholder.jpg'
  constructor(private imageService:ImageService,
    private lessonService:LessonsService,
    private accountService:AccountService,
    private toastr:ToastrService
  ){}
  ngOnInit(): void {
    this.imageService.getImage(this.lesson?.media).then(x=>{
      if(x!=='')
        console.log(x)
        this.imgUrl = x;
    })
    this.apButton = this.accountService.isAdmin()
  }

  approve(id:string){
    this.lessonService.approve(id).subscribe(res=>{
      this.toastr.success('Approved','OK')
    })
  }
}

import { Component, OnInit } from '@angular/core';
import { ArticlesService } from '../../_services/test/articles.service';
import { ActivatedRoute } from '@angular/router';
import { Article } from '../../_models/Article';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Review } from '../../_models/Review';
import { LessonsService } from '../../_services/test/lessons.service';
import { CommentComponent } from "./comment/comment.component";
import { AccountService } from '../../_services/account.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { Media } from '../../_models/Media';
import { ImageService } from '../../_services/image.service';
import { Section } from '../../_models/Section';

@Component({
    selector: 'app-article-details',
    standalone: true,
    templateUrl: './article-details.component.html',
    styleUrl: './article-details.component.css',
    imports: [CommonModule, FormsModule, CommentComponent,ToastrModule]
})
export class ArticleDetailsComponent implements OnInit{

  article : Article | undefined

  reviews : Review[] | undefined

  newReview : any = {}

  imgUrls : string[] = []

  prefabs = true

  constructor(private articlesService:ArticlesService,
    private lessonService:LessonsService,
    private router: ActivatedRoute,
    private accountService:AccountService,
    public imageService:ImageService,
    private toastr : ToastrService){}
  
  ngOnInit(): void {
    this.getDeatailed(this.router.snapshot.paramMap.get('id')??"")
  }

  getDeatailed(id:string){
    this.articlesService.getDetailed(id).subscribe(resp=>{
      this.article=resp as Article
       this.article.sections.forEach(sec=>{
        this.loadImg(sec,this.article?.sections.indexOf(sec)??0)
       })
       this.prefabs = false
    })
    this.lessonService.getReviews(id).subscribe(resp=>{
      this.reviews = resp as Review[]
    })
  }
  postReview(){
    this.newReview.LessonId = this.router.snapshot.paramMap.get('id')??""
    this.newReview.UserId = JSON.parse(localStorage.getItem('user')??"").id
    this.lessonService.postReview(this.newReview).subscribe(resp=>{
      this.toastr.success('Comment added')
      this.newReview = {}
      this.getDeatailed(this.router.snapshot.paramMap.get('id')??"")
    },
    err=>{
      console.log(err)
      this.toastr.error(err.error.message,'Error')
    })
  }
  loadImg(target:Section,index:number){
   
    this.imageService.getImage(target.media).then(x=> {
      
      this.imgUrls[index]=x
    }
    )
  }
}

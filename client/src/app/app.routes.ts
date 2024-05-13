import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { StudyTestComponent } from './study-test/study-test.component';
import { ArticlesComponent } from './articles/articles.component';
import { ArticleDetailsComponent } from './articles/article-details/article-details.component';
import { TeachComponent } from './teach/teach.component';
import { AboutComponent } from './about/about.component';
import { authGuard } from './_guards/auth.guard';
import { CreateArticleComponent } from './teach/create-article/create-article.component';
import { CreateTestComponent } from './teach/create-test/create-test.component';
import { TestDetailedComponent } from './study-test/test-detailed/test-detailed.component';
import { CommunityComponent } from './community/community.component';

export const routes: Routes = [
    {path:'',component:HomeComponent},
    {
        path:'',
        runGuardsAndResolvers:'always',
        canActivate:[authGuard],
        children:[
            {path:'tests',component:StudyTestComponent},
            {path:'tests/:id',component:TestDetailedComponent},
            {path:'articles',component:ArticlesComponent},
            {path:'articles/:id',component:ArticleDetailsComponent},
            {path:'community',component:CommunityComponent},
            {path:'teach',component:TeachComponent},
            {path:'teach/create-article',component:CreateArticleComponent},
            {path:'teach/create-test',component:CreateTestComponent},
            {path:'about',component:AboutComponent}
        ]
    }
    
];

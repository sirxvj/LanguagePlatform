import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { StudyTestComponent } from './study-test/study-test.component';
import { ArticlesComponent } from './articles/articles.component';

export const routes: Routes = [
    {path:'',component:HomeComponent},
    {path:'tests',component:StudyTestComponent},
    {path:'articles',component:ArticlesComponent}

];

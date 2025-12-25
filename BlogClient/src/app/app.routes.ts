import { Routes } from '@angular/router';
import { CategoryOperation } from './Components/category-operation/category-operation';
import { TagOperation } from './Components/tag-operation/tag-operation';
import { PostOperation } from './Components/post-operation/post-operation';

export const routes: Routes = [
    {path: '', component:CategoryOperation},
    {path: 'categories', component:CategoryOperation},
    {path: 'tags', component:TagOperation},
    {path: 'posts', component:PostOperation},
];

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { BlogCardComponent } from './components/blog-card/blog-card.component';
import { LoginComponent } from './components/login/login.component';
import { BlogCreateComponent } from './components/blog-create/blog-create.component';
import { BlogComponent } from './components/blog/blog.component';
import { BlogCommentComponent } from './components/blog-comment/blog-comment.component';
import { CommentBoxComponent } from './components/comment-box/comment-box.component';
import { AdminUsermanageComponent } from './components/admin/usermanagement/usermanagement.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent, RegistrationComponent, BlogCardComponent,
        LoginComponent, BlogCreateComponent, BlogComponent, BlogCommentComponent, CommentBoxComponent,
        AdminUsermanageComponent, AboutComponent, ContactComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule, ReactiveFormsModule,
        //RouterModule.forChild([
        //    { path: 'admin/users', component: AdminUsermanageComponent, canActivate: [AuthGuard, AdminAuthGuard] }]),

        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'registration', component: RegistrationComponent },
            { path: 'login', component: LoginComponent },
            { path: 'Blog/:id', component: BlogComponent },
            { path: 'create', component: BlogCreateComponent },
            { path: 'about', component: AboutComponent },
            { path: 'contact', component: ContactComponent },
            { path: 'admin/users', component: AdminUsermanageComponent },  
            { path: 'logout', component: HomeComponent }, 
            { path: '**', redirectTo: 'home' }
        ])
    ],
    exports: [HomeComponent, BlogCardComponent, BlogCommentComponent, CommentBoxComponent]
})
export class AppModuleShared {
}

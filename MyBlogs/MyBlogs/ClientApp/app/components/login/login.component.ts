import { Component, OnInit,Injectable } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'
import { Router, ActivatedRoute } from '@angular/router';
import { BlogUserService } from '../../services/bloguserservice.service'
import { AppGlobals } from '../../app.global';
import { AppUser } from '../../models/app-user';
import { userdetails } from '../../models/user-details';
import { Http, Headers, Response } from '@angular/http';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'], providers: [BlogUserService, AppGlobals]
})
export class LoginComponent implements OnInit {
    blogLoginForm: FormGroup;
    errorMessage: any;
    userManger: userdetails | null;
    failureMessagebool: boolean = true;
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _blogUserService: BlogUserService, private _globals: AppGlobals, private _router: Router) {
        this.userManger = null;
        this.blogLoginForm = this._fb.group({
        email: ['', [Validators.required]],
        password: ['', [Validators.required]]
    }) }

    ngOnInit() {
    }
    loginUser() {
        
        if (this.blogLoginForm.valid) {
            
          
            //alert(username);
            //this._blogUserService.getUserDetails(this.blogLoginForm.controls.email.value, this.blogLoginForm.controls.password.value,
            //    this._globals.baseAPIUrl + 'api/AdminUser/GetUserByID/').subscribe(
            //    data => this.userManger = data
            //)

            this._blogUserService.getUserDetails(btoa(this.blogLoginForm.controls.email.value), btoa(this.blogLoginForm.controls.password.value),
                this._globals.baseAPIUrl + 'api/AdminUser/GetUserByID/').then(
                data => this.userManger = data
            )
           
            
                
            if (this.userManger != null) {
                console.log(this.userManger.authToken);
                var authToken = this.userManger.authToken.split('|');
                var username = atob(authToken[0]);
                var password = atob(authToken[1]);
                //console.log(this.userManger.authToken);
                if (this.userManger.email == username && password == this.userManger.password) {

                    sessionStorage.setItem("Username", username);
                    sessionStorage.setItem("isAdmin", this.userManger.isadmin)
                    sessionStorage.setItem("UserID", this.userManger.id)
                    sessionStorage.setItem("authToken", this.userManger.authToken)
                    this._router.navigate(['/home']);
                }
                else {
                     //this.failureMessagebool = true;
                    this._router.navigate(['/login']); 
                }
            }
            else { console.log("Empty")}
        }
    }
}

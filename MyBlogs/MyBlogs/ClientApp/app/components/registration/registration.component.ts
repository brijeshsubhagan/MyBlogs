import { NgModule, OnInit } from '@angular/core'; 
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'; 
import { Router, ActivatedRoute } from '@angular/router'; 
import { BlogUserService } from '../../services/bloguserservice.service'; 
import { AppGlobals } from '../../app.global';

@NgModule({
    imports: [FormsModule, ReactiveFormsModule ]
})

@Component({
    selector: 'registration',
        templateUrl: './registration.component.html',
        providers: [BlogUserService, AppGlobals]
})
export class RegistrationComponent implements OnInit {
    blogUserForm: FormGroup;
    title: string = "Create";
 

    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,  
        private _blogUserService: BlogUserService, private _router: Router, private _global: AppGlobals) {
   
        if (this._avRoute.snapshot.params["id"]) {
    
           // this.id = this._avRoute.snapshot.params["id"];
            }
        this.blogUserForm = this._fb.group({
            name: ['', [Validators.required]],
            password: ['', [Validators.required]],
            email: ['', [Validators.email]]
      })
   }
    ngOnInit() {
     }

    resetForm(form?: NgForm) {
        if (form != null)
            form.reset();

    }

    get primaryEmail() {
        return this.blogUserForm.get('email');
    } 

    saveUser() {
        var string1 = JSON.stringify(this.blogUserForm.value);
       
        if (this.blogUserForm.valid) {
            this._blogUserService.saveblogUser(this.blogUserForm.value, this._global.baseAPIUrl + 'api/BlogUsers')
                .subscribe((data) => {
                    this._router.navigate(['/home']);




                }, error => this.errorMessage = error)
        }
    }
  

   
}

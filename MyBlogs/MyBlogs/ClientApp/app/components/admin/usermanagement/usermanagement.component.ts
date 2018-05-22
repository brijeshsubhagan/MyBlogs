import { NgModule } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { AppUser } from '../../../models/app-user';
import { AdminService } from '../../../services/adminservice.service'
import { BlogUserService } from '../../../services/bloguserservice.service'
import { AppGlobals } from '../../../app.global';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { LowerCasePipe } from '@angular/common';
@NgModule({
    imports: [FormsModule]
})
@Component({
    selector: 'app-usermanage',
    templateUrl: './usermanagement.component.html',
    styleUrls: ['./usermanagement.component.css'],
    providers: [AdminService, BlogUserService, AppGlobals]
})
export class AdminUsermanageComponent implements OnInit {
    userManger: AppUser[] | null;
    errorMessage: any;
    constructor(private _adminService: AdminService, private _globals: AppGlobals,
        private _blogUserService: BlogUserService, private _router: Router) {
        this.userManger = null;
    }

    ngOnInit() {
        this.getAllUsers();
    }

    getAllUsers() {

        this._adminService.getAllUsers(this._globals.baseAPIUrl + 'api/AdminUser/GetPosts').subscribe(
            data => this.userManger = data
        );

    }
    grantAdmin(userID) {
        this._blogUserService.updateAdminUserById(userID, this._globals.baseAPIUrl + "api/AdminUser/GetUserByID/")
            .subscribe((data) => {
                this.getAllUsers();
                this._router.navigate(['/admin/users']);
            }, error => this.errorMessage = error)
    }
    getButtonState(admin) {
        if (admin == "false")
            return "enableBtn";
        else
            return "disableBtn";
    }
    getCheckState(admin) {
        if (admin == "false")
            return "false";
        else
            return "false";
    }
    getButtonText(admin) {
        if (admin == "false")
            return "Grant";
        else
            return "Revoke";
    }
    deleteUser(userID) {
        /*  var string1 = JSON.stringify(this.blogCreateForm.value);
          alert(string1);*/
        var ans = confirm("Do you want to delete this user ");
        if (ans) {

            this._blogUserService.deleteUserById(userID, this._globals.baseAPIUrl + "api/BlogUsers/DeletetbBlogUser/")
                .subscribe((data) => {
                    this.getAllUsers();
                    this._router.navigate(['/admin/users']);
                }, error => this.errorMessage = error)
        }
    }

    // checked() { alert("") }


}

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit{
    showAdmin: boolean = false;
    showLogin: boolean = true;
    constructor(private _router: Router) { }
    
    ngOnInit() {
      
        let userID = sessionStorage.getItem("UserID");
        let userName = sessionStorage.getItem("Username");
        let isAdmin = sessionStorage.getItem("isAdmin");
        if (isAdmin)
            this.showAdmin = true;

       // let authToken = sessionStorage.getItem("authToken");
        this.showLogin = false;
        // alert(myItem);
    }

    updatesessions()
    {
        //sessionStorage.clear();
        //this._router.navigate(['/home']);
    }
}

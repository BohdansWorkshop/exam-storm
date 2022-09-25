import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from '../../models/UserModel';
import { AccountService } from '../../services/account.service';

@Component({
    selector: 'app-user-profile',
    templateUrl: './user-profile.component.html',
    styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

    currentUser: UserModel;
    constructor(private router: Router, private accountService: AccountService) { }

    ngOnInit() {
        const currentUserRawModel = localStorage.getItem("currentUser");
        if (!currentUserRawModel)
        {
            this.router.navigate(['']);
        }
        this.currentUser = JSON.parse(currentUserRawModel) as UserModel;
    }

    logout() {
        this.accountService.logout().subscribe(
            () => {
                localStorage.removeItem("jwtToken");
                localStorage.removeItem("refreshJwtToken");
                localStorage.removeItem("currentUser");
                this.router.navigate(['']);
            },
            (err: any) => {
                console.log(err);
            });
    }

}

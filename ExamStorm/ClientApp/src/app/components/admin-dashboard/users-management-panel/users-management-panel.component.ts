import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../../models/UserModel';
import { UserService } from '../../../services/user.service';

@Component({
    selector: 'users-management-panel',
    templateUrl: './users-management-panel.component.html',
    styleUrls: ['./users-management-panel.component.css']
})
export class UsersManagementPanelComponent implements OnInit {
    userModels: UserModel[] = [];
    private usersEditingCache: Map<string, UserModel> = new Map<string, UserModel>();

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.userService.getUsersRequest().subscribe(
            (users: UserModel[]) => {
                this.userModels = users;
            },
            (err: any) => console.log(err));
    }

    startEditUser(user: UserModel) {
        this.usersEditingCache.set(user.id, new UserModel(user.id, user.email, user.firstName, user.lastName, user.role));
    }

    exitEditMode(userId: string) {
        this.usersEditingCache.delete(userId);
    }

    updateUser(user: UserModel) {
        this.userService.postUpdateUserRequest(user).subscribe(
            (updatedUserModel: UserModel) => {
                const userIdx = this.userModels.findIndex(x => x.id == user.id);
                if (userIdx > -1) {
                    this.userModels[userIdx] = updatedUserModel;
                }
                this.exitEditMode(updatedUserModel.id)
            },
            (err: any) => console.log(err)
        );
    }

    removeUser(user: UserModel) {
        this.userService.removeUserRequest(user.id).subscribe(
            (res: boolean) => {
                if (res) {
                    this.userModels.splice(this.userModels.indexOf(user), 1);
                }
            },
            (err: any) => console.log(err)
        );
    }
}
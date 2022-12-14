import { Component } from '@angular/core';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
    isExpanded: boolean = false;

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    isAuthorizedUser(): boolean{
        return localStorage.getItem("currentUser") != null;
    }
}

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { LoginModel } from '../../models/auth/LoginModel';
import { UserAuthInfoModel } from '../../models/auth/UserAuthInfoModel';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    error: string | null;
    form: FormGroup;

    private formSubmitAttempt: boolean;

    constructor(private accountService: AccountService, private router: Router, private fb: FormBuilder) { }

    ngOnInit() {
        if (localStorage.getItem("currentUser")) {
            return this.router.navigate(['/profile']);
        }

        this.form = this.fb.group({
            userName: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    isFieldInvalid(field: string) {
        return (
            (!this.form.get(field).valid && this.form.get(field).touched) ||
            (this.form.get(field).untouched && this.formSubmitAttempt)
        );
    }

    onSubmit() {
        if (!this.form.valid)
            return;

        this.accountService.login(new LoginModel(this.form.get("userName").value, this.form.get("password").value))
            .subscribe(
                (res: UserAuthInfoModel) => {
                    localStorage.setItem("jwtToken", res.accessToken);
                    localStorage.setItem("refreshJwtToken", res.refreshToken);
                    localStorage.setItem("currentUser", JSON.stringify(res.user));
                    this.router.navigate(['/profile']);
                },
                (err: any) => {
                    this.error = err;
                });
        this.formSubmitAttempt = true;
    }
}

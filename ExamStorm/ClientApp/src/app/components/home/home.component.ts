import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { LoginModel } from '../../models/auth/LoginModel';
import { UserAuthInfoModel } from '../../models/auth/UserAuthInfoModel';
import { RegisterModel } from '../../models/auth/RegisterModel';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    error: string | null = null;
    loginForm: FormGroup;
    registerForm: FormGroup;
    isRegisterMode: boolean = false;

    private formSubmitAttempt: boolean;

    constructor(private accountService: AccountService, private router: Router, private fb: FormBuilder) { }

    ngOnInit() {
        if (localStorage.getItem("currentUser")) {
            return this.router.navigate(['/profile']);
        }

        this.loginForm = this.fb.group({
            email: ['', Validators.required],
            password: ['', Validators.required]
        });

        this.registerForm = this.fb.group({
            email: ['', Validators.required],
            fName: ['', Validators.required],
            lName: ['', Validators.required],
            password: ['', Validators.required],
        })
    }

    isLoginFieldValid(field: string) {
        return (!this.loginForm.get(field).valid && this.loginForm.get(field).touched) ||
            (this.loginForm.get(field).untouched && this.formSubmitAttempt);
    }

    isRegisterFieldValid(field: string) {
        return (!this.registerForm.get(field).valid && this.registerForm.get(field).touched) ||
            (this.registerForm.get(field).untouched)
    }

    onLogin() {
        if (!this.loginForm.valid)
            return;

        this.accountService.login(new LoginModel(this.loginForm.get("email").value, this.loginForm.get("password").value))
            .subscribe(
                (res: UserAuthInfoModel) => {
                    localStorage.setItem("jwtToken", res.accessToken);
                    localStorage.setItem("refreshJwtToken", res.refreshToken);
                    localStorage.setItem("currentUser", JSON.stringify(res.user));
                    this.router.navigate(['/profile']);
                },
                (err: any) => {
                    this.error = err.error;
                });
        this.formSubmitAttempt = true;
    }

    onRegister() {
        if (!this.registerForm.valid)
            return;

        this.accountService.register(new RegisterModel(
            this.registerForm.get("email").value,
            this.registerForm.get("fName").value,
            this.registerForm.get("lName").value,
            this.registerForm.get("password").value))
            .subscribe(
                (res) => {
                    this.registerForm.reset();
                    this.isRegisterMode = false;
                },
                (err: any) => {
                    this.error = err.error;
                });
    }

    registerMode() {
        this.error = null;
        this.isRegisterMode = true;
    }
}

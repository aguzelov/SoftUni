import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../service/authentication.service';
import { LoginModel } from '../models/login.model';
import { Router } from '@angular/router';
import { AuthModel } from '../models/auth.model';

@Component({
	selector: 'app-login-form',
	templateUrl: './login-form.component.html',
	styleUrls: [ './login-form.component.css' ]
})
export class LoginFormComponent implements OnInit {
	loginForm: FormGroup;
	constructor(private authService: AuthenticationService, private router: Router) {}

	submitForm() {
		let model: LoginModel = this.loginForm.value;
		this.authService.login(model).subscribe(
			(response) => {
				let token: AuthModel = new AuthModel();
				token.authoken = response['_kmd'].authtoken;
				token.username = response.username;

				this.authService.token = token;

				this.router.navigate([ '' ]);
			},
			(err) => console.log(err)
		);
	}

	ngOnInit() {
		this.loginForm = new FormGroup({
			username: new FormControl('', Validators.required),
			password: new FormControl('', Validators.required)
		});
	}
}

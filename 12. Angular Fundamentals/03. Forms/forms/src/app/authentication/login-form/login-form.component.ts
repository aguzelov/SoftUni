import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
	selector: 'app-login-form',
	templateUrl: './login-form.component.html',
	styleUrls: [ './login-form.component.css' ]
})
export class LoginFormComponent implements OnInit {
	loginForm: FormGroup;
	constructor() {}

	submitForm() {
		console.log(this.loginForm);
	}

	ngOnInit() {
		this.loginForm = new FormGroup({
			username: new FormControl('', Validators.required),
			password: new FormControl('', Validators.required)
		});
	}
}

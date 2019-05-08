import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
	usernameValidator,
	passwordValidator,
	bothPasswordValidator,
	namesValidator,
	emailValidator
} from '../shared/register-from.directive';
import { AuthenticationService } from '../service/authentication.service';
import { RegisterModel } from '../models/register.model';

@Component({
	selector: 'app-register-form',
	templateUrl: './register-form.component.html',
	styleUrls: [ './register-form.component.css' ]
})
export class RegisterFormComponent implements OnInit {
	registerForm: FormGroup;

	constructor(private authService: AuthenticationService, private router: Router) {}

	submitForm(): void {
		let model: RegisterModel = this.registerForm.value;

		this.authService.register(model).subscribe(
			(response) => {
				this.router.navigate([ '' ]);
			},
			(err) => console.log(err)
		);
	}

	ngOnInit() {
		this.registerForm = new FormGroup(
			{
				username: new FormControl('Kokorcho', [ usernameValidator() ]),
				password: new FormControl('1234', passwordValidator()),
				confirmPassword: new FormControl(),
				firstName: new FormControl(),
				lastName: new FormControl(),
				email: new FormControl('', emailValidator()),
				age: new FormControl()
			},
			{ validators: [ bothPasswordValidator, namesValidator ] }
		);
	}
}

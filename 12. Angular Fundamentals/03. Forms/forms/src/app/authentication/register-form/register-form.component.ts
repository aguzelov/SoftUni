import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
	usernameValidator,
	passwordValidator,
	bothPasswordValidator,
	namesValidator,
	emailValidator
} from '../shared/register-from.directive';

@Component({
	selector: 'app-register-form',
	templateUrl: './register-form.component.html',
	styleUrls: [ './register-form.component.css' ]
})
export class RegisterFormComponent implements OnInit {
	registerForm: FormGroup;

	constructor() {}

	submitForm(): void {
		console.log(this.registerForm);
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

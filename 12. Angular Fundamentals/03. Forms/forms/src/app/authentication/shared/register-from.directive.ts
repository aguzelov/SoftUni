import { ValidatorFn, FormGroup, ValidationErrors, AbstractControl } from '@angular/forms';

export function usernameValidator(): ValidatorFn {
	return (
		control: AbstractControl
	): {
		[key: string]: any;
	} | null => {
		const username: string = control.value;
		return username && (startWithCapitalLetter(username) && onlyLettersAndDigits(username))
			? null
			: { username: { value: username } };
	};
}

export function passwordValidator(): ValidatorFn {
	return (
		control: AbstractControl
	): {
		[key: string]: any;
	} | null => {
		const password: string = control.value;
		return password && (password.length >= 4 && password.length <= 16 && onlyLettersAndDigits(password))
			? null
			: { password: { value: password } };
	};
}

export function emailValidator(): ValidatorFn {
	return (
		control: AbstractControl
	): {
		[key: string]: any;
	} | null => {
		const email: string = control.value;
		const pattern: RegExp = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
		return email && email.match(pattern) ? null : { email: { value: email } };
	};
}

export const bothPasswordValidator: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
	const password: string = control.get('password').value;
	const confirmPassword: string = control.get('confirmPassword').value;

	return password && confirmPassword && password === confirmPassword
		? null
		: { password: true, confirmPassword: true };
};

export const namesValidator: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
	const firstName: string = control.get('firstName').value;
	const lastName: string = control.get('lastName').value;

	return firstName &&
	lastName &&
	(startWithCapitalLetter(firstName) && onlyLetters(firstName)) &&
	(startWithCapitalLetter(lastName) && onlyLetters(lastName))
		? null
		: { firstName: true, lastName: true };
};

function startWithCapitalLetter(input: string) {
	return input[0] == input[0].toUpperCase();
}

function onlyLettersAndDigits(input: string) {
	const pattern: string = '^[A-z0-9]+$';
	return input.match(pattern);
}

function onlyLetters(input: string) {
	const pattern: string = '^[A-z]+$';
	return input.match(pattern);
}

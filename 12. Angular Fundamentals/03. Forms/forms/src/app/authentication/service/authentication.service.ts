import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthModel } from '../models/auth.model';

@Injectable()
export class AuthenticationService {
	private appKey: string = 'kid_rJBaNjg24'; // APP KEY HERE;
	private appSecret: string = '9c0db4df4d914756adc4fa7ec7ec249f'; // APP SECRET HERE;
	private registerUrl: string = `https://baas.kinvey.com/user/${this.appKey}`;
	private loginUrl: string = `https://baas.kinvey.com/user/${this.appKey}/login`;
	private logoutUrl: string = `https://baas.kinvey.com/user/${this.appKey}/_logout`;
	private authTokenName: string = 'authToken';

	private currentAuthToken: string;

	constructor(private http: HttpClient) {}

	private createAuthHeaders(type: string = 'Basic'): HttpHeaders {
		if (type === 'Basic') {
			return new HttpHeaders({
				Authorization: `Basic ${btoa(`${this.appKey}:${this.appSecret}`)}`,
				'Content-Type': 'application/json'
			});
		} else {
			return new HttpHeaders({
				Authorization: `Kinvey ${localStorage.getItem(this.authTokenName)}`,
				'Content-Type': 'application/json'
			});
		}
	}

	checkIfLoggedIn() {
		return this.currentAuthToken === localStorage.getItem(this.authTokenName);
	}

	get token() {
		var model: AuthModel = new AuthModel();
		model.username = localStorage.getItem('username');
		model.authoken = this.currentAuthToken;

		return model;
	}

	set token(val: AuthModel) {
		this.currentAuthToken = val.authoken;
		localStorage.setItem(this.authTokenName, this.currentAuthToken);
		localStorage.setItem('username', val.username);
	}

	public login(loginModel: LoginModel) {
		return this.http.post(this.loginUrl, JSON.stringify(loginModel), {
			headers: this.createAuthHeaders()
		});
	}

	public register(registerModel: RegisterModel) {
		return this.http.post(this.registerUrl, JSON.stringify(registerModel), {
			headers: this.createAuthHeaders()
		});
	}

	public logout() {
		this.currentAuthToken = '';

		localStorage.clear();

		return this.http.post(
			this.logoutUrl,
			{},
			{
				headers: this.createAuthHeaders('Kinvey')
			}
		);
	}
}

import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication/service/authentication.service';

@Component({
	selector: 'app-navigation',
	templateUrl: './navigation.component.html',
	styleUrls: [ './navigation.component.css' ]
})
export class NavigationComponent implements OnInit {
	constructor(private authService: AuthenticationService) {}

	logout() {
		console.log('logout');

		this.authService.logout();
	}

	isLoggedIn(): boolean {
		return this.authService.checkIfLoggedIn();
	}

	ngOnInit() {
		console.log('init navigation');
	}
}

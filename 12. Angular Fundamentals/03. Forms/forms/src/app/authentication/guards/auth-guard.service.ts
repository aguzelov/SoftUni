import { Injectable } from '@angular/core';
import { AuthenticationService } from '../service/authentication.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, Route } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
	canActivate(
		next: ActivatedRouteSnapshot,
		state: RouterStateSnapshot
	): boolean | Observable<boolean> | Promise<boolean> {
		if (this._authService.checkIfLoggedIn()) {
			return true;
		}

		this._router.navigate([ '/login' ]);

		return false;
	}

	constructor(private _authService: AuthenticationService, private _router: Router) {}
}

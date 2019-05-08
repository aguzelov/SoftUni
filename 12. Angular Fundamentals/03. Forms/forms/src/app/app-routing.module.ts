import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginFormComponent } from './authentication/login-form/login-form.component';
import { RegisterFormComponent } from './authentication/register-form/register-form.component';
import { AuthGuardService } from './authentication/guards/auth-guard.service';

const routes: Routes = [
	{ path: '', component: HomeComponent, canActivate: [ AuthGuardService ] },
	{ path: 'login', component: LoginFormComponent },
	{ path: 'register', component: RegisterFormComponent }
];

@NgModule({
	imports: [ RouterModule.forRoot(routes) ],
	exports: [ RouterModule ]
})
export class AppRoutingModule {}

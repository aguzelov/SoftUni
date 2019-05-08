import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { LoginFormComponent } from './authentication/login-form/login-form.component';
import { HomeComponent } from './home/home.component';
import { RegisterFormComponent } from './authentication/register-form/register-form.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './authentication/service/authentication.service';
import { AuthGuardService } from './authentication/guards/auth-guard.service';

@NgModule({
	declarations: [ AppComponent, NavigationComponent, LoginFormComponent, HomeComponent, RegisterFormComponent ],
	imports: [ BrowserModule, AppRoutingModule, ReactiveFormsModule, HttpClientModule ],
	providers: [ HttpClientModule, AuthenticationService, AuthGuardService ],
	bootstrap: [ AppComponent ]
})
export class AppModule {}

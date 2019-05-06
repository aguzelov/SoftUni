import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { LoginFormComponent } from './authentication/login-form/login-form.component';
import { HomeComponent } from './home/home.component';
import { RegisterFormComponent } from './authentication/register-form/register-form.component';

@NgModule({
	declarations: [ AppComponent, NavigationComponent, LoginFormComponent, HomeComponent, RegisterFormComponent ],
	imports: [ BrowserModule, AppRoutingModule ],
	providers: [],
	bootstrap: [ AppComponent ]
})
export class AppModule {}

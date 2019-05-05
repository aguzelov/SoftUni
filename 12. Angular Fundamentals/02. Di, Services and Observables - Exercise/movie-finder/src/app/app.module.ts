import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { MoviesService } from './service/movies.service';

@NgModule({
	declarations: [ AppComponent, MoviesComponent ],
	imports: [ BrowserModule, AppRoutingModule, HttpClientModule ],
	providers: [ MoviesService ],
	bootstrap: [ AppComponent ]
})
export class AppModule {}

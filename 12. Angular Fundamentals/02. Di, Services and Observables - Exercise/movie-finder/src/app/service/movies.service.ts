import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class MoviesService {
	apiKey: string = '18296195d287c23e7d85a0aeb2b302c1';

	constructor(private http: HttpClient) {}

	getMostPopular() {
		var path: string = 'https://api.themoviedb.org/3/';
		var popular: string = 'discover/movie?sort_by=popularity.desc';
		var authentication: string = '&api_key=';
		return this.http.get(path + popular + authentication + this.apiKey);
	}

	getInTheaters() {
		var path: string = 'https://api.themoviedb.org/3/';
		var popular: string = 'discover/movie?primary_release_date.gte=2014-09-15&primary_release_date.lte=2014-10-22';
		var authentication: string = '&api_key=';
		return this.http.get(path + popular + authentication + this.apiKey);
	}
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { $ } from 'protractor';

@Injectable({
	providedIn: 'root'
})
export class MoviesService {
	apiKey: string = '18296195d287c23e7d85a0aeb2b302c1';
	path: string = 'https://api.themoviedb.org/3/';
	authentication: string = '&api_key=';

	constructor(private http: HttpClient) {}

	getMostPopular<T>() {
		var url: string = 'discover/movie?sort_by=popularity.desc';
		return this.get<T>(url);
	}

	getInTheaters<T>() {
		var url: string = 'discover/movie?primary_release_date.gte=2014-09-15&primary_release_date.lte=2014-10-22';
		return this.get<T>(url);
	}

	getPopularKids<T>() {
		var url: string = 'discover/movie?certification_country=US&certification.lte=G&sort_by=popularity.desc';
		return this.get<T>(url);
	}

	getBestDrama<T>() {
		var url: string = 'discover/movie?with_genres=18&primary_release_year=2014';
		return this.get<T>(url);
	}

	getMovie<T>(id: number) {
		var url: string = `movie/${id}`;
		return this.http.get<T>(this.path + url + '?api_key=' + this.apiKey);
	}

	findAMovie<T>(name: string) {
		var url: string = 'search/movie';
		return this.http.get<T>(this.path + url + '?api_key=' + this.apiKey + `&query=${name}`);
	}

	get<T>(url: string) {
		return this.http.get<T>(this.path + url + this.authentication + this.apiKey);
	}
}

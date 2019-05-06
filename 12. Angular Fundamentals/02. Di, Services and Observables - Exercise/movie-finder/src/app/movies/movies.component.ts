import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../service/movies.service';
import { Movie } from '../models/movie.model';
import { MovieDbData } from '../models/movieDb.model';

@Component({
	selector: 'app-movies',
	templateUrl: './movies.component.html',
	styleUrls: [ './movies.component.css' ]
})
export class MoviesComponent implements OnInit {
	popular: Movie[];
	theaters: Movie[];
	kids: Movie[];
	dramas: Movie[];
	mathcedMovies: Movie[];
	constructor(private movieService: MoviesService) {}

	ngOnInit() {
		this.movieService.getMostPopular<MovieDbData>().subscribe((data) => {
			this.popular = data.results;
		});

		this.movieService.getInTheaters<MovieDbData>().subscribe((data) => {
			this.theaters = data.results;
		});

		this.movieService.getPopularKids<MovieDbData>().subscribe((data) => {
			this.kids = data.results;
		});

		this.movieService.getBestDrama<MovieDbData>().subscribe((data) => {
			this.dramas = data.results;
		});
	}

	search(form: any) {
		var searchTerm: string = form.search;
		this.movieService.findAMovie<MovieDbData>(searchTerm).subscribe((movie) => {
			this.mathcedMovies = movie.results;
		});
	}
}

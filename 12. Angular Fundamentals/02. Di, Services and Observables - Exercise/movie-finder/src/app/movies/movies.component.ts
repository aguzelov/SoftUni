import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../service/movies.service';
import { Movie } from '../models/movie.model';

@Component({
	selector: 'app-movies',
	templateUrl: './movies.component.html',
	styleUrls: [ './movies.component.css' ]
})
export class MoviesComponent implements OnInit {
	popular: Movie[];
	theaters: Movie[];
	constructor(private movieService: MoviesService) {}

	ngOnInit() {
		this.movieService.getMostPopular().subscribe((data) => {
			this.popular = data.results;
			console.log(data);
		});

		this.movieService.getInTheaters().subscribe((data) => {
			this.theaters = data.results;
			console.log(data);
		});
	}
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MoviesService } from '../service/movies.service';
import { Movie } from '../models/movie.model';

@Component({
	selector: 'app-movie',
	templateUrl: './movie.component.html',
	styleUrls: [ './movie.component.css' ]
})
export class MovieComponent implements OnInit {
	movie: Movie;
	constructor(private route: ActivatedRoute, private movieService: MoviesService) {}

	ngOnInit() {
		this.route.params.subscribe((params) => {
			var id: number = +params['id'];
			this.movieService.getMovie<Movie>(id).subscribe((movie) => {
				this.movie = movie;
			});
		});
	}
}

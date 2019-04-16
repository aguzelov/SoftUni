handlers.cinema = async function(ctx) {
	let partials = handlers.getCommonPartials(ctx);
	try {
		let movies = await movieService.getAllMovies();
		let userId = sessionStorage.getItem('id');
		// movies.forEach((movie) => (movie.isCreator = movie._acl.creator === userId));

		ctx.movies = movies;

		partials.movie = './views/movies/movie.hbs';
		ctx
			.loadPartials(partials)
			.then(function() {
				this.partial('./views/movies/cinema.hbs');
			})
			.catch(function(err) {
				notifications.showError(err);
			});
	} catch (e) {}
};

handlers.getAddMovie = function(ctx) {
	let partials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(partials).then(function() {
		this.partial('./views/movies/addMovie.hbs');
	});
};

handlers.addMovie = function(ctx) {
	let title = ctx.params.title;
	let imageURL = ctx.params.imageUrl;
	let description = ctx.params.description;
	let genres = ctx.params.genres;
	let tickets = ctx.params.tickets;

	if (title.length < 6) {
		notifications.showError('The title should be at least 6 characters long.');
	} else if (description.length < 10) {
		notifications.showError('The description should be at least 10 characters long.');
	} else if (!imageURL.startsWith('http')) {
		notifications.showError('The image should start with "http://" or "https://".');
	} else if (typeof tickets == 'number') {
		notifications.showError('The available tickets should be a number.');
	} else if (!genres.includes(' ')) {
		notifications.showError('The genres must be separated by a single space.');
	} else {
		genres = genres.split(' ');
		let data = {
			title: ctx.params.title,
			imageURL: ctx.params.imageUrl,
			description: ctx.params.description,
			genres: genres,
			tickets: ctx.params.tickets
		};

		movieService
			.createMovie(data)
			.then(function(res) {
				notifications.showSuccess('Movie created successfully.');
				ctx.redirect('#/');
			})
			.catch(function(err) {
				notifications.showError(err);
			});
	}
};

handlers.buyTicket = async function(ctx) {
	let id = ctx.params.id;

	try {
		let movie = await movieService.getAMovie(id);
		if (Number(movie.tickets) > 0) {
			let tickets = movie.tickets - 1;
			movie.tickets = tickets;

			movieService
				.buyTicket(id, movie)
				.then(function() {
					notifications.showSuccess(`Successfully bought ticket for ${movie.title}!`);
					ctx.redirect('#/cinema');
				})
				.catch(function(err) {
					console.log(err);
				});
		} else {
			notifications.showError('If there are no available tickets');
		}
		ctx.redirect('#/cinema');
	} catch (e) {
		console.log(e);
	}
};

handlers.getDetailMovie = async function(ctx) {
	let id = ctx.params.id;
	let partials = handlers.getCommonPartials(ctx);
	try {
		let movie = await movieService.getAMovie(id);
		let genres = movie.genres.join();

		ctx.id = movie._id;
		ctx.title = movie.title;
		ctx.tickets = movie.tickets;
		ctx.imageURL = movie.imageURL;
		ctx.genres = genres;
		ctx.description = movie.description;

		ctx.loadPartials(partials).then(function() {
			this.partial('./views/movies/detailMovie.hbs');
		});
	} catch (e) {
		console.log(e);
	}
};

handlers.getMyMovies = function(ctx) {
	let partials = handlers.getCommonPartials(ctx);

	movieService.getAllMyMovies().then(function(res) {
		let userId = sessionStorage.getItem('id');
		// res.forEach((song) => (song.isCreator = song._acl.creator === userId));

		ctx.movies = res;

		partials.movie = './views/movies/myMovie.hbs';
		ctx.loadPartials(partials).then(function() {
			this.partial('./views/movies/myMovies.hbs');
		});
	});
};

handlers.getDeleteMovie = async function(ctx) {
	let id = ctx.params.id;
	let partials = handlers.getCommonPartials(ctx);
	try {
		let movie = await movieService.getAMovie(id);
		let genres = movie.genres.join();
		ctx.id = movie._id;
		ctx.title = movie.title;
		ctx.tickets = movie.tickets;
		ctx.imageURL = movie.imageURL;
		ctx.genres = genres;
		ctx.description = movie.description;

		ctx.loadPartials(partials).then(function() {
			this.partial('./views/movies/deleteMovie.hbs');
		});
	} catch (e) {
		console.log(e);
	}
};

handlers.deleteMovie = function(ctx) {
	movieService
		.deleteMovie(ctx.params.id)
		.then(function() {
			notifications.showSuccess('Movie removed successfully!');
			ctx.redirect('#/');
		})
		.catch(function(err) {
			notifications.showError(err);
		});
};

handlers.getEditMovie = async function(ctx) {
	let id = ctx.params.id;
	let partials = handlers.getCommonPartials(ctx);
	try {
		let movie = await movieService.getAMovie(id);
		let genres = movie.genres.join();
		ctx.id = movie._id;
		ctx.title = movie.title;
		ctx.tickets = movie.tickets;
		ctx.imageURL = movie.imageURL;
		ctx.genres = genres;
		ctx.description = movie.description;

		ctx.loadPartials(partials).then(function() {
			this.partial('./views/movies/editMovie.hbs');
		});
	} catch (e) {
		console.log(e);
	}
};

handlers.editMovie = function(ctx) {
	let genres = ctx.params.genres.split(' ');

	let data = {
		title: ctx.params.title,
		imageURL: ctx.params.imageUrl,
		description: ctx.params.description,
		genres: genres,
		tickets: ctx.params.tickets
	};

	movieService
		.editMovie(ctx.params.id, data)
		.then(function() {
			notifications.showSuccess('Movie edited successfully!');
			ctx.redirect(`#/myMovies`);
		})
		.catch(function(err) {
			notifications.showError(err);
		});
};

handlers.search = async function(ctx) {
	let searchGenre = ctx.params.search;

	let partials = handlers.getCommonPartials(ctx);
	try {
		let movies = await movieService.getAllMovies();
		let userId = sessionStorage.getItem('id');
		movies = movies.filter((movie) => movie.genres.includes(searchGenre));

		if (movies.length == 0) {
			notifications.showError(`Movie with "${searchGenre}" genre does not exist`);
		} else {
			ctx.movies = movies;

			partials.movie = './views/movies/movie.hbs';
			ctx
				.loadPartials(partials)
				.then(function() {
					this.partial('./views/movies/cinema.hbs');
				})
				.catch(function(err) {
					notifications.showError(err);
				});
		}
	} catch (e) {}
};

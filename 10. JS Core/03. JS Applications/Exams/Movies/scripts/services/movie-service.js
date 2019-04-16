const movieService = (() => {
	const endpoint = 'movies';
	const auth = 'kinvey';
	const collection = 'appdata';

	function createMovie(data) {
		return kinvey.post(collection, endpoint, auth, data);
	}

	function getAllMovies() {
		return kinvey.get(collection, endpoint, auth, '?query={}&sort={"tickets": -1}');
	}

	function getAllMyMovies() {
		return kinvey.get(collection, endpoint, auth, `?query={"_acl.creator":"${sessionStorage.getItem('id')}"}`);
	}

	function getSearchedMovies(searchGenre) {
		return kinvey.get(collection, endpoint, auth, `?query={"genres":"${searchGenre}"}`);
	}

	function deleteMovie(id) {
		return kinvey.remove(collection, `${endpoint}/${id}`, auth);
	}

	function buyTicket(id, movie) {
		return kinvey.update(collection, `${endpoint}/${id}`, auth, movie);
	}

	function editMovie(id, movie) {
		return kinvey.update(collection, `${endpoint}/${id}`, auth, movie);
	}

	function getAMovie(id) {
		return kinvey.get(collection, `${endpoint}/${id}`, auth);
	}

	return {
		createMovie,
		getAllMovies,
		getAllMyMovies,
		getSearchedMovies,
		deleteMovie,
		buyTicket,
		editMovie,
		getAMovie
	};
})();

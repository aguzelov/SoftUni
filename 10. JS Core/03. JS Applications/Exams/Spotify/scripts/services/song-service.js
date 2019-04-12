const songService = (() => {
	const endpoint = 'songs';
	const auth = 'kinvey';
	const collection = 'appdata';

	function createSong(data) {
		return kinvey.post(collection, endpoint, auth, data);
	}

	function getAllSongs() {
		return kinvey.get(collection, endpoint, auth, '?query={}&sort={"likes": -1}');
	}

	function getAllMySongs() {
		return kinvey.get(collection, endpoint, auth, `?query={"_acl.creator":"${sessionStorage.getItem('id')}"}`);
	}

	function removeSong(id) {
		return kinvey.remove(collection, `${endpoint}/${id}`, auth);
	}

	function likeSong(id, song) {
		return kinvey.update(collection, `${endpoint}/${id}`, auth, song);
	}

	function listenSong(id, song) {
		return kinvey.update(collection, `${endpoint}/${id}`, auth, song);
	}

	function getASong(id) {
		return kinvey.get(collection, `${endpoint}/${id}`, auth);
	}

	return {
		createSong,
		getAllSongs,
		getAllMySongs,
		removeSong,
		likeSong,
		listenSong,
		getASong
	};
})();

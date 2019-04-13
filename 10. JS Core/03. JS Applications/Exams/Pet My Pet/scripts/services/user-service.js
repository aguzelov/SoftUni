const userService = (() => {
	const collection = 'user';
	const kinveyAuth = 'kinvey';
	const basicAuth = 'basic';

	function isAuth() {
		return sessionStorage.getItem('authtoken') !== null;
	}

	function saveSession(res) {
		sessionStorage.setItem('username', res.username);
		sessionStorage.setItem('authtoken', res._kmd.authtoken);
		sessionStorage.setItem('id', res._id);
	}

	function register(username, password) {
		if (username.length < 3) {
			return Promise.reject('Username must be at least 3 symbols');
		}

		if (password.length < 6) {
			return Promise.reject('Password must be at least 6 symbols');
		}

		return kinvey.post(collection, '', basicAuth, {
			username,
			password
		});
	}

	function login(username, password) {
		if (username.length < 3) {
			return Promise.reject('Username must be at least 3 symbols');
		}

		if (password.length < 6) {
			return Promise.reject('Password must be at least 6 symbols');
		}

		return kinvey.post(collection, 'login', basicAuth, {
			username,
			password
		});
	}

	function logout() {
		return kinvey.post(collection, '_logout', kinveyAuth);
	}

	return {
		register,
		login,
		logout,
		saveSession,
		isAuth
	};
})();

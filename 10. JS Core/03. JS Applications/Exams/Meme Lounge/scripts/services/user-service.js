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

	function validateUserInput(user) {
		let status = {
			isValid: true,
			message: ''
		};

		if (user.username.length < 3) {
			status.message = 'Username must be at least 3 characters long';
			return status;
		}

		if (user.password.length < 6 && /^[a-zA-Z]+$/.test(password)) {
			status.message = 'Password must be at least 6 characters long and contain only english alphabet letters';
			return status;
		}

		return status;
	}

	function register(user) {
		let validationStatus = validateUserInput(user);
		delete user.password;
		delete user.repeatPass;

		if (!validationStatus.isValid) {
			return Promise.reject(new Error(validationStatus.message));
		}

		return kinvey.post(collection, '', basicAuth, user);
	}

	function login(username, password) {
		let validationStatus = validateUserInput({ username, password });

		if (!validationStatus.isValid) {
			return Promise.reject(new Error(validationStatus.message));
		}

		return kinvey.post(collection, 'login', basicAuth, {
			username,
			password
		});
	}

	function logout() {
		return kinvey.post(collection, '_logout', kinveyAuth);
	}

	function getAUser(id) {
		return kinvey.get(collection, `${id}`, kinveyAuth);
	}

	function deleteUser(id) {
		return kinvey.remove(collection, `${id}`, kinveyAuth);
	}

	return {
		register,
		login,
		logout,
		getAUser,
		deleteUser,
		saveSession,
		isAuth
	};
})();

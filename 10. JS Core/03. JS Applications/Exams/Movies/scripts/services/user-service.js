/* eslint-disable no-undef */
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

	function validateUserInput(username, password, repeatPassword) {
		let status = {
			isValid: false,
			message: ''
		};

		if (repeatPassword !== undefined && password !== repeatPassword) {
			status.message = 'The repeat password should be equal to the password';
			return status;
		}

		if (username.length < 3) {
			status.message = 'Username must be at least 3 characters long';
			return status;
		}

		if (password.length < 6) {
			status.message = 'Password must be at least 6 characters long';
			return status;
		}
		status.isValid = true;
		return status;
	}

	function register(username, password, repeatPassword) {
		let validationStatus = validateUserInput(username, password, repeatPassword);
		if (!validationStatus.isValid) {
			return Promise.reject(new Error(validationStatus.message));
		}

		// @ts-ignore
		return kinvey.post(collection, '', basicAuth, {
			username,
			password
		});
	}

	function login(username, password) {
		let validationStatus = validateUserInput(username, password);
		if (!validationStatus.isValid) {
			return Promise.reject(new Error(validationStatus.message));
		}
		// @ts-ignore
		return kinvey.post(collection, 'login', basicAuth, {
			username,
			password
		});
	}

	function logout() {
		// @ts-ignore
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

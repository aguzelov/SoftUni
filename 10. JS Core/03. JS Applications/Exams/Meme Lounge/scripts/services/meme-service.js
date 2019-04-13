const memeService = (() => {
	const endpoint = 'memes';
	const auth = 'kinvey';
	const collection = 'appdata';

	function validateMemeInput(data) {
		let status = {
			isValid: true,
			message: ''
		};

		if (!data.title || data.title.length > 33) {
			status.isValid = false;
			status.message = 'The title length must not be empty or exceed 33 characters!';
			return status;
		}

		if (!data.description || data.description.length < 30 || data.description.length > 450) {
			status.isValid = false;
			status.message =
				'The description length must not be empty or exceed 450 characters and should be at least 30!';
			return status;
		}

		if (!data.imageUrl.startsWith('http')) {
			status.isValid = false;
			status.message = 'Image URL is not valid!';
			return status;
		}
		return status;
	}

	function createMeme(data) {
		let validationStatus = validateMemeInput(data);

		if (!validationStatus.isValid) {
			return Promise.reject(new Error(validationStatus.message));
		}

		return kinvey.post(collection, endpoint, auth, data);
	}

	function getAllMeme() {
		return kinvey.get(collection, endpoint, auth, '?query={}&sort={}');
	}

	function getAllMyMemes() {
		return kinvey.get(collection, endpoint, auth, `?query={"_acl.creator":"${sessionStorage.getItem('id')}"}`);
	}

	function removeMeme(id) {
		return kinvey.remove(collection, `${endpoint}/${id}`, auth);
	}

	function editMeme(id, data) {
		let validationStatus = validateMemeInput(data);

		if (!validationStatus.isValid) {
			return Promise.reject(new Error(validationStatus.message));
		}

		return kinvey.update(collection, `${endpoint}/${id}`, auth, data);
	}

	function getAMeme(id) {
		return kinvey.get(collection, `${endpoint}/${id}`, auth);
	}

	return {
		createMeme,
		getAllMeme,
		getAllMyMemes,
		removeMeme,
		editMeme,
		getAMeme
	};
})();

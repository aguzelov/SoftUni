const petService = (() => {
	const endpoint = 'pets';
	const auth = 'kinvey';
	const collection = 'appdata';

	function createPet(data) {
		return kinvey.post(collection, endpoint, auth, data);
	}

	function getAllPets() {
		return kinvey.get(collection, endpoint, auth, '?query={}&sort={"likes": -1}');
	}

	function getAllMyPets() {
		return kinvey.get(collection, endpoint, auth, `?query={"_acl.creator":"${sessionStorage.getItem('id')}"}`);
	}

	function removePet(id) {
		return kinvey.remove(collection, `${endpoint}/${id}`, auth);
	}

	function editPet(id, pet) {
		return kinvey.update(collection, `${endpoint}/${id}`, auth, pet);
	}

	function likePet(id, pet) {
		return kinvey.update(collection, `${endpoint}/${id}`, auth, pet);
	}

	function getAPet(id) {
		return kinvey.get(collection, `${endpoint}/${id}`, auth);
	}

	return {
		createPet,
		getAllPets,
		getAllMyPets,
		editPet,
		removePet,
		likePet,
		getAPet
	};
})();

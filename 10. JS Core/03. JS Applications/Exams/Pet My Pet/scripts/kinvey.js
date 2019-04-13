const kinvey = (() => {
	const BASE_URL = 'https://baas.kinvey.com/';
	const APP_KEY = 'kid_BJylNdAFE'; // <------------------- PUT YOUR APP KEY HERE
	const APP_SECRET = '4638d959df11428b8e0bbbfde0236316'; // <------------------ PUT YOUR  APP SECRET HERE

	function makeAuth(auth) {
		if (auth == 'basic') {
			return {
				Authorization: `Basic ${btoa(APP_KEY + ':' + APP_SECRET)}`
			};
		} else {
			return {
				Authorization: `Kinvey ${sessionStorage.getItem('authtoken')}`
			};
		}
	}

	function makeRequest(method, collection, endpoint, auth) {
		return {
			url: BASE_URL + collection + '/' + APP_KEY + '/' + endpoint,
			method,
			headers: makeAuth(auth)
		};
	}

	function post(collection, endpoint, auth, data) {
		let req = makeRequest('POST', collection, endpoint, auth);
		req.data = data;
		return $.ajax(req);
	}

	function get(collection, endpoint, auth, query) {
		if (query) {
			endpoint += query;
		}
		let req = makeRequest('GET', collection, endpoint, auth);
		return $.ajax(req);
	}

	function update(collection, endpoint, auth, data) {
		let req = makeRequest('PUT', collection, endpoint, auth);
		req.data = data;

		return $.ajax(req);
	}

	function remove(collection, endpoint, auth) {
		return $.ajax(makeRequest('DELETE', collection, endpoint, auth));
	}

	return {
		get,
		post,
		update,
		remove
	};
})();

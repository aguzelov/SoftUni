const notifications = (() => {
	$(document).on({
		ajaxStart: () => $('#loadingBox').fadeIn(),
		ajaxStop: () => $('#loadingBox').fadeOut()
	});

	function showSuccess(message) {
		let successBox = $('#infoBox');
		successBox.find('span').text(message);
		successBox.fadeIn();
		successBox.fadeOut(3000);
	}

	function showError(message) {
		let errorBox = $('#errorBox');
		errorBox.find('span').text(message);
		errorBox.fadeIn();
		errorBox.fadeOut(3000);
	}

	return {
		showSuccess,
		showError
	};
})();

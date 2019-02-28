function validate() {
	$('#submit').on('click', (e) => {
		e.preventDefault();
		e.stopPropagation();

		let isValidForm = true;
		isValidForm = isValidUsename() && isValidForm;
		isValidForm = isValidEmail() && isValidForm;
		isValidForm = isValidPasswordAndConfirmPassword() && isValidForm;

		if ($('#company').is(':checked')) {
			isValidForm = isValidCompanyNumber() && isValidForm;
		}

		if (isValidForm) {
			$('#valid').css('display', '');
		} else {
			$('#valid').css('display', 'none');
		}
	});

	$('#company').on('change', () => {
		if ($("#company").is(':checked')) {
			$("#companyInfo").show();
		}
		else {
			$("#companyInfo").hide();
		}
	});

	function isValidUsename() {
		let $username = $('#username');
		let username = $username.val();

		let isValid = /^[A-Za-z0-9]{3,20}$/.test(username);
		markField($username, isValid);
		return isValid;
	}

	function isValidEmail() {
		let $email = $('#email');
		let email = $email.val();

		let isValid = /.*@.*\..*/.test(email);
		markField($email, isValid);
		return isValid;
	}

	function isValidPasswordAndConfirmPassword() {
		let $password = $('#password');
		let password = $password.val();

		let $confirmPassword = $('#confirm-password');
		let confirmPassword = $confirmPassword.val();

		let isValid = isValidPassword(password) &&
			isValidPassword(confirmPassword) &&
			password === confirmPassword;

		markField($password, isValid);
		markField($confirmPassword, isValid);

		return isValid;
	}

	function isValidPassword(password) {
		let isValid = /^\w{5,15}$/.test(password);
		return isValid;
	}

	function isValidCompanyNumber() {
		let $companyNumber = $('#companyNumber');
		let number = +$companyNumber.val();

		let isValid = number >= 1000 && number <= 9999;
		markField($companyNumber, isValid);
		return isValid;
	}

	function markField($field, isValid) {
		if (isValid) {
			$field.css('border', 'none');
		} else {
			$field.css('border-color', 'red'); ``
		}
	}
}

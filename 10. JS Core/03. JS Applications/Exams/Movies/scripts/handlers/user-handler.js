/* eslint-disable no-undef */
handlers.getRegister = function(ctx) {
	let commonPartials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(commonPartials).then(function() {
		this.partial('./views/user/registerPage.hbs');
	});
};

handlers.registerUser = function(ctx) {
	let username = ctx.params.username;
	let password = ctx.params.password;
	let repeatPassword = ctx.params.repeatPassword;

	userService
		.register(username, password, repeatPassword)
		.then((res) => {
			userService.saveSession(res);
			// @ts-ignore
			notifications.showSuccess('User registration successful.');
			ctx.redirect('#/home');
		})
		.catch(function(err) {
			if ('message' in err) {
				notifications.showError(err.message);
			} else {
				notifications.showError(err.responseJSON.description);
			}
		});
};

handlers.getLogin = function(ctx) {
	let commonPartials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(commonPartials).then(function() {
		this.partial('./views/user/loginPage.hbs');
	});
};

handlers.loginUser = function(ctx) {
	let username = ctx.params.username;
	let password = ctx.params.password;
	// @ts-ignore
	userService
		.login(username, password)
		.then((res) => {
			// @ts-ignore
			userService.saveSession(res);
			// @ts-ignore
			notifications.showSuccess('Login successful.');
			ctx.redirect('#/home');
		})
		.catch(function(err) {
			if ('message' in err) {
				notifications.showError(err.message);
			} else {
				notifications.showError(err.responseJSON.description);
			}
		});
};

handlers.logoutUser = function(ctx) {
	// @ts-ignore
	userService.logout().then(() => {
		sessionStorage.clear();
		// @ts-ignore
		notifications.showSuccess('Logout successful.');
		ctx.redirect('#/home');
	});
};

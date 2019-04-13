handlers.getRegister = function(ctx) {
	let partials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(partials).then(function() {
		this.partial('./views/user/registerPage.hbs');
	});
};

handlers.registerUser = function(ctx) {
	let username = ctx.params.username;
	let password = ctx.params.password;

	userService
		.register(username, password)
		.then((res) => {
			userService.saveSession(res);
			notifications.showSuccess('User registration successful.');
			ctx.redirect('#/home');
		})
		.catch(function(err) {
			notifications.showError(err);
		});
};

handlers.getLogin = function(ctx) {
	let partials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(partials).then(function() {
		this.partial('./views/user/loginPage.hbs');
	});
};

handlers.loginUser = function(ctx) {
	let username = ctx.params.username;
	let password = ctx.params.password;

	userService
		.login(username, password)
		.then((res) => {
			userService.saveSession(res);
			notifications.showSuccess('Login successful.');
			ctx.redirect('#/home');
		})
		.catch(function(err) {
			notifications.showError(err);
		});
};

handlers.logoutUser = function(ctx) {
	userService.logout().then(() => {
		sessionStorage.clear();
		notifications.showSuccess('Logout successful.');
		ctx.redirect('#/home');
	});
};

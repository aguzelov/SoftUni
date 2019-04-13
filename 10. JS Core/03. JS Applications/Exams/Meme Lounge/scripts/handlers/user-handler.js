// @ts-check

handlers.getRegister = function(ctx) {
	let commonPartials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(commonPartials).then(function() {
		this.partial('./views/user/registerPage.hbs');
	});
};

handlers.registerUser = function(ctx) {
	let user = {
		username: ctx.params.username,
		password: ctx.params.password,
		repeatPass: ctx.params.repeatPass,
		avatarUrl: ctx.params.avatarUrl,
		email: ctx.params.email
	};
	userService
		.register(user)
		.then((res) => {
			userService.saveSession(res);
			notifications.showSuccess('User registration successful.');
			ctx.redirect('#/memeFeed');
		})
		.catch(function(err) {
			notifications.showError(err.message);
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

	userService
		.login(username, password)
		.then((res) => {
			userService.saveSession(res);
			notifications.showSuccess('User logged in successfully');
			ctx.redirect('#/profile');
		})
		.catch(function(err) {
			notifications.showError(err.message);
		});
};

handlers.logoutUser = function(ctx) {
	userService.logout().then(() => {
		sessionStorage.clear();
		notifications.showSuccess('User logged out successfully');
		ctx.redirect('#/home');
	});
};

handlers.getProfile = async function(ctx) {
	let commonPartials = handlers.getCommonPartials(ctx);

	let userId = sessionStorage.getItem('id');
	let user = await userService.getAUser(userId);

	ctx.id = user._id;
	ctx.avatarUrl = user.avatarUrl;
	ctx.email = user.email;
	ctx.username = user.username;

	let userMemes = await memeService.getAllMyMemes();
	console.log(userMemes);
	ctx.memes = userMemes;

	commonPartials.myMeme = './views/meme/myMeme.hbs';
	ctx.loadPartials(commonPartials).then(function() {
		this.partial('./views/user/profile.hbs');
	});
};

handlers.deleteUser = function(ctx) {
	userService
		.deleteUser(ctx.params.id)
		.then(function() {
			notifications.showSuccess('User deleted.');
			ctx.redirect('#/logout');
		})
		.catch(function(err) {
			notifications.showError(err);
		});
};

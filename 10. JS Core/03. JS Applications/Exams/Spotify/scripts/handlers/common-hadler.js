handlers.getCommonPartials = function(context) {
	context.isAuth = userService.isAuth();
	context.username = sessionStorage.getItem('username');
	return {
		header: './views/common/header.hbs',
		footer: './views/common/footer.hbs'
	};
};

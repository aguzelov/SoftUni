handlers.getHome = async function(ctx) {
	let commonPartials = handlers.getCommonPartials(ctx);
	if (ctx.isAuth) {
		ctx.redirect('#/allPets');
	}
	ctx.loadPartials(commonPartials).then(function() {
		this.partial('./views/home/homePage.hbs');
	});
};

/* eslint-disable no-undef */

handlers.getHome = function(ctx) {
	let commonPartials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(commonPartials).then(function() {
		this.partial('./views/home/homePage.hbs');
	});
};

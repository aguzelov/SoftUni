const handlers = {};

$(() => {
	const app = Sammy('#container', function() {
		this.use('Handlebars', 'hbs');
		// home page routes

		this.get('/index.html', handlers.getHome);
		this.get('/', handlers.getHome);

		this.get('#/home', handlers.getHome);

		// user routes
		this.get('#/register', handlers.getRegister);
		this.get('#/login', handlers.getLogin);

		this.post('#/register', handlers.registerUser);
		this.post('#/login', handlers.loginUser);
		this.get('#/logout', handlers.logoutUser);

		this.get('#/profile', handlers.getProfile);
		this.get('#/delete/:id', handlers.deleteUser);

		// // songs routes
		this.get('#/memeFeed', handlers.getMemeFeed);
		this.get('#/memeDetail/:id', handlers.getMemeDetail);
		this.get('#/createMeme', handlers.getCreateMeme);
		this.post('#/createMeme', handlers.createMeme);

		this.get('#/memeEdit/:id', handlers.getMemeEdit);
		this.post('#/memeEdit/:id', handlers.editMeme);

		this.get('#/memeDelete/:id', handlers.removeMeme);
	});
	app.run('#/home');
});

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
		this.post('#/register', handlers.registerUser);

		this.get('#/login', handlers.getLogin);
		this.post('#/login', handlers.loginUser);

		this.get('#/logout', handlers.logoutUser);

		// // songs routes
		this.get('#/allPets', handlers.getAllPets);
		this.get('#/allPets/:ctr', handlers.getAllPets);

		this.get('#/addPet', handlers.getAddPet);
		this.post('#/addPet', handlers.createPet);

		this.get('#/myPets', handlers.getMyPets);

		this.get('#/editPet/:id', handlers.getEditDetailsPet);
		this.post('#/editPet/:id', handlers.editPet);

		this.get('#/detailsPet/:id', handlers.getEditDetailsPet);

		this.get('#/deletePet/:id', handlers.getRemovePet);
		this.post('#/deletePet/:id', handlers.removePet);

		this.get('#/pet/:id', handlers.pet);
	});
	app.run('#/home');
});

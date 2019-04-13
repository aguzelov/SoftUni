handlers.getAllPets = async function(ctx) {
	let partial = handlers.getCommonPartials(ctx);

	try {
		let userId = sessionStorage.getItem('id');
		let pets = await petService.getAllPets();

		let category = ctx.params.ctr;
		if (ctx.params.ctr) {
			pets = pets.filter((pet) => pet._acl.creator !== userId && pet.category === category);
		} else {
			pets = pets.filter((pet) => pet._acl.creator !== userId);
		}

		ctx.pets = pets;
		partial.otherPet = './views/pet/otherPet.hbs';
		ctx.loadPartials(partial).then(function() {
			this.partial('./views/pet/allPetsPage.hbs');
		});
	} catch (e) {
		console.log(e);
	}
};

handlers.getAddPet = function(ctx) {
	let partial = handlers.getCommonPartials(ctx);

	ctx.loadPartials(partial).then(function() {
		this.partial('./views/pet/addPetPage.hbs');
	});
};

handlers.createPet = function(ctx) {
	let data = {
		name: ctx.params.name,
		description: ctx.params.description,
		imageURL: ctx.params.imageURL,
		category: ctx.params.category,
		likes: 0
	};

	if (!data.name || !data.description || !data.imageURL || !data.category) {
		notifications.showError('All input fields must be filled');
	} else {
		petService
			.createPet(data)
			.then(function(res) {
				notifications.showSuccess('Pet created.');
				ctx.redirect('#/home');
			})
			.catch(function(err) {
				console.log(err);
			});
	}
};

handlers.getMyPets = function(ctx) {
	petService.getAllMyPets().then(function(res) {
		let userId = sessionStorage.getItem('id');
		res.forEach((pet) => (pet.isCreator = pet._acl.creator === userId));

		ctx.pets = res;
		let partials = handlers.getCommonPartials(ctx);
		partials.pet = './views/pet/myPet.hbs';
		ctx.loadPartials(partials).then(function() {
			this.partial('./views/pet/myPetsPage.hbs');
		});
	});
};

handlers.getRemovePet = async function(ctx) {
	let id = ctx.params.id;
	let userId = sessionStorage.getItem('id');
	let pet = await petService.getAPet(id);

	ctx.name = pet.name;
	ctx.description = pet.description;
	ctx.likes = pet.likes;
	ctx.imageURL = pet.imageURL;
	ctx.id = pet._id;

	let partial = handlers.getCommonPartials(ctx);
	ctx.loadPartials(partial).then(function() {
		this.partial('./views/pet/deletePet.hbs');
	});
};

handlers.removePet = function(ctx) {
	petService
		.removePet(ctx.params.id)
		.then(function() {
			notifications.showSuccess('Pet removed successfully!');
			ctx.redirect('#/allPets');
		})
		.catch(function(err) {
			console.log(err);
		});
};

handlers.getEditDetailsPet = async function(ctx) {
	let id = ctx.params.id;
	let userId = sessionStorage.getItem('id');
	let pet = await petService.getAPet(id);
	sessionStorage.setItem('pet', JSON.stringify(pet));

	ctx.name = pet.name;
	ctx.description = pet.description;
	ctx.likes = pet.likes;
	ctx.imageURL = pet.imageURL;
	ctx.id = pet._id;

	let partial = handlers.getCommonPartials(ctx);
	let view = './views/pet/detailsOtherPet.hbs';
	if (pet._acl.creator === userId) {
		view = './views/pet/detailsMyPet.hbs';
	}
	ctx.loadPartials(partial).then(function() {
		this.partial(view);
	});
};

handlers.editPet = function(ctx) {
	try {
		let pet = JSON.parse(sessionStorage.getItem('pet'));

		pet.description = ctx.params.description;
		petService
			.editPet(pet._id, pet)
			.then(function() {
				notifications.showSuccess('Updated successfully!');
				ctx.redirect('#/myPets');
			})
			.catch(function(err) {
				console.log(err);
			});
	} catch (e) {
		console.log(e);
	}
};

handlers.pet = async function(ctx) {
	let id = ctx.params.id;

	try {
		let pet = await petService.getAPet(id);
		let newLikes = Number(pet.likes) + 1;
		pet.likes = newLikes;

		petService
			.likePet(id, pet)
			.then(function() {
				notifications.showSuccess('Pet was liked successfully!');
				ctx.redirect('#/allPets');
			})
			.catch(function(err) {
				console.log(err);
			});
	} catch (e) {
		console.log(e);
	}
};

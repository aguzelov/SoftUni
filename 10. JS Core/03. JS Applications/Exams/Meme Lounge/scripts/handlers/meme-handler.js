handlers.getMemeFeed = async function(ctx) {
	let partials = handlers.getCommonPartials(ctx);
	try {
		let memes = await memeService.getAllMeme();
		let userId = sessionStorage.getItem('id');
		memes.forEach((meme) => (meme.isCreator = meme._acl.creator === userId));

		ctx.memes = memes;
		partials.meme = './views/meme/meme.hbs';
		ctx
			.loadPartials(partials)
			.then(function() {
				this.partial('./views/meme/meme-feed.hbs');
			})
			.catch(function(err) {
				console.log(err);
			});
	} catch (e) {
		console.log(e);
	}
};

handlers.getCreateMeme = function(ctx) {
	let partials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(partials).then(function() {
		this.partial('./views/meme/createMeme.hbs');
	});
};

handlers.createMeme = function(ctx) {
	let creator = sessionStorage.getItem('username');
	let data = {
		title: ctx.params.title,
		description: ctx.params.description,
		imageUrl: ctx.params.imageUrl,
		creator: creator
	};

	memeService
		.createMeme(data)
		.then(function(res) {
			notifications.showSuccess('Meme created');
			ctx.redirect('#/memeFeed');
		})
		.catch(function(err) {
			notifications.showError(err.message);
		});
};

handlers.getMemeDetail = async function(ctx) {
	let id = ctx.params.id;
	let partials = handlers.getCommonPartials(ctx);
	try {
		let meme = await memeService.getAMeme(id);
		ctx.id = meme._id;
		ctx.title = meme.title;
		ctx.imageUrl = meme.imageUrl;
		ctx.description = meme.description;
		ctx.creator = meme.creator;

		let userId = sessionStorage.getItem('id');
		ctx.isCreator = meme._acl.creator === userId;

		ctx.loadPartials(partials).then(function() {
			this.partial('./views/meme/memeDetail.hbs');
		});
	} catch (e) {
		console.log(e);
	}
};

handlers.removeMeme = function(ctx) {
	memeService
		.removeMeme(ctx.params.id)
		.then(function() {
			notifications.showSuccess('Meme deleted.');
			ctx.redirect('#/memeFeed');
		})
		.catch(function(err) {
			notifications.showError(err);
		});
};

handlers.getMemeEdit = async function(ctx) {
	let id = ctx.params.id;
	let partials = handlers.getCommonPartials(ctx);
	try {
		let meme = await memeService.getAMeme(id);
		sessionStorage.setItem('meme', JSON.stringify(meme));
		ctx.id = meme._id;
		ctx.title = meme.title;
		ctx.imageUrl = meme.imageUrl;
		ctx.description = meme.description;

		ctx.loadPartials(partials).then(function() {
			this.partial('./views/meme/memeEdit.hbs');
		});
	} catch (e) {
		notifications.showError(e);
	}
};

handlers.editMeme = function(ctx) {
	let id = ctx.params.id;

	try {
		// let meme = await memeService.getAMeme(id);
		let meme = JSON.parse(sessionStorage.getItem('meme'));
		meme.title = ctx.params.title;
		meme.imageUrl = ctx.params.imageUrl;
		meme.description = ctx.params.description;

		memeService
			.editMeme(id, meme)
			.then(function() {
				notifications.showSuccess(`Meme ${meme.title} updated.`);
				ctx.redirect('#/memeFeed');
			})
			.catch(function(err) {
				notifications.showError(err.message);
			});
	} catch (e) {
		console.log(e);
	}
};

handlers.getMySongs = function(ctx) {
	let partials = handlers.getCommonPartials(ctx);
	memeService.getAllMySongs().then(function(res) {
		let userId = sessionStorage.getItem('id');
		res.forEach((song) => (song.isCreator = song._acl.creator === userId));

		ctx.songs = res;

		partials.song = './views/song/song.hbs';
		ctx.loadPartials(partials).then(function() {
			this.partial('../views/song/mySongsPage.hbs');
		});
	});
};

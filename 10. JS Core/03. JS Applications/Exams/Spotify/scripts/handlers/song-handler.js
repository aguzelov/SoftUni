handlers.getAllSongs = async function(ctx) {
	try {
		let songs = await songService.getAllSongs();
		let userId = sessionStorage.getItem('id');
		songs.forEach((song) => (song.isCreator = song._acl.creator === userId));
		ctx.songs = songs;

		let partials = handlers.getCommonPartials(ctx);
		partials.song = './views/song/song.hbs';

		ctx
			.loadPartials(partials)
			.then(function() {
				this.partial('./views/song/allSongsPage.hbs');
			})
			.catch(function(err) {
				console.log(err);
			});
	} catch (e) {
		console.log(e);
	}
};

handlers.getCreateSong = function(ctx) {
	let partials = handlers.getCommonPartials(ctx);

	ctx.loadPartials(partials).then(function() {
		this.partial('./views/song/createSongPage.hbs');
	});
};

handlers.getMySongs = function(ctx) {
	songService.getAllMySongs().then(function(res) {
		let userId = sessionStorage.getItem('id');
		res.forEach((song) => (song.isCreator = song._acl.creator === userId));

		ctx.songs = res;

		let partials = handlers.getCommonPartials(ctx);
		partials.song = './views/song/song.hbs';

		ctx.loadPartials(partials).then(function() {
			this.partial('./views/song/mySongsPage.hbs');
		});
	});
};

handlers.createSong = function(ctx) {
	let data = {
		title: ctx.params.title,
		artist: ctx.params.artist,
		imageURL: ctx.params.imageURL,
		likes: 0,
		listened: 0
	};

	if (data.title.length < 6) {
		notifications.showError('The title should be at least 6 characters long!');
	} else if (data.artist.length < 3) {
		notifications.showError('The artist should be at least 3 characters long!');
	} else if (!data.imageURL.startsWith('http')) {
		notifications.showError('The image should start with "http://" or "https://"');
	} else {
		songService
			.createSong(data)
			.then(function(res) {
				notifications.showSuccess('Song created successfully!');
				ctx.redirect('#/mySongs');
			})
			.catch(function(err) {
				console.log(err);
			});
	}
};

handlers.removeSong = function(ctx) {
	songService
		.removeSong(ctx.params.id)
		.then(function() {
			notifications.showSuccess('Song removed successfully!');
			ctx.redirect('#/mySongs');
		})
		.catch(function(err) {
			console.log(err);
		});
};

handlers.likeSong = async function(ctx) {
	let id = ctx.params.id;

	try {
		let song = await songService.getASong(id);
		let newLikes = Number(song.likes) + 1;
		song.likes = newLikes;

		songService
			.likeSong(id, song)
			.then(function(e) {
				notifications.showSuccess('Liked!');
				ctx.redirect('#/allSongs');
			})
			.catch(function(err) {
				console.log(err);
			});
	} catch (e) {
		console.log(e);
	}
};

handlers.listenSong = async function(ctx) {
	let id = ctx.params.id;

	try {
		let song = await songService.getASong(id);
		let songName = song.name;
		let newListened = Number(song.listened) + 1;
		song.listened = newListened;

		songService
			.listenSong(id, song)
			.then(function(e) {
				notifications.showSuccess(`You just listened ${songName}`);
				ctx.redirect('#/allSongs');
			})
			.catch(function(err) {
				console.log(err);
			});
	} catch (e) {
		console.log(e);
	}
};

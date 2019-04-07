$(() => {
	const app = Sammy('#main', function () {
		this.use('Handlebars', 'hbs');

		this.get('#/', getHome);
		this.get('#/home', getHome);
		this.get('#/about', getAbout);

		this.get('#/register', getRegister);
		this.post('#/register', postRegister);

		this.get('#/login', getLogin);
		this.post('#/login', postLogin);
		this.get('#/logout', getLogout);

		this.get('#/catalog', getCatalog);
		this.get('#/catalog/:teamId', getDetails);

		this.get('#/create', getCreate);
		this.post('#/create', postCreate);

		this.get('#/edit/:teamId', getEdit);
		this.post('#/edit/:teamId', postEdit);

		this.get('#/join/:teamId', getJoin);
		this.get('#/leave', getLeave);
	});

	app.run('#/');
});

function getHome(context) {
	let partials = getCommonPartials(context);
	this.loadPartials(partials).then(function () {
		this.teamId = sessionStorage.getItem('teamId');
		this.partial('./templates/home/home.hbs');
	});
}

function getAbout(context) {
	let partials = getCommonPartials(context);
	this.loadPartials(partials).then(function () {
		this.partial('./templates/about/about.hbs');
	});
}

function getRegister(context) {
	let partials = getCommonPartials(context);
	partials.registerForm = './templates/register/registerForm.hbs';
	this.loadPartials(partials).then(function () {
		this.partial('./templates/register/registerPage.hbs');
	});
}

function postRegister(context) {
	let {
		username,
		password,
		repeatPassword
	} = context.params;
	let _this = this;
	auth.register(username, password, repeatPassword)
		.then(function (userInfo) {
			auth.saveSession(userInfo);
			auth.showInfo('Registration is successfully');
			_this.redirect('#/');
		})
		.catch(function () {
			auth.showError('Registration is not successfully');
		});
}

function getLogin(context) {
	let partials = getCommonPartials(context);
	partials.loginForm = './templates/login/loginForm.hbs';
	this.loadPartials(partials).then(function () {
		this.partial('./templates/login/loginPage.hbs');
	});
}

function postLogin(context) {
	let {
		username,
		password
	} = context.params;
	let _this = this;
	auth.login(username, password)
		.then(function (userInfo) {
			auth.saveSession(userInfo);
			auth.showInfo('Login is successfully');
			_this.redirect('#/');
		})
		.catch(function () {
			auth.showError('Login is not successfully');
		});
}

function getLogout(context) {
	let _this = this;
	auth.logout()
		.then(function () {
			sessionStorage.clear();
			auth.showInfo('Logout is successfully');
			_this.redirect('#/');
		}).catch(function () {
			auth.showError('Logout is not successfully');
		});
}

function getCatalog(context) {
	let partials = getCommonPartials(context);
	partials.team = './templates/catalog/team.hbs';
	this.loadPartials(partials)
		.then(function () {
			let _this = this;
			teamsService.loadTeams()
				.then(function (teams) {
					context.teams = teams;
					context.hasNoTeam = teams;
					_this.partial('./templates/catalog/teamCatalog.hbs');
				});
		});
}

function getCreate(context) {
	let partials = getCommonPartials(context);
	partials.createForm = './templates/create/createForm.hbs';
	this.loadPartials(partials)
		.then(function () {
			this.partial('./templates/create/createPage.hbs');
		});
}

function postCreate(context) {
	let {
		name,
		comment
	} = context.params;
	let _this = this;
	teamsService.createTeam(name, comment)
		.then(function (teamInfo) {
			sessionStorage.setItem('teamId', teamInfo._id);
			auth.showInfo(`${teamInfo.name} is successfully created`);
			_this.redirect('#/catalog');
		})
		.catch(function () {
			auth.showError('Team is not created');
		});
}

function getDetails(context) {
	let partials = getCommonPartials(context);
	partials.teamMember = './templates/catalog/teamMember.hbs';
	partials.teamControls = './templates/catalog/teamControls.hbs';

	context.isOnTeam = !!sessionStorage.getItem('teamId');
	this.loadPartials(partials)
		.then(function () {
			let _this = this;
			let teamId = context.params.teamId.substr(1);

			teamsService.loadTeamDetails(teamId)
				.then(function (teamInfo) {
					context.isAuthor = sessionStorage.getItem('userId') === teamInfo._acl.creator;

					context.name = teamInfo.name;
					context.members = teamInfo.members;
					context.comment = teamInfo.comment;
					context.teamId = teamId;
					_this.partial('./templates/catalog/details.hbs');
				});
		});
}

function getEdit(context) {
	let partials = getCommonPartials(context);
	partials.editForm = './templates/edit/editForm.hbs';
	this.loadPartials(partials)
		.then(function () {
			let teamId = context.params.teamId.substr(1);
			let _this = this;
			teamsService.loadTeamDetails(teamId)
				.then(function (teamInfo) {
					context.teamId = teamId;
					context.name = teamInfo.name;
					context.comment = teamInfo.comment;
					_this.partial('./templates/edit/editPage.hbs');
				});
		});
}

function postEdit(context) {
	let teamId = context.params.teamId.substr(1);

	let {
		name,
		description
	} = context.params;
	let _this = this;
	teamsService.edit(teamId, name, description)
		.then(function (teamInfo) {
			auth.showInfo('Team info is changed');
			_this.redirect(`#/catalog/:${teamId}`);
		})
		.catch(function () {
			auth.showInfo('Error');
		});
}

function getLeave(context) {
	let teamId = sessionStorage.getItem('teamId');

	teamsService.leaveTeam();
	sessionStorage.setItem('teamId', '');
	this.redirect(`#/catalog/:${teamId}`);
}

function getJoin(context) {
	let teamId = context.params.teamId.substr(1);

	teamsService.joinTeam(teamId);

	sessionStorage.setItem('teamId', teamId);

	this.redirect(`#/catalog/:${teamId}`);
}

//common
function getCommonPartials(context) {
	setCommon(context);
	return {
		header: './templates/common/header.hbs',
		footer: './templates/common/footer.hbs'
	};
}

function setCommon(context) {
	context.loggedIn = !!sessionStorage.getItem('userId');
	context.username = sessionStorage.getItem('username');
}
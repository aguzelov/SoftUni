let FilmStudio = require('./filmStudio');
let assert = require('chai').assert;

describe('FilmStudio', function () {
    describe('constructor', function () {
        it('has all property', function () {
            let fs = new FilmStudio();

            assert.property(fs, 'name', 'Must have property name');
            assert.property(fs, 'films', 'Must have property films');
        });

        it('name property is init', function () {
            let name = 'TestName';
            let fs = new FilmStudio(name);

            assert.equal(fs.name, name);
        });

        it('films property is empty array', function () {
            let name = 'TestName';
            let fs = new FilmStudio(name);

            assert.deepEqual(fs.films, []);
        });
    });

    describe('makeMovie', function () {
        it('invalid arguments count', function () {
            let fs = new FilmStudio('test');

            assert.throws(() => { fs.makeMovie('test', 'test', 'test'); }, /Invalid arguments count/);
        });

        it('invalid first argument type', function () {
            let fs = new FilmStudio('test');

            assert.throws(() => { fs.makeMovie([], 'test', 'test'); }, /Invalid arguments/);
        });

        it('invalid second argument type', function () {
            let fs = new FilmStudio('test');

            assert.throws(() => { fs.makeMovie('test', 'test'); }, /Invalid arguments/);
        });

        it('result has valid property', function () {
            let filmStudio = new FilmStudio('SU-Studio');
            let result = filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

            assert.property(result, 'filmName');
            assert.property(result, 'filmRoles');
        });

        it('result has valid film name', function () {
            let filmStudio = new FilmStudio('SU-Studio');
            let name = 'The Avengers';
            let roles = ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy'];

            let result = filmStudio.makeMovie(name, roles);

            assert.equal(result.filmName, name);
        });

        it('result has valid film roles', function () {
            let filmStudio = new FilmStudio('SU-Studio');
            let name = 'The Avengers';
            let roles = ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy'];

            let result = filmStudio.makeMovie(name, roles);
            let resultRoles = result.filmRoles.reduce((acc, curr) => {
                acc.push(curr.role);
                return acc;
            }, []);


            assert.deepEqual(resultRoles, roles);
        });

        it('result with multipple add', function () {
            let filmStudio = new FilmStudio('SU-Studio');

            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            let result = filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

            assert.equal(result.filmName, 'The Avengers 3');
        });

        it('add film to films', function () {
            let filmStudio = new FilmStudio('SU-Studio');
            let result = filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

            let film = filmStudio.films[0];

            assert.equal(film.filmName, result.filmName);
            assert.equal(film.filmRoles.length, result.filmRoles.length);
        });
    });

    describe('casting', function () {
        it('with no films added', function () {
            let studionName = 'SU-Studio';
            let filmStudio = new FilmStudio(studionName);
            let expectedResult = `There are no films yet in ${studionName}.`;

            let result = filmStudio.casting('Actor', 'role');

            assert.equal(result, expectedResult);
        });

        it('with no existing role', function () {
            let studionName = 'SU-Studio';
            let filmStudio = new FilmStudio(studionName);
            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            let actor = 'Actor';
            let role = 'Role';


            let expectedResult = `${actor}, we cannot find a ${role} role...`;

            let result = filmStudio.casting(actor, role);

            assert.equal(result, expectedResult);
        });

        it('with existing role', function () {
            let studionName = 'SU-Studio';
            let filmStudio = new FilmStudio(studionName);
            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            let actor = 'Actor';
            let role = 'Iron-Man';


            let expectedResult = `You got the job! Mr. ${actor} you are next ${role} in the ${'The Avengers'}. Congratz!`;

            let result = filmStudio.casting(actor, role);

            assert.equal(result, expectedResult);

        });

        it('film role changed', function () {
            let studionName = 'SU-Studio';
            let filmStudio = new FilmStudio(studionName);
            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            let actor = 'Actor';
            let role = 'Iron-Man';

            filmStudio.casting(actor, role);
            let film = filmStudio.films[0];
            let currentRole = film.filmRoles.find(r => r.role === role);
            console.log(film);


            assert.equal(currentRole.actor, actor);

        });

    });

    describe('lookForProducer', function () {
        it('with no existing film', function () {
            let filmStudio = new FilmStudio('SU-Studio');
            let filmName = 'test';

            assert.throw(() => filmStudio.lookForProducer(filmName), /test do not exist yet, but we need the money.../);
        });

        it('with existing film', function () {
            let filmStudio = new FilmStudio('SU-Studio');
            let filmName = 'The Avengers';
            filmStudio.makeMovie(filmName, ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);


            let result = filmStudio.lookForProducer(filmName);

            let expected = `Film name: The Avengers\nCast:\nfalse as Iron-Man\nfalse as Thor\nfalse as Hulk\nfalse as Arrow guy\n`;

            assert.equal(result, expected);
        });
    });
});
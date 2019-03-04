let SoftUniFy = require('./SoftUniFy');
let assert = require('chai').assert;

describe('SoftUniFy', function () {
    describe('constuctor', function () {
        it('have allSongs property', function () {
            let softUniFy = new SoftUniFy();

            assert.property(softUniFy, 'allSongs');
        });
        it('allSongs is initialized as an empty obj', () => {
            let softUniFy = new SoftUniFy();

            assert.isEmpty(softUniFy.allSongs);
        });
    });

    describe('downloadSong', () => {
        let softUniFy;
        beforeEach(() => {
            softUniFy = new SoftUniFy();
        });

        it('return itself', () => {
            let artist = 'Artist';
            let song = 'Song';
            let lyrics = 'Lirics';

            let resultObj = softUniFy.downloadSong(artist, song, lyrics);

            assert.instanceOf(resultObj, SoftUniFy);
        });
        it('add artist to allSongs', () => {
            let artist = 'Artist';
            let song = 'Song';
            let lyrics = 'Lirics';

            softUniFy.downloadSong(artist, song, lyrics);

            assert.isTrue(softUniFy.allSongs.hasOwnProperty(artist));
        });
        it('default rate is zero', () => {
            let artist = 'Artist';
            let song = 'Song';
            let lyrics = 'Lirics';

            softUniFy.downloadSong(artist, song, lyrics);

            assert.equal(softUniFy.allSongs[artist]['rate'], 0);
        });
        it('default votes is zero', () => {
            let artist = 'Artist';
            let song = 'Song';
            let lyrics = 'Lirics';

            softUniFy.downloadSong(artist, song, lyrics);

            assert.equal(softUniFy.allSongs[artist]['votes'], 0);
        });
        it('song is added', () => {
            let artist = 'Artist';
            let song = 'Song';
            let lyrics = 'Lirics';

            softUniFy.downloadSong(artist, song, lyrics);

            assert.equal(softUniFy.allSongs[artist]['songs'].length, 1);
        });
        it('song is added with correct format', () => {
            let artist = 'Artist';
            let song = 'Song';
            let lyrics = 'Lirics';

            softUniFy.downloadSong(artist, song, lyrics);
            let songs = softUniFy.allSongs[artist]['songs'];

            assert.isTrue(songs.indexOf(`${song} - ${lyrics}`) !== -1);
        });
        it('multiple song', () => {
            let artist = 'Artist';
            let song = 'Song';
            let lyrics = 'Lirics';

            softUniFy.downloadSong(artist, song, lyrics);
            softUniFy.downloadSong(artist, song, lyrics);
            softUniFy.downloadSong(artist, song, lyrics);

            let songs = softUniFy.allSongs[artist]['songs'];

            assert.equal(songs.length, 3);
        });
    });

    describe('playSong', () => {
        let softUniFy;
        beforeEach(() => {
            softUniFy = new SoftUniFy();
        });

        it('with no downloaded song', () => {
            let song = 'SongName';
            let expected = `You have not downloaded a ${song} song yet. Use SoftUniFy's function downloadSong() to change that!`;

            let result = softUniFy.playSong(song);

            assert.equal(result, expected);
        });
        it('with no available song', () => {
            let artist = 'ArtistName';
            let song = 'SongName';
            let lyrics = 'Lyrics';

            let songToPlay = 'SongToPlay';
            let expected = `You have not downloaded a ${songToPlay} song yet. Use SoftUniFy's function downloadSong() to change that!`;

            softUniFy.downloadSong(artist, song, lyrics);
            let result = softUniFy.playSong(songToPlay);

            assert.equal(result, expected);
        });
        it('with different artists', () => {
            let artist = 'ArtistName';
            let song = 'SongName';
            let lyrics = 'Lyrics';

            for (let index = 0; index < 10; index++) {
                softUniFy.downloadSong(artist + `${index}`, song + `${index}`, lyrics + `${index}`);
            }


            for (let index = 0; index < 10; index++) {
                let expected = `ArtistName${index}:\nSongName${index} - Lyrics${index}\n`;
                let result = softUniFy.playSong(song + `${index}`);
                assert.equal(result, expected);
            }
        });
        it('with multiple songs from one artist', () => {
            let artist = 'ArtistName';
            let song = 'SongName';
            let lyrics = 'Lyrics';

            for (let index = 0; index < 10; index++) {
                softUniFy.downloadSong(artist, song + `${index}`, lyrics + `${index}`);
            }


            for (let index = 0; index < 10; index++) {
                let expected = `ArtistName:\nSongName${index} - Lyrics${index}\n`;
                let result = softUniFy.playSong(song + `${index}`);
                assert.equal(result, expected);
            }
        });
        it('with multiple songs from multiple artists', () => {
            let artist = 'ArtistName';
            let song = 'SongName';
            let lyrics = 'Lyrics';

            let expected = '';
            for (let index = 0; index < 10; index++) {
                softUniFy.downloadSong(artist + `${index}`, song, lyrics + `${index}`);
                expected += `${artist + index}:\n${song} - ${lyrics + index}\n`;
            }

            let result = softUniFy.playSong(song);
            assert.equal(result, expected);


        });
    });

    describe('songList', () => {
        let softUniFy;
        beforeEach(() => {
            softUniFy = new SoftUniFy();
        });

        it('with empty songList', () => {
            let expected = 'Your song list is empty';

            let result = softUniFy.songsList;

            assert.equal(result, expected)
        });
        it('with multiple songs', () => {
            let artist = 'ArtistName';
            let song = 'SongName';
            let lyrics = 'Lyrics';

            let songs = [];
            for (let index = 0; index < 10; index++) {
                softUniFy.downloadSong(artist + `${index}`, song + `${index}`, lyrics + `${index}`);
                songs.push(`${song + index} - ${lyrics + index}`);
            }

            let expected = songs.join('\n');
            let result = softUniFy.songsList;

            assert.equal(result, expected);
        });
    });


    describe('rateArtist', () => {
        let softUniFy;
        beforeEach(() => {
            softUniFy = new SoftUniFy();
        });

        it('with no existing artist', () => {
            let artist = 'ArtistName';
            let expected = `The ${artist} is not on your artist list.`;

            let result = softUniFy.rateArtist(artist);

            assert.equal(result, expected);
        });
        it('with new added artist', () => {
            let artist = 'ArtistName';
            let song = 'SongName';
            let lyrics = 'Lyrics';

            softUniFy.downloadSong(artist, song, lyrics);

            let expected = '0';

            let result = softUniFy.rateArtist(artist);

            assert.equal(result, expected);
        });
        it('with multiple rate', () => {
            let artist = 'ArtistName';
            let song = 'SongName';
            let lyrics = 'Lyrics';

            softUniFy.downloadSong(artist, song, lyrics);

            let rate = 50;


            let expected = rate;

            softUniFy.rateArtist(artist, rate);
            softUniFy.rateArtist(artist, rate);
            softUniFy.rateArtist(artist, rate);
            let result = softUniFy.rateArtist(artist, rate);

            assert.equal(result, expected);
        });
    });
});
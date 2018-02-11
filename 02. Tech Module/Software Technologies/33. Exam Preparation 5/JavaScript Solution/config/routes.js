const animeController = require('../controllers/anime');

module.exports = (app) => {
    app.get('/', animeController.index);

    app.get('/create/', animeController.createGet);
    app.post('/create/', animeController.createPost);

    app.get('/delete/:id', animeController.deleteGet);
    app.post('/delete/:id', animeController.deletePost);
};
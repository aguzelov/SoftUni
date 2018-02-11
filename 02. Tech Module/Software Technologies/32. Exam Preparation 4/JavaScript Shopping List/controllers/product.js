const Product = require('../models/Product');

module.exports = {
	index: (req, res) => {
        Product.find().then(products => {
            return res.render('product/index', {'entries': products});
        }).catch(err => {
            return res.send("error");
        });
    	},
	createGet: (req, res) => {
        res.render('product/create');
	},
	createPost: (req, res) => {
        let product = req.body;
        Product.create(product).then(product => {
            res.redirect("/");
        }).catch(err => {
            product.error = 'Cannot create product.';
            res.render('product/create', product);
        });
	},
	editGet: (req, res) => {
        let productId = req.params.id;
        Product.findById(productId).then(product => {
            if (product) {
                res.render('product/edit', product );
            }
            else {
                res.redirect('/');
            }
        }).catch(err => res.redirect('/'));
	},
	editPost: (req, res) => {
        let productId = req.params.id;
        let product = req.body;

        Product.findByIdAndUpdate(productId, product, {runValidators: true}).then(product => {
            res.redirect("/");
        }).catch(err => {
            product.id = productId;
            product.error = "Cannot edit product.";
            return res.render("product/edit", product);
        });
	}
};
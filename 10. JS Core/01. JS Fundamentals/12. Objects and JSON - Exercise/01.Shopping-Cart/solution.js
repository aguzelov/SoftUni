function solves() {
    let textArea = document.querySelector('div#exercise textarea');
    let productButtons = document.querySelectorAll('div#exercise div.product button');
    let divElement = document.getElementById('exercise');

    let products = [];
    divElement.lastElementChild.addEventListener('click', function () {
        let list = products.map(p => p.name).filter((el, idx, arr) => {
            if (arr.indexOf(el) === idx) {
                return el;
            }
        });

        let totalPrice = products.map(x => x.price).reduce((a, b) => { return a + b; }, 0);

        textArea.value += `You bought ${list.join(', ')} for ${totalPrice.toFixed(2)}.\n`;
    });

    for (const botton of productButtons) {
        botton.addEventListener('click', function () {
            let paragraphs = this.parentElement.getElementsByTagName('p');

            let product = {};
            product.name = paragraphs[0].textContent;
            product.price = parseFloat(paragraphs[1].textContent.split(': ')[1]);

            products.push(product);

            textArea.value += `Added ${product.name} for ${product.price.toFixed(2)} to the cart.\n`;
        }
        );
    }
}

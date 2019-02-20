function makeCard(face, suit) {
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let suits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    };

    if (faces.indexOf(face) === -1 || !suits.hasOwnProperty(suit)) {
        let error = new Error('Invalid card face or suit!');
        error.card = face + suit;
        throw error;
    }

    let card = {
        face: face,
        suit: suits[suit],
        toString: function () {
            return this.face + this.suit;
        }
    };

    return card;
}


let card = '' + makeCard('1', 'C');

console.log(card);

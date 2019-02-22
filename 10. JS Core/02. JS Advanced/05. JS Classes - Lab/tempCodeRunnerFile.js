let result = (function () {
    let Suits = {
        SPADES: '♠',
        HEARTS: '♥',
        DIAMONDS: '♦',
        CLUBS: '♣'
    };
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(face) {
            if (faces.indexOf(face) === -1) {
                throw new Error('Invalid card face!');
            }

            this._face = face;
        }

        get suit() {
            return this.suit;
        }

        set suit(suit) {
            if (typeof suit !== 'string' || suit.length !== 1) {
                throw new Error('Invalid card suit!');
            }

            this._suit = suit;
        }
    }

    return {
        Suits: Suits,
        Card: Card
    };
})();

let Card = result.Card;
let Suits = result.Suits;

console.log(new Card("2", Suits.SPADES));


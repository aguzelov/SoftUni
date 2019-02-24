class Stringer {
    constructor(text, length) {
        this.innerString = text;
        this.text = this.innerString;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;

        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        let result = this.innerString;
        if (this.innerLength === 0) {
            result = '...';
        }

        if (this.innerLength < this.innerString.length) {
            result = this.innerString.substr(0, this.innerLength) + '...';
        }

        return result;
    }
}
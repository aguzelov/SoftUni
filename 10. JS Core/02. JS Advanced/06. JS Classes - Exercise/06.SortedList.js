class SorterList {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(element) {
        this.list.push(element);
        this.list.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (this._checkIndex(index)) {
            this.list.splice(index, 1);
            this.size--;
        }
    }

    get(index) {
        if (this._checkIndex(index)) {
            return this.list[index];
        }
    }

    _checkIndex(index) {
        if (index < 0 || index >= this.list.length) {
            return false;
        }

        return true;
    }
}
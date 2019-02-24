class Rat {
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }

    unite(other) {
        if (typeof other === typeof this) {
            this.unitedRats.push(other);
        }
    }

    getRats() {
        return this.unitedRats;
    }

    toString() {
        return `${this.name}\n${this.unitedRats.map(r => '##' + r.toString()).join('')}`;
    }
}
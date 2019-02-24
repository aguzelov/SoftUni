let result = (function () {
    return class Extensible {
        constructor() {
            Extensible._id = (Extensible._id || 0) + 1;
            this.id = Extensible._id - 1;
        }

        extend(obj) {
            for (const key in obj) {
                if (typeof obj[key] === 'function') {
                    Extensible.prototype[key] = obj[key];
                } else {
                    this[key] = obj[key];
                }


            }
        }
    };
})();
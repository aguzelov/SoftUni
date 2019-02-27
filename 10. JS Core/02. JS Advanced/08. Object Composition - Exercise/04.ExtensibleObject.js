let result = function () {
    return {
        extend: function (other) {
            for (const key in other) {
                if (other.hasOwnProperty(key)) {

                    if (typeof other[key] === "function") {
                        Object.setPrototypeOf(this, other);
                    } else {
                        this[key] = other[key];
                    }
                }
            }
        }
    };
};
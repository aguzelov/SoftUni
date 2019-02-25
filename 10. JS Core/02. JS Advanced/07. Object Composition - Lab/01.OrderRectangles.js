function solve(input) {
    let rectangleFactory = (function () {
        return function (width, height) {
            return {
                width,
                height,
                area: function () { return this.width * this.height; },
                compareTo: function (other) {
                    let result = other.area() - this.area();
                    return result || (other.width - this.width);
                }
            };
        };
    })();
    let rectangles = [];
    for (const [width, height] of input) {
        let rect = rectangleFactory(width, height);
        rectangles.push(rect);
    }

    rectangles.sort((a, b) => a.compareTo(b));

    return rectangles;
}

console.log(solve([[10, 5], [5, 12]]));


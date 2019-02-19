function solve() {
    return {
        add: function (v1, v2) {
            let x1 = v1[0];
            let y1 = v1[1];
            let x2 = v2[0];
            let y2 = v2[1];
            let result = [];
            result[0] = x1 + x2;
            result[1] = y1 + y2;
            return result;
        },
        multiply: function (v1, num) {
            let result = [];
            result[0] = v1[0] * num;
            result[1] = v1[1] * num;
            return result;
        },
        length: function (v1) {
            let x = v1[0];
            let y = v1[1];
            let result = Math.sqrt(x * x + y * y);
            return result;
        },
        dot: function (v1, v2) {
            let x1 = v1[0];
            let y1 = v1[1];
            let x2 = v2[0];
            let y2 = v2[1];
            let result = x1 * x2 + y1 * y2;
            return result;
        },
        cross: function (v1, v2) {
            let x1 = v1[0];
            let y1 = v1[1];
            let x2 = v2[0];
            let y2 = v2[1];
            let result = x1 * y2 - y1 * x2;
            return result;
        }
    };
}


let result = solve();

console.log(result.dot([2, 3], [2, -1]));

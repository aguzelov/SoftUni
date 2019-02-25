function solve() {
    return (function () {
        let selector1;
        let selector2;
        let resultSelector;

        return {
            init: (s1, s2, result) => {
                selector1 = s1;
                selector2 = s2;
                resultSelector = result;
            },
            add: () => {
                let value1 = +document.getElementById(selector1).value;
                let value2 = +document.getElementById(selector2).value;
                document.getElementById(resultSelector).textContent = value1 + value2;
            },
            subtract: () => {
                let value1 = +document.getElementById(selector1).value;
                let value2 = +document.getElementById(selector2).value;

                document.getElementById(resultSelector).textContent = value2 - value1;
            }
        };
    })();
}

let obj = solve();
obj.init("#num1", "#num2", '#result');
obj.add();
obj.subtract();
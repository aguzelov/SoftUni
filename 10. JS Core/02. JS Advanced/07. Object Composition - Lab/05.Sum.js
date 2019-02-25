function solve() {
    return (function () {
        let selector1;
        let selector2;
        let resultSelector;

        return {
            init: (s1, s2, result) => {
                selector1 = s1.slice(1);
                selector2 = s2.slice(1);
                resultSelector = result.slice(1);
            },
            add: () => {
                let value1 = +document.getElementById(selector1).value;
                let value2 = +document.getElementById(selector2).value;
                document.getElementById(resultSelector).value = value1 + value2;
            },
            subtract: () => {
                let value1 = +document.getElementById(selector1).value;
                let value2 = +document.getElementById(selector2).value;

                document.getElementById(resultSelector).value = value1 - value2;
            }
        };
    })();
}

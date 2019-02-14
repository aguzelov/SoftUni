function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2, 2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}


function currencyFormat(formatter) {
    return (value) => {
        return formatter(',', '$', true, value);
    };
}

let f = currencyFormat(currencyFormatter);

console.log(f(10));

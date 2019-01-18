function solve(amountOfCouns, coinValues) {
    coinValues.sort(function (a, b) { return b - a });

    let convertedCoins = [];

    for (let coin of coinValues) {
        while (amountOfCouns >= coin) {
            convertedCoins.push(coin);
            amountOfCouns -= coin;
        }
    }

    console.log(convertedCoins.join(', '));
}

solve(57, [25, 10, 5, 1]);
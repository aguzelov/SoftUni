function solve(input) {

    let perfectNumbers = [];

    var divisors = n => [...Array(n + 1).keys()]
        .slice(1)
        .reduce((s, a) => s + (!(n % a) && a), 0);

    for (let num of input) {
        let sum = divisors(num);

        if (sum / 2 === num) {
            perfectNumbers.push(num);
        }
    }

    console.log(perfectNumbers.length === 0 ? 'No perfect number' : perfectNumbers.join(', '));
}

solve([5, 6, 28]);
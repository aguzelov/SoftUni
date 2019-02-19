function solve(...input) {
    let counter = {
    };

    for (const arg of input) {
        console.log(`${typeof (arg)}: ${arg}`);

        if (counter.hasOwnProperty(typeof (arg))) {
            counter[typeof (arg)] += 1;
        } else {
            counter[typeof (arg)] = 1;
        }

    }
    let keys = Object.keys(counter).sort((a, b) => counter[b] - counter[a]);

    for (const property of keys) {
        console.log(`${property} = ${counter[property]}`);
    }
}

solve(42, 'cat', 15, 'kitten', 'tomcat');
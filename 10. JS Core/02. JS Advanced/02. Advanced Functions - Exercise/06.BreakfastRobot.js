function solve() {
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        coke: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        omelet: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        cheverme: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    };

    let instructions = {
        restock: (microlement, quantity) => {
            if (stock.hasOwnProperty(microlement)) {
                stock[microlement] += +quantity;
            } else {
                stock[microlement] = +quantity;
            }

            return 'Success';
        },
        prepare: (recipeToPrepare, quantity) => {
            let recipe = recipes[recipeToPrepare];

            let microelements = Object.keys(recipe);

            for (const element of microelements) {
                if (!stock.hasOwnProperty(element)) {
                    return `Error: not enough ${element} in stock`;
                }

                if ((recipe[element] * quantity) > stock[element]) {
                    return `Error: not enough ${element} in stock`;
                }
            }

            for (const element of microelements) {
                let neededQuantity = recipe[element] * quantity;
                stock[element] -= neededQuantity;
            }

            return 'Success';
        },
        report: () => {
            return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`;
        }
    };

    return (input) => {
        let instructionTokens = input.split(' ');
        let instruction = instructionTokens[0];

        if (instruction === 'report') {
            return instructions[instruction]();
        } else {
            let param = instructionTokens[1];
            let quantity = instructionTokens[2];
            return instructions[instruction](param, quantity);
        }
    };
}

let robot = solve();
console.log(robot('restock carbohydrate 10'));
console.log(robot('restock flavour 10'));
console.log(robot('prepare apple 1'));
console.log(robot('restock fat 10'));
console.log(robot('prepare burger 1'));
// console.log(robot('restock fat 10'));
// console.log(robot('prepare cheverme 1'));
// console.log(robot('restock flavour 10'));
// console.log(robot('prepare cheverme 1'));
console.log(robot('report'));

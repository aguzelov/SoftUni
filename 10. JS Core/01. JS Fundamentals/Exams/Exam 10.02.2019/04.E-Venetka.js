function solve(input) {

    let mostProfit = checkProfit(input);
    console.log(`${mostProfit.town} is most profitable - ${mostProfit.profit} BGN`);

    let mostDriven = checkMostDriven(input, mostProfit.town);
    console.log(`Most driven model: ${mostDriven.model}`);

    let groupedByTowns = groupeByTownCarNumber(input, mostDriven.model);

    printGroupedTowns(groupedByTowns);


    function checkProfit(input) {
        let arr = [];
        for (const car of input) {
            if (includeCar(arr, car)) {
                let indexOfCar = arr.map(function (e) { return e.town; }).indexOf(car.town);
                arr[indexOfCar].count++;
                arr[indexOfCar].profit += car.price;
            } else {
                let obj = {
                    'town': car.town,
                    'profit': car.price,
                    'count': 1
                };
                arr.push(obj);
            }
        }

        arr.sort((a, b) => {
            if (a.profit > b.profit) {
                return -1;
            }

            if (a.profit < b.profit) {
                return 1;
            }

            if (a.count > b.count) {
                return -1;
            }

            if (a.count < b.count) {
                return 1;
            }

            if (a.town < b.town) {
                return -1;
            }

            if (a.town > b.town) {
                return 1;
            }

            return 0;
        });
        return arr[0];
    }

    function checkMostDriven(input, town) {
        let arr = [];
        for (const car of input) {
            if (car.town !== town) {
                continue;
            }

            if (includeModel(arr, car)) {
                let indexOfCar = arr.map(function (e) { return e.model; }).indexOf(car.model);
                arr[indexOfCar].model = car.model;
                arr[indexOfCar].price += car.price;
            } else {
                let obj = {
                    'town': car.town,
                    'model': car.model,
                    'price': car.price
                };
                arr.push(obj);
            }
        }

        arr.sort((a, b) => {
            if (a.count > b.count) {
                return -1;
            }

            if (a.count < b.count) {
                return 1;
            }

            if (a.price > b.price) {
                return -1;
            }

            if (a.price < b.price) {
                return 1;
            }

            if (a.model < b.model) {
                return -1;
            }

            if (a.model > b.model) {
                return 1;
            }

            return 0;
        });
        return arr[0];
    }

    function includeCar(arr, car) {
        for (const c of arr) {
            if (c.town === car.town) {
                return true;
            }
        }
        return false;
    }

    function includeModel(arr, car) {
        for (const c of arr) {
            if (c.model === car.model) {
                return true;
            }
        }
        return false;
    }

    function groupeByTownCarNumber(cars, model) {
        groupByTown = cars.reduce(function (r, a) {

            r[a.town] = r[a.town] || [];
            r[a.town].push(a);
            return r;
        }, Object.create(null));

        let arr = [];
        for (const car of cars) {
            if (car.model !== model) {
                continue;
            }

            if (includeCar(arr, car)) {
                let indexOfCar = arr.map(function (e) { return e.town; }).indexOf(car.town);
                arr[indexOfCar].registrations.push(car.regNumber);
            } else {
                let obj = [];
                obj.town = car.town;
                obj.registrations = [];
                obj.registrations.push(car.regNumber);
                arr.push(obj);
            }

        }

        arr.sort((a, b) => {
            if (a.town < b.town) {
                return -1;
            }

            if (a.town > b.town) {
                return 1;
            }
        });

        return arr;
    }

    function printGroupedTowns(arr) {
        for (const row of arr) {
            let town = row.town;

            let registrations = row.registrations.sort((a, b) => {
                if (a < b) {
                    return -1;
                }

                if (a > b) {
                    return 1;
                }

                return 0;
            });

            console.log(`${town}: ${registrations.join(', ')}`);
        }
    }
}

solve([{ model: 'BMW', regNumber: 'B1234SM', town: 'Varna', price: 2 },
{ model: 'BMW', regNumber: 'C5959CZ', town: 'Sofia', price: 8 },
{ model: 'Tesla', regNumber: 'NIKOLA', town: 'Burgas', price: 9 },
{ model: 'BMW', regNumber: 'A3423SM', town: 'Varna', price: 3 },
{ model: 'Lada', regNumber: 'SJSCA', town: 'Sofia', price: 3 }]
);
function solve(order) {
    let model = order.model;
    let power = order.power;
    let carriage = order.carriage;
    let color = order.color;
    let wheelSize = order.wheelsize;

    function engineFactory(power) {
        let engines = {
            small: { power: 90, volume: 1800 },
            normal: { power: 120, volume: 2400 },
            monster: { power: 200, volume: 3500 }
        };

        return (function () {
            let engineTypes = Object.keys(engines);

            for (let index = engineTypes.length - 1; index >= 0; index--) {
                let key = engineTypes[index];

                if (power === engines[key].power) {
                    return engines[key];
                }

                if (power > engines[key].power) {
                    return engines[engineTypes[index + 1]];
                }
            }

            return engines[engineTypes[0]];
        })();
    }

    function carriageFactory(carriage, color) {
        let carriages = {
            hatchback: {
                type: 'hatchback',
                color: color
            },
            coupe: {
                type: 'coupe',
                color: color
            }
        };

        return carriages[carriage.toLowerCase()];
    }

    function wheelsFactory(size) {
        let wheels = [];

        let workingSize = size;

        while (workingSize % 2 === 0) {
            workingSize--;
        }

        return Array(4).fill(workingSize);
    }

    return {
        model: model,
        engine: engineFactory(power),
        carriage: carriageFactory(carriage, color),
        wheels: wheelsFactory(wheelSize)
    };
}
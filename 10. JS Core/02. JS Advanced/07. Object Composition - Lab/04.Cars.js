function solve(input) {

    let carFactory = (function () {
        let cars = {};
        return {
            create: (name) => {
                cars[name] = {};
            },
            inherits: (child, parent) => {
                cars[child] = Object.create(cars[parent]);
            },
            set: ([name, key, value]) => {

                cars[name][key] = value;
            },
            print: (name) => {
                let result = [];
                for (const key in cars[name]) {
                    result.push(`${key}:${cars[name][key]}`);
                }

                console.log(result.join(', '));
            }
        };
    })();

    for (const commandLine of input) {
        let commandTokens = commandLine.split(' ');
        let command = commandTokens[0];
        let args = commandTokens.slice(1);

        if (command === 'create') {
            carFactory.create(args[0]);

            if (args.length > 1) {
                carFactory.inherits(args[0], args[2]);
            }
        } else {
            carFactory[command](args);
        }
    }
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);
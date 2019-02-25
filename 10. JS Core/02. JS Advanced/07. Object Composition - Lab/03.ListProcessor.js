function solve(input) {
    let processor = (function () {
        let list = [];
        return {
            add: (text) => {
                list.push(text);
            },
            remove: (text) => {
                list = list.filter(s => s !== text);
            },
            print: () => {
                console.log(list.join(','));
            }
        };
    })();

    for (const commandString of input) {
        let commandTokens = commandString.split(' ');
        let command = commandTokens[0];
        let text = commandTokens[1];

        processor[command](text);
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
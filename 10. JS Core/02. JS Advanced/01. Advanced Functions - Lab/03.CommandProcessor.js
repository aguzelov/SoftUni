function commandProcessor(commandsArr) {
    let text = '';

    let commands = {
        append: (str) => text = text + str,
        removeStart: (n) => text = text.slice(n),
        removeEnd: (n) => text = text.slice(0, n * -1),
        print: () => console.log(text)
    };

    for (const commandStr of commandsArr) {
        let commandTokens = commandStr.split(' ');
        let command = commandTokens[0];

        if (commandTokens.length > 1) {
            commands[command](commandTokens[1]);
        } else {
            commands[command]();
        }
    }
}

commandProcessor(['append 123',
    'append 45',
    'removeStart 2',
    'removeEnd 1',
    'print']

);
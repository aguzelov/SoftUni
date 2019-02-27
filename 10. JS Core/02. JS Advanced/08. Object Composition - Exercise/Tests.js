function solve(text, ...args) {
    let regex = new RegExp('{\\d}', 'gm');
    let matches = text.match(regex);

    for (let index = 0; index < matches.length; index++) {
        let currentMatch = matches[index];
        let currentParam = args[index];

        if (index < args.length) {
            text = text.replace(currentMatch, currentParam);
        }
    }
}

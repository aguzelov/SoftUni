function solve(matrixInput, commmandInput) {

    let stringifiedMatrix = JSON.stringify(matrixInput);
    let matrix = JSON.parse(stringifiedMatrix);
    let header = matrix[0];

    let table = [];

    for (let index = 1; index < matrix.length; index++) {
        const row = matrix[index];

        let obj = toObj(header, row);
        table.push(obj);
    }

    let commandTokens = commmandInput.split(' ');
    let command = commandTokens[0];
    let commandParams = commandTokens.slice(1);


    let commands = {
        'filter': filter,
        'sort': sort,
        'hide': hide
    };

    let result = commands[command](header, table, commandParams);
    console.log(result);

    function toObj(keys, values) {
        let obj = {};
        for (let index = 0; index < keys.length; index++) {
            let key = keys[index];
            let value = values[index];

            obj[key] = value;
        }

        return obj;
    }

    function hide(header, table, columnArr) {
        let column = columnArr[0];
        let result = getHeader(header, column);

        for (const row of table) {
            delete row[column];

            let objValues = [];
            for (const key in row) {
                if (key === column) {
                    continue;
                }

                objValues.push(row[key]);
            }
            result += objValues.join(' | ') + '\n';
        }

        return result;
    }

    function sort(header, table, columnArr) {
        let column = columnArr[0];
        let result = getHeader(header);

        table.sort((a, b) => (a[column] > b[column]) ? 1 : ((b[column] > a[column]) ? -1 : 0));

        for (const value of table) {
            let objValues = [];
            for (const key in value) {
                objValues.push(value[key]);
            }
            result += objValues.join(' | ') + '\n';
        }

        return result;
    }

    function filter(header, table, columnArr) {
        let column = columnArr[0];
        let value = columnArr[1];

        let result = getHeader(header);

        for (const row of table) {
            if (row[column] === value) {
                let objValues = [];
                for (const key in row) {
                    objValues.push(row[key]);
                }
                result += objValues.join(' | ') + '\n';
            }

        }
        return result;
    }

    function getHeader(header, column) {
        let result = header.filter(h => h !== column).join(' | ') + '\n';

        return result;
    }

}

solve([['firstName', 'age', 'grade', 'course'],
['Peter', '25', '5.00', 'JS-Core'],
['George', '34', '6.00', 'Tech'],
['Marry', '28', '5.49', 'Ruby']],
    'filter firstName Marry'

);
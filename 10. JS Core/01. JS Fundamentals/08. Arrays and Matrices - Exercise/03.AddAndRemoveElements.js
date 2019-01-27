function solution(arr) {
    let commands = {
        'add': function (arr, num) {
            arr.push(num);
        },
        'remove': function (arr) {
            arr.pop();
        }
    };

    let num = 1;
    let array = [];
    for (let index = 0; index < arr.length; index++) {
        commands[arr[index]](array, num);
        num++;
    }

    console.log(array.length === 0 ? 'Empty' : array.join('\n'));
}


solution(['add',
    'add',
    'add',
    'add']
);
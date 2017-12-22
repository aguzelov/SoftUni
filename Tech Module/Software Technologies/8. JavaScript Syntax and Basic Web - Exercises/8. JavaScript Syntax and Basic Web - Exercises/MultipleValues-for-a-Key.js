function solution(arr) {
    let obj = {};

    for (let i = 0; i < arr.length - 1; i++) {
        let key = arr[i].split(" ")[0];
        let value = arr[i].split(" ")[1];

        if (obj.hasOwnProperty(key)) {
            obj[key].push(value);
        } else {
            obj[key] =[value];
        }
    }

    let key = arr[arr.length - 1];
    if (obj.hasOwnProperty(key)) {
        console.log(obj[key].join("\n"));
    } else {
        console.log("None");
    }
}

solution([
    "key value",
    "key eulav",
    "test tset",
    "key"
]);

console.log("");

solution([
    "3 test",
    "3 test1",
    "4 test2",
    "4 test3",
    "4 test5",
    "4"
]);

console.log("");

solution([
    "3 bla",
    "3 alb",
    "2"
]);
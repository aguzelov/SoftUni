function solution(arr) {
    let length = Number(arr[0]);

    let array = new Array(length).fill(0);

    for(let i = 1; i < arr.length; i++){
        let index = arr[i].split(" - ")[0];
        let number = arr[i].split(" - ")[1];
        array[index] = number;
    }


    array.forEach(p=> console.log(p));
}

solution([
    "3",
    "0 - 5",
    "1 - 6",
    "2 - 7"
]);

console.log("");

solution([
    "2",
    "0 - 5",
    "0 - 6",
    "0 - 7"
]);
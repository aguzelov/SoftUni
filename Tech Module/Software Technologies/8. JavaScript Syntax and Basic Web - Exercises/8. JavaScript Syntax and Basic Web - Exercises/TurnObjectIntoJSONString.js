function solution(arr) {

    let obj = {
        name: arr[0].split(" -> ")[1],
        surname: arr[1].split(" -> ")[1],
        age: Number(arr[2].split(" -> ")[1]),
        grade: Number(arr[3].split(" -> ")[1]),
        date: arr[4].split(" -> ")[1],
        town: arr[5].split(" -> ")[1],
    };


    console.log(JSON.stringify(obj));
}

solution([
    "name -> Angel",
    "surname -> Georgiev",
    "age -> 20",
    "grade -> 6.00",
    "date -> 23/05/1995",
    "town -> Sofia"
]);
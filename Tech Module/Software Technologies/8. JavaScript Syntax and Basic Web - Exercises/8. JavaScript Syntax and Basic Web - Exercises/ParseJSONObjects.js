function solution(arr) {
    for(let text of arr){
        let obj = JSON.parse(text);

        console.log("Name: " + obj["name"]);
        console.log("Age: " + obj["age"]);
        console.log("Date: " + obj["date"]);
    }
}

solution([
    '{"name":"Gosho","age":10,"date":"19/06/2005"}',
    '{"name":"Tosho","age":11,"date":"04/04/2005"}'
]);
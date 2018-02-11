function solution(arr) {
    let objArray = [];
    for (let element of arr) {
        element = element.split(" -> ");
        let name = element[0];
        let age = element[1];
        let grade = element[2];

        let obj = {name: name, age: age, grade: grade};
        objArray.push(obj);
    }

    for(let obj of objArray){
        console.log("Name: " + obj.name);
        console.log("Age: " + obj.age);
        console.log("Grade: " + obj.grade);
    }
}

solution([
    "Pesho -> 13 -> 6.00",
    "Ivan -> 12 -> 5.57",
    "Toni -> 13 -> 4.90",
]);
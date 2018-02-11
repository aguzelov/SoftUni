function solution(commands) {
    let array = [];

    for(let element of commands){
        let command = element.split(" ")[0];
        let argument = element.split(" ")[1];

        if(command === "add"){
            array.push(argument);
        }else if(command === "remove"){
            if(argument > array.length-1){
                continue;
            }
            array.splice(argument,1);
        }
    }

    console.log(array.join("\n"));
}

solution([
    "add 3",
    "add 5",
    "add 7"
]);

console.log("");

solution([
    "add 3",
    "add 5",
    "remove 2",
    "remove 0",
    "add 7"
]);
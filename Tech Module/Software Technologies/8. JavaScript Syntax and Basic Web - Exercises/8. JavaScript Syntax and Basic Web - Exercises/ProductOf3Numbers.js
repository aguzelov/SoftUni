function solution(arr) {
    arr = arr.map(Number);

    let countNegative = 0;
    for(let i = 0; i < arr.length; i++){
        if(arr[i] < 0){
            countNegative++;
        }else if(arr[i] === 0){
            return "Positive";
        }
    }

    if(countNegative % 2 === 0){
        return "Positive";
    }else{
        return "Negative";
    }
}

console.log(solution(["2", "3", "-1"]));
console.log(solution(["5", "4", "3"]));
console.log(solution(["-3", "-4", "5"]));
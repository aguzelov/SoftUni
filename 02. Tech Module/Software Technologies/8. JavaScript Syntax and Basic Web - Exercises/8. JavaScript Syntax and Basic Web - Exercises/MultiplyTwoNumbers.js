function solution(arr) {
    let firstNum = Number(arr[0]);
    let secondNum = Number(arr[1]);
    return firstNum * secondNum;
}

console.log(solution(["2", "3"]));
console.log(solution(["13", "13"]));
console.log(solution(["1", "2"]));
console.log(solution(["0", "50"]));
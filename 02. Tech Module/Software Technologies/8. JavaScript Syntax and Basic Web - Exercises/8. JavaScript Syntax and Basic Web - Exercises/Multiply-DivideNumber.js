function solution(arr) {
    let n = Number(arr[0]);
    let x = Number(arr[1]);

    if(x >= n){
        return n*x;
    }else{
        return n/x;
    }
}

console.log(solution(["2", "3"]));
console.log(solution(["13", "13"]));
console.log(solution(["3", "2"]));
console.log(solution(["144", "12"]));
function solution(arr) {
    let nums = arr.map(Number).sort((a,b) => b-a);

    let count = arr.length < 3 ? arr.length : 3;

    for(let i = 0; i < count; i++){
        console.log(nums[i]);
    }

}


let nums = ['10', '30', '15', '20', '50', '5'];
solution(nums)
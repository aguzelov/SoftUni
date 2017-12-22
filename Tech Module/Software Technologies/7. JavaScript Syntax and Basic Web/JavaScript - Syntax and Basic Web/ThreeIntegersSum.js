function solution([nums]) {
    let array = nums.split(' ');
    let a = Number(array[0]);
    let b = Number(array[1]);
    let c = Number(array[2]);

    if (a + b === c) {
        console.log(`${Math.min(a,b)} + ${Math.max(a,b)} = ${c}`);
    }else if (a + c === b) {
        console.log(`${Math.min(a,c)} + ${Math.max(a,c)} = ${b}`);
    }else if (b + c === a) {
        console.log(`${Math.min(c,b)} + ${Math.max(c,b)} = ${a}`);
    }else{
        console.log('No');
    }
}

solution('3 8 12');
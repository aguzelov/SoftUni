function solution(n) {
    n = Number(n);
    let result = '';

    for (let i = 1; i <= n; i++){
        if (isSymmetric(i.toString())){
            result += i + " ";
        }
    }

    function isSymmetric(str) {
        for (let i = 0; i < str.length / 2; i++){
            if (str[i] !== str[str.length - i - 1]){
                return false;
            }
        }
        return true;
    }

    console.log(result);
}

solution('12')
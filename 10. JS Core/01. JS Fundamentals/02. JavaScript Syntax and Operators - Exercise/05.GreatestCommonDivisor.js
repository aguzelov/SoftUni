function gcd(a, b){

    if (a === 0)
        return b;

    while (b !== 0) {
        if (a > b)
            a = a - b;
        else
            b = b - a;
    }

    console.log(a);
}

gcd(2154, 458);
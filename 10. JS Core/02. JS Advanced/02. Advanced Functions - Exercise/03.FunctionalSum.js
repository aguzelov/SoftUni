function add(num) {
    let sum = Array.prototype.reduce.call(arguments, function (l, r) {
        return l + r;
    }, 0);

    let ret = add.bind(null, sum);
    ret.add = ret;

    ret.value = ret.valueOf = Number.prototype.valueOf.bind(sum);
    ret.toString = Number.prototype.toString.bind(sum);

    return ret;
}

console.log(add(3)(3)(1).toString());


function calculator(firstNumber, secondNumber, operator){
    let math_it_up = {
        "+": function (x, y) { return x + y; },
        "-": function (x, y) { return x - y; },
        "*": function (x, y) { return x * y; },
        "/": function (x, y) { return x / y; },
        "**": function (x, y) { return x ** y; },
        "%": function (x, y) { return x % y;},
    };

 let result = math_it_up[operator](firstNumber, secondNumber);
 console.log(result);
}

calculator(3, 5.5, '*');
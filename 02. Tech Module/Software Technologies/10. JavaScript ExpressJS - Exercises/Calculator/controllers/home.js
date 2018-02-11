const Calculator = require('../models/Calculator');

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    indexPost: (req, res) =>{
        let calculatorBody = req.body;

        let calculatorParams = calculatorBody['calculator'];
        let calculator = Calculator;
        calculator.leftOperand = Number(calculatorParams.leftOperand);
        calculator.operator = calculatorParams.operator;
        calculator.rightOperand = Number(calculatorParams.rightOperand);

        let result;
        result = function () {
            let result = 0;

            switch (calculator.operator) {
                case "+":
                    result = calculator.leftOperand + calculator.rightOperand;
                    break;
                case "-":
                    result = calculator.leftOperand - calculator.rightOperand;
                    break;
                case "*":
                    result = calculator.leftOperand * calculator.rightOperand;
                    break;
                case "/":
                    result = calculator.leftOperand / calculator.rightOperand;
                    break;
            }
            return result;
        };

        res.render('home/index', {'calculator': calculator, 'result': result});
    }
};
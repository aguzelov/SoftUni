let assert = require('chai').assert;

function sum(arr) {
    let sum = 0;
    for (let num of arr)
        sum += Number(num);
    return sum;
}


describe('sum', function () {
    it('with array of numbers, should return correct sum', function () {
        let arr = [1, 2, 3];

        let result = 6;

        assert.equal(sum(arr), result, `Sum of all elements in ${arr} is not equal to ${result}`);
    });
    it('with array of string, should return correct sum', function () {
        let arr = ['1', '2', '3'];

        let result = 6;

        assert.equal(sum(arr), result, `Sum of all elements in ${arr} is not equal to ${result}`);
    });
    it('with array of non numbers, should return NaN', function () {
        let arr = ['aaa', '2', '3'];
        let result = sum(arr);
        let expect = NaN;

        assert.isNaN(result, `Must return ${expect}, but return ${result}`);
    });
});
let assert = require('chai').assert;

function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}
console.log(rgbToHexColor([], 250, 35));


// describe('rgbToHexColor', function () {
//     it('with three numbers in range of 0 to 255, should return color in hexadecimal', function () {
//         let red = 150;
//         let green = 250;
//         let blue = 35;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = '#96FA23';
//         let firstChar = result[0];

//         assert.equal(result.toUpperCase(), result, `${result} is not upper case`);
//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//         assert.equal(firstChar, '#', 'Result not starting with #');
//         assert.equal(result.length, 7, 'Result lenght in incorrect');
//     });
//     it('with first argument with different of number type, should return undefined', function () {
//         let red = '1';
//         let green = 2;
//         let blue = 3;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with first argument with value less than 0, should return undefined', function () {
//         let red = -0.1;
//         let green = 2;
//         let blue = 3;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with first argument with value bigger than 255, should return undefined', function () {
//         let red = 255.1;
//         let green = 2;
//         let blue = 3;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with second argument with different of number type, should return undefined', function () {
//         let red = 1;
//         let green = '2';
//         let blue = 3;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with second argument with value less than 0, should return undefined', function () {
//         let red = 1;
//         let green = -0.1;
//         let blue = 3;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with second argument with value bigger than 255, should return undefined', function () {
//         let red = 1;
//         let green = 255.1;
//         let blue = 3;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with third argument with different of number type, should return undefined', function () {
//         let red = 1;
//         let green = 2;
//         let blue = '3';

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with third argument with value less than 0, should return undefined', function () {
//         let red = 1;
//         let green = 2;
//         let blue = -1;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with third argument with value bigger than 255, should return undefined', function () {
//         let red = 1;
//         let green = 2;
//         let blue = 255.1;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = undefined;

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//     });
//     it('with three numbers in range of 0 to 255, should return color in hexadecimal', function () {
//         let red = 1;
//         let green = 2;
//         let blue = 3;

//         let result = rgbToHexColor(red, green, blue);
//         let expect = '#010203';
//         let firstChar = result[0];

//         assert.equal(result, expect, `${result} is not equal to ${expect}`);
//         assert.equal(firstChar, '#', 'Result not starting with #');
//         assert.equal(result.length, 7, 'Result lenght in incorrect');
//     });
// });
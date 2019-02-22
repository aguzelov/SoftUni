let StringBuilder = require('./07.StringBuilder');
let assert = require('chai').assert;

describe('StringBuilder', function () {
    let sb;
    beforeEach(function () {
        sb = new StringBuilder();
    });

    describe('prototype', function () {
        it('properties exist', function () {
            assert.isFunction(StringBuilder.prototype.append, `StringBuilder prototype does not contain append `);
            assert.isFunction(StringBuilder.prototype.prepend, `StringBuilder prototype does not contain prepend `);
            assert.isFunction(StringBuilder.prototype.insertAt, `StringBuilder prototype does not contain insertAt `);
            assert.isFunction(StringBuilder.prototype.remove, `StringBuilder prototype does not contain remove `);
            assert.isFunction(StringBuilder.prototype.toString, `StringBuilder prototype does not contain toString `);

        });
    });

    describe('constructor', function () {
        it('wich empty contstructor', function () {
            let result = sb.toString();

            assert.equal(result, '', `Must retrun empty string, but return ${result}`);
        });
        it('wich string arg', function () {
            let text = 'Text';

            let sb = new StringBuilder(text);
            let result = sb.toString();

            assert.equal(result, text, `Must return ${text}, but return ${result}`);
        });
        it('wich different type from string', function () {
            let text = [];


            assert.throw(() => { new StringBuilder(text); }, 'Argument must be string');
        });
    });

    describe('append', function () {
        it('wich no param', function () {
            assert.throw(() => { sb.append(); }, 'Argument must be string');
        });
        it('wich string arg', function () {
            let text = 'Text';

            sb.append(text);
            let result = sb.toString();

            assert.equal(result, text, `Must return ${text}, but return ${result}`);
        });
        it('wich multiple calls', function () {
            let text = 'Text';
            let testText = 'TEST';
            let expected = text + text + text + testText;

            sb.append(text);
            sb.append(text);
            sb.append(text);
            sb.append(testText);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich different type from string', function () {
            let text = [];

            assert.throw(() => { sb.append(text); }, 'Argument must be string');
        });
    });

    describe('prepend', function () {
        it('wich no param', function () {
            assert.throw(() => { sb.prepend(); }, 'Argument must be string');
        });
        it('wich string arg', function () {
            let text = 'Text';

            sb.prepend(text);
            let result = sb.toString();

            assert.equal(result, text, `Must return ${text}, but return ${result}`);
        });
        it('wich multiple calls', function () {
            let text = 'Text';
            let testText = 'TEST';
            let expected = testText + text + text + text;

            sb.prepend(text);
            sb.prepend(text);
            sb.prepend(text);
            sb.prepend(testText);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich different type from string', function () {
            let text = [];

            assert.throw(() => { sb.prepend(text); }, 'Argument must be string');
        });
    });

    describe('insertAt', function () {
        it('wich correct param char', function () {
            let text = 'Text';
            sb.append(text);

            let charToInsert = '-';
            let index = 1;

            let expected = 'T-ext';

            sb.insertAt(charToInsert, index);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich correct param string', function () {
            let text = 'Text';
            sb.append(text);

            let stringToInsert = '12345';
            let index = 1;

            let expected = 'T' + stringToInsert + 'ext';

            sb.insertAt(stringToInsert, index);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich multiple calls', function () {
            let text = 'Text';
            sb.append(text);
            let stringToInsert = '1234';
            let index = 1;

            let expected = 'T' + stringToInsert + stringToInsert + stringToInsert + stringToInsert + 'ext';

            sb.insertAt(stringToInsert, index);
            sb.insertAt(stringToInsert, index);
            sb.insertAt(stringToInsert, index);
            sb.insertAt(stringToInsert, index);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich negative index', function () {
            let text = 'Text';
            sb.append(text);
            let stringToInsert = '1234';
            let index = -2;

            let expected = 'Te' + stringToInsert + 'xt';



            sb.insertAt(stringToInsert, index);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich no param', function () {
            assert.throw(() => { sb.insertAt(); }, 'Argument must be string');
        });
        // it('wich one param', function () {
        //     let text = 'Text';

        //     assert.throw(() => { sb.insertAt(text); }, 'Argument must be string');
        // });
        it('wich different type from string', function () {
            let text = [];
            let index = 1;

            assert.throw(() => { sb.insertAt(text, index); }, 'Argument must be string');
        });
        // it('wich different type from number', function () {
        //     let text = 'Text';
        //     let index = '1';

        //     assert.throw(() => { sb.insertAt(text, index); }, 'Argument must be string');
        // });
    });

    describe('remove', function () {
        it('wich correct params', function () {
            let text = 'Text';
            sb.append(text);

            let startIndex = 0;
            let length = 1;

            let expected = 'ext';

            sb.remove(startIndex, length);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich multiple calls', function () {
            let text = 'Text';
            sb.append(text);
            let startIndex = 1;
            let length = 1;

            let expected = 'Tt';

            sb.remove(startIndex, length);
            sb.remove(startIndex, length);
            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich no param', function () {
            assert.throw(() => { sb.insertAt(); }, 'Argument must be string');
        });
    });

    describe('_stringArray', function () {
        it('wich empty contstructor', function () {
            let result = sb.toString();
            let stringArray = sb._stringArray;
            assert.equal(result, stringArray, `Must return ${stringArray}, but return ${result}`);
        });
        it('wich string arg', function () {
            let text = 'Text';
            sb.append(text);
            let expected = Array.from(text);

            let result = sb._stringArray;

            assert.deepEqual(result, expected, `Must return ${expected}, but return ${result}`);
        });
    });

    describe('complex', function () {
        it('wich all methods call', function () {
            let sb = new StringBuilder('hello');
            sb.append(', there');
            sb.prepend('User, ');
            sb.insertAt('woop', 5);
            let expected = 'User,woop hello, there';

            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
        it('wich all methods call', function () {
            let sb = new StringBuilder('hello');
            sb.append(', there');
            sb.prepend('User, ');
            sb.insertAt('woop', 5);
            sb.remove(6, 3);
            let expected = 'User,w hello, there';

            let result = sb.toString();

            assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
        });
    });
});


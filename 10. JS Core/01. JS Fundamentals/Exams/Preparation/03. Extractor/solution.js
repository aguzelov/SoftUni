function solve() {
    let inputElement = document.getElementById('input');
    let outputElement = document.getElementById('output');

    let button = document.querySelector('#exercise button');
    button.addEventListener('click', extract);

    function extract() {
        let inputText = inputElement.value;

        let patternAndText = getSplitedText(inputText);

        let matchedText = applyPattern(patternAndText);

        let cleanedText = replaceHash(matchedText);

        outputElement.value = cleanedText;
    }

    function replaceHash(text) {
        text = replaceAll(text, '#', ' ');
        return text;
    }

    function applyPattern(arr) {
        let pattern = '[' + arr[0] + ']';
        let text = arr[1];
        text = replaceAll(text, pattern, '');
        return text;
    }

    function replaceAll(text, search, replacement) {
        return text.replace(new RegExp(search, 'g'), replacement);
    }

    function getSplitedText(inputText) {
        let charArr = inputText.split('');
        let count = getNumber(charArr);
        let nCharsFromText = getNCharsFromText(charArr, count);
        let lastCart = getLastChar(nCharsFromText);

        let result = nCharsFromText.join('').split(lastCart);
        return result;
    }

    // extract starting number 
    function getNumber(text) {
        let nums = [];

        for (let i = 0; i < text.length; i++) {
            if (isNaN(parseInt(text[i], 10))) {
                break;
            }
            nums.push(text[i]);
        }

        for (let i = 0; i < nums.length; i++) {
            text.shift();
        }

        return parseInt(nums.join(''));
    }
    // get number count char from text
    function getNCharsFromText(text, count) {
        let tempArr = [];
        for (let i = 0; i < text.length && i < count; i++) {
            tempArr.push(text[i]);
        }

        return tempArr;
    }

    //get last character/split char
    function getLastChar(text) {
        let lastChar = text.pop();
        return lastChar;
    }
}
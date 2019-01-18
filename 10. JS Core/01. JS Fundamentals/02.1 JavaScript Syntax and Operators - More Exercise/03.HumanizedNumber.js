function solve(input) {
    let textArr = input.split(/[\s,.]+/);

    for (let element of textArr) {
        if (!isNaN(+element) && element !== '') {

            console.log(ordinal_suffix_of(+element));
        }
    }

    function ordinal_suffix_of(i) {
        var j = i % 10,
            k = i % 100;
        if (j == 1 && k != 11) {
            return i + "st";
        }
        if (j == 2 && k != 12) {
            return i + "nd";
        }
        if (j == 3 && k != 13) {
            return i + "rd";
        }
        return i + "th";
    }
}

solve('The school has 251 students. In each class there are 26 chairs, 13 desks and 1 board.');
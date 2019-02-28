function increment(selector) {
    let $elem = $(`${selector}`);

    let $textArea = $('<textarea></textarea>');
    $textArea.addClass('counter');
    $textArea.attr('disabled', 'disabled');
    $textArea.val(0);
    $elem.append($textArea);

    let $incrementBtn = $('<button></button>');
    $incrementBtn.addClass('btn');
    $incrementBtn.attr('id', 'incrementBtn');
    $incrementBtn.text('Increment');
    $elem.append($incrementBtn);

    let $addBtn = $('<button></button>');
    $addBtn.addClass('btn');
    $addBtn.attr('id', 'addBtn');
    $addBtn.text('Add');
    $elem.append($addBtn);

    let $resultsUl = $('<ul></ul>');
    $resultsUl.addClass('results');
    $elem.append($resultsUl);

    $incrementBtn.on('click', () => {
        $textArea.val(+$textArea.val() + 1);
    });

    $addBtn.on('click', () => {
        let $currentLi = $('<li></li>');
        $currentLi.text(+$textArea.val());
        $resultsUl.append($currentLi);
    });
}

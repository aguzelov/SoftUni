function addSticker() {
    let $titleElem = $('.title');
    let $textElem = $('.content');

    let title = $titleElem.val();
    let text = $textElem.val();

    if (title && text) {
        createSticker(title, text);

        resetInput($titleElem, $textElem);
    }

    function createSticker(title, text) {
        let $stickerList = $('#sticker-list');

        let $noteContentElem = $('<li>');
        $noteContentElem.addClass('note-content');

        let $closeBtn = $('<a>');
        $closeBtn.addClass('button');
        $closeBtn.text('x');
        $closeBtn.on('click', (e) => {
            $(e.target).parent().remove();
        });
        $noteContentElem.append($closeBtn);

        let $headerElem = $('<h2>');
        $headerElem.text(title);
        $noteContentElem.append($headerElem);

        $noteContentElem.append($('<hr>'));

        let $contentElem = $('<p>');
        $contentElem.text(text);
        $noteContentElem.append($contentElem);

        $stickerList.append($noteContentElem);
    }

    function resetInput($titleElem, $textElem) {
        $titleElem.val('');
        $textElem.val('');
    }
}
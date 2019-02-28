function attachEvents(e) {
    $('.button').on('click', (e) => {
        $('.button').removeClass('selected');
        $(e.target).addClass('selected');
    });
}
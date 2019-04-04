$(() => {
    monkeys.forEach(m => {
        let html = $(getHTML(m));
        html.find('button').on('click', () => {
            $(`#${m.id}`).css('display', 'block');
        });

        $('.monkeys').append(html);
    });
});

function getHTML(context) {
    let source = $('#monkey-template').html();
    let template = Handlebars.compile(source);
    let html = template(context);

    return html;
}
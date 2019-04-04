function attachEvents() {
    $('#btnLoadTowns').on('click', loadTowns);
}

function loadTowns() {
    let townsStr = $('#towns').val();
    let towns = townsStr.split(', ');

    towns.forEach(town => {
        let context = {
            town: town
        };
        let html = getHTML(context);

        $('#root').append(html);
    });
}

function getHTML(context) {
    let source = $('#towns-template').html();
    let template = Handlebars.compile(source);
    let html = template(context);

    return html;
}
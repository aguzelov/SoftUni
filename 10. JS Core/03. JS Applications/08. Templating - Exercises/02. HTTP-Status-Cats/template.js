$(() => {
    renderCatTemplate();

    function renderCatTemplate() {
        cats.forEach(c => {
            let html = $(getHTML(c));


            html.find('button').on('click', (e) => {
                if (e.target.textContent == 'Show status code') {
                    e.target.textContent = 'Hide status code';
                    html.find(`#${c.id}`).css('display', 'block');
                } else {
                    e.target.textContent = 'Show status code';
                    html.find(`#${c.id}`).css('display', 'none');
                }
            });

            $('#allCats').append(html);
        });
    }

    function getHTML(context) {
        let source = $('#cat-template').html();
        let template = Handlebars.compile(source);
        let html = template(context);

        return html;
    }
});
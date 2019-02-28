function initializeTable() {
    $('#createLink').on('click', (e) => {
        e.preventDefault();
        e.stopPropagation();

        let countryName = $('#newCountryText').val();
        let capitalName = $('#newCapitalText').val();

        $(e.target).parent().parent().parent().append(`<tr><td>${countryName}</td><td>${capitalName}</td><td><a>[Up]</a><a>[Down]</a><a>[Delete]</a></td></tr>`);

        $('tbody tr:last-child td:last-child').on('click', 'a', (e) => {
            let $row = $(e.target).parent().parent();

            if (e.target.textContent === '[Up]') {
                $row.insertBefore($row.prev());
            }
            if (e.target.textContent === '[Down]') {
                $row.insertAfter($row.next());
            }
            if (e.target.textContent === '[Delete]') {
                $row.remove();
            }

            displayCheck();

            e.preventDefault();
            e.stopPropagation();
        });

        displayCheck();
    });

    var clickEvent = document.createEvent('MouseEvents');
    clickEvent.initEvent('click', true, true);

    let initTable = [
        ['Bulgaria', 'Sofia'],
        ['Germany', 'Berlin'],
        ['Russia', 'Moscow']
    ];

    for (const row of initTable) {
        $('#newCountryText').val(`${row[0]}`);
        $('#newCapitalText').val(`${row[1]}`);
        $("#createLink").get(0).dispatchEvent(clickEvent);
    }


    function displayCheck() {
        let table = $('#countriesTable tr');

        for (const row of table) {
            let $row = $(row);
            if (isFirst($row)) {
                $row.find("a:contains('Up')").css('display', 'none');
            } else if (isLast($row)) {
                $row.find("a:contains('Down')").css('display', 'none');
            } else {
                $row.find("a:contains('Up')").css('display', '');
                $row.find("a:contains('Down')").css('display', '');
            }
        }
    }

    function isLast($row) {
        let lastRow = $('#countriesTable tr:last-child');
        let firstCol = $(lastRow).find('td:first-child');
        let lastRowCountryName = firstCol.text();

        return lastRowCountryName === $row.children()[0].textContent;
    }

    function isFirst($row) {
        let table = $('#countriesTable tr');
        let thirdRowFirstCol = $(table[2]).find('td:first-child');
        let topRowCountry = thirdRowFirstCol.text();

        return topRowCountry === $row.children()[0].textContent;
    }

    displayCheck();
}
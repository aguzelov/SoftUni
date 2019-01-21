function solve() {
    let buttonElement = document.getElementById('searchBtn');

    buttonElement.addEventListener('click', function () {

        clearOldSearchResult();

        let inputElement = document.getElementById('searchField');
        let searchText = inputElement.value;
        inputElement.value = '';

        let rows = document.querySelectorAll('#exercise table tbody tr');

        for (let row of rows) {
            let isContainText = isRowContainText(row, searchText);
            console.log(isContainText);

            if (isContainText) {
                row.classList.add('select');
            }
        }
    });

    function clearOldSearchResult() {
        let rows = document.querySelectorAll('#exercise table tbody tr.select');

        for (let row of rows) {
            row.classList.remove('select');
        }
    }

    function isRowContainText(row, searchText) {
        let rowData = row.getElementsByTagName('td');

        for (let data of rowData) {
            if (data.textContent.toLowerCase().match(searchText.toLowerCase())) {
                return true;
            }
        }
        return false;
    }
}
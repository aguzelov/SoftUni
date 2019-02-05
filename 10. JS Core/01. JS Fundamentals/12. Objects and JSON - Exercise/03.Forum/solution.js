function solve() {
    let submitButton = document.querySelector('#exercise form button');

    submitButton.addEventListener('click', getUserInput);

    let searchButton = document.querySelector('#exercise>button');

    searchButton.addEventListener('click', search);

    // search for user
    function search() {
        let searchInput = document.querySelector('#exercise>input');
        let tableBody = document.querySelector('#exercise table tbody');
        let rows = tableBody.querySelectorAll('tr');

        let searchToken = searchInput.value;

        for (const row of rows) {
            if (isContainsToken(row, searchToken)) {
                row.style.visibility = 'visible';
            } else {
                row.style.visibility = 'hidden';
            }
        }
    }

    function isContainsToken(row, token) {
        let data = row.getElementsByTagName('td');

        for (const td of data) {
            if (td.textContent.includes(token)) {
                return true;
            }
        }

        return false;
    }

    //get user date functions
    function getUserInput(e) {
        let userInfo = getUserInfo();
        userInfo.topics = getTopic();

        registerUser(userInfo);

        e.preventDefault();
    }

    function getUserInfo() {
        let userInfoInputs = document.querySelectorAll('.user-info input');
        let user = {};
        for (const userInfo of userInfoInputs) {
            user[userInfo.placeholder] = userInfo.value;
        }

        return user;
    }

    function getTopic() {
        let userTopicsInputs = document.querySelectorAll('.topics input');

        let topics = [];
        for (const checkbox of userTopicsInputs) {
            if (checkbox.checked) {
                topics.push(checkbox.value);
            }
        }

        return topics;
    }

    function registerUser(user) {
        let tableBody = document.querySelector('#exercise table tbody');

        let tableRow = document.createElement('tr');

        let usernameCol = document.createElement('td');
        usernameCol.textContent = user.username;
        tableRow.appendChild(usernameCol);

        let emailCol = document.createElement('td');
        emailCol.textContent = user.email;
        tableRow.appendChild(emailCol);

        let topicsCol = document.createElement('td');
        topicsCol.textContent = user.topics.join(' ');
        tableRow.appendChild(topicsCol);

        tableBody.appendChild(tableRow);
    }

}
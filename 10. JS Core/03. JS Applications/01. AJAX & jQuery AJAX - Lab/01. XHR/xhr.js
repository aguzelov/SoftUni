function loadRepos() {
    let req = new XMLHttpRequest();

    let url = 'https://api.github.com/users/testnakov/repos';
    req.open('GET', url, true);

    req.onreadystatechange = function () {
        if (req.readyState === 4 && req.status === 200) {
            document.getElementById('res').textContent = req.responseText;
        }
    };

    req.send();
}
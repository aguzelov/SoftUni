function loadRepos() {
    let $username = $('#username').val();

    let url = `https://api.github.com/users/${$username}/repos`;

    $.ajax({
        method: 'GET',
        url: url,
        success: onLoadReposSuccess
    });
}

function onLoadReposSuccess(data) {
    console.log(data);
    $('#repos').empty();

    data.forEach(r => {
        let $repo = $('<li>');

        let $repoLink = $('<a>');
        $repoLink.attr('href', r.html_url);
        $repoLink.text(r.full_name);

        $repo.append($repoLink);


        $('#repos').append($repo);
    });
}
function loadCommits() {
    let $username = $('#username').val();
    let $repo = $('#repo').val();

    getCommitsAsyn($username, $repo, displayCommits, displayError);
}

function getCommitsAsyn(username, repository, resolve, reject) {
    let url = `https://api.github.com/repos/${username}/${repository}/commits`;

    $.get(url)
        .then(resolve)
        .catch(reject);
}

function displayCommits(commits) {
    let $commitsList = $('#commits');

    commits.forEach((c) => {
        let $commit = $('<li>');
        let commitAuthorName = c.commit.author.name;
        let commitMessage = c.commit.message;

        $commit.text(`${commitAuthorName}: ${commitMessage}`);

        $commitsList.append($commit);
    });
}

function displayError(err) {
    let $commitsList = $('#commits');

    let $error = $('<li>');
    let errorStatus = err.status;
    let errorStatusText = err.statusText;

    $error.text(`Error: ${errorStatus} (${errorStatusText})`);

    $commitsList.append($error);
}


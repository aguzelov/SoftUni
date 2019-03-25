function attachEvents() {
    $('#submit').on('click', () => {
        submit();
    });

    $('#refresh').on('click', () => {
        refresh();
    });
}

//Submit
function submit() {
    let $author = $('#author').val();
    let $content = $('#content').val();

    if (!$author || !$content) {
        return;
    }

    let message = {
        author: $author,
        content: $content
    };

    request('POST', getURL(''), JSON.stringify(message))

    refresh();

    $('#author').val('');
    $('#content').val('');
}

//Refresh
function refresh() {
    request('GET', getURL(''), '', onRefreshSuccess);
}

function onRefreshSuccess(data) {
    let messages = Object.entries(data).map(m => `${m[1].author}: ${m[1].content}`);

    $('#messages').text(messages.join('\n'));
}



function request(method, url, data, onSuccess, onError) {
    $.ajax({
        method,
        url,
        data,
        success: onSuccess,
        error: onError
    });
}

function getURL(param) {
    let url = `https://messenger-a8261.firebaseio.com/messenger/${param}.json`;

    return url;
}
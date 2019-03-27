function attachEvents() {
    $('#btnLoadPosts').on('click', onLoadPostsClick);

    $('#btnViewPost').on('click', onViewPostClick);
}
//BEGIN Load posts 
function onLoadPostsClick() {
    getAsync('posts', addPostsToSelectMenu, catchError);
}

function addPostsToSelectMenu(posts) {
    posts.forEach(p => {
        $('#posts').append($("<option></option>")
            .attr("value", p._id)
            .text(p.title));
    });
}
//END Load posts

//BEGIN View post
function onViewPostClick() {
    let selectedPostId = $('#posts').find(":selected").val();
    getAsync(`posts/${selectedPostId}`, getPost, catchError);
}

function getPost(post) {
    getAsync(`comments/?query={"post_id":"${post._id}"}`, getComments, catchError);

    $('#post-title').text(post.title);
    $('#post-body').text(post.body);
}

function getComments(comments) {
    $('#post-comments').empty();
    comments.forEach(c => {
        $('#post-comments').append($(`<li>${c.text}</li>`));
    });
}

//END View post
function catchError(err) {
    console.log(err);
}

function getAsync(requestToken, resolve, reject) {
    let req = getRequestDetails(requestToken);

    $.ajax(req)
        .then(resolve)
        .catch(reject);
}

function getRequestDetails(token) {
    const kinveyAppId = 'kid_r1VJRSY_N';
    const serviceUrl = 'https://baas.kinvey.com/appdata/' + kinveyAppId;

    const kinveyUsernam = 'User';
    const kinveyPassword = 'user';
    const base64auth = btoa(kinveyUsernam + ":" + kinveyPassword);
    const authHeaders = { 'Authorization': 'Basic ' + base64auth };

    return {
        'url': serviceUrl + '/' + token,
        'headers': authHeaders
    };
}
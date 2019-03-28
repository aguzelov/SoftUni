function attachedEvents() {
    $('#load-books').on('click', loadBooks);
    $('#addBook').on('click', addBook);
    $('#updateBook').on('click', updateBook);
}

//BEGIN Load books
function loadBooks() {
    request.get(addBooksToContainer, onError);
}

function addBooksToContainer(books) {
    $('#books-container').empty();

    books.forEach(b => {
        appendBook(b);
    });
}

//END Load books
//BEGIN Add book
function addBook() {
    let title = $('#bookTitle').val();
    let author = $('#bookAuthor').val();
    let isbn = $('#bookIsbn').val();

    if (!title || !author || !isbn) {
        return;
    }

    let data = { title: title, author: author, isbn: isbn };
    console.log(data);

    request.post(JSON.stringify(data), appendBook, onError);
}

function appendBook(book) {
    let $book = $(`<div id="${book._id}" class="card">
    <div  class="card-body">
        <h5 class="card-title book-title">${book.title}</h5>
        <h6 class="card-subtitle book-author mb-2 text-muted">${book.author}</h6>
        <h6 class="card-subtitle book-isbn mb-2 text-muted">${book.isbn}</h6>
        <div class="btn-holder">
        <button type="button" class="btn btn-primary btn-sm">Delete</button>
        </div>
    </div>
</div>`);

    $book.on('click', updateUpdateBookForm);
    $book.find('button').on('click', deleteBook);

    $('#books-container').append($book);

    clearAddForm();
}

function clearAddForm() {
    $('#bookTitle').val('');
    $('#bookAuthor').val('');
    $('#bookIsbn').val('');
}

function updateUpdateBookForm(e) {
    e.preventDefault();
    e.stopPropagation();

    let $book = $(e.target).closest(".card");

    let id = $book.attr('id');
    let title = $book.find('.book-title').text();
    let author = $book.find('.book-author').text();
    let isbn = $book.find('.book-isbn').text();

    $('#updatebookId').text(id);
    $('#updatebookTitle').val(title);
    $('#updatebookAuthor').val(author);
    $('#updatebookIsbn').val(isbn);

    showUpdateForm();
}

//END Add book
//BEGIN Update book

function updateBook() {
    let id = $('#updatebookId').text();
    let title = $('#updatebookTitle').val();
    let author = $('#updatebookAuthor').val();
    let isbn = $('#updatebookIsbn').val();

    let book = { title, author, isbn };
    request.put(id, JSON.stringify(book), updateCurrentBookInList, onError);

    $('#updatebookId').text('');
    $('#updatebookTitle').val('');
    $('#updatebookAuthor').val('');
    $('#updatebookIsbn').val('');

    showAddForm();
}

function updateCurrentBookInList(book) {
    let $book = $(`#${book._id}`);
    $book.find('.book-title').text(book.title);
    $book.find('.book-author').text(book.author);
    $book.find('.book-isbn').text(book.isbn);
}

//END Update book
//BEGIN Delete book
function deleteBook(e) {
    e.preventDefault();
    e.stopPropagation();
    let $book = $(e.target).closest(".card");

    let id = $book.attr('id');
    let title = $book.find('.book-title').text();
    let author = $book.find('.book-author').text();
    let isbn = $book.find('.book-isbn').text();

    let book = { title, author, isbn };
    request.delete(id, JSON.stringify(book), removeBook, onError);

    function removeBook(deleteResult) {
        if (deleteResult.count > 0) {
            $book.remove();
        }
    }
}

//END Delete book

let request = function request() {
    let appId = 'kid_rJtq8_c_4';
    let headers = getAuthHeaders();

    function getAsync(resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/books`;

        $.ajax({
            url: url,
            method: 'GET',
            headers: headers
        })
            .then(resolve)
            .catch(reject);
    }

    function postAsync(data, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/books`;
        headers['Content-type'] = 'application/json';
        $.ajax({
            url: url,
            method: 'POST',
            headers: headers,
            data: data
        })
            .then(resolve)
            .catch(reject);
    }

    function updateAsync(id, data, resolve, reject) {
        const url = `https://baas.kinvey.com/appdata/${appId}/books/${id}`;
        headers['Content-type'] = 'application/json';

        $.ajax({
            url: url,
            method: 'PUT',
            headers: headers,
            data: data
        })
            .then(resolve)
            .catch(reject);
    }

    function deleteAsync(id, data, resolve, reject) {
        const url = `https://baas.kinvey.com/appdata/${appId}/books/${id}`;
        headers['Content-type'] = 'application/json';

        $.ajax({
            url: url,
            method: 'DELETE',
            headers: headers,
            data: data
        })
            .then(resolve)
            .catch(reject);
    }

    return {
        get: getAsync,
        post: postAsync,
        put: updateAsync,
        delete: deleteAsync
    };
}();

function onSuccess(data) {
    console.log(data);
}

function onError(err) {
    console.log(err);
}

function getAuthHeaders() {
    const kinveyUsername = 'User';
    const kinveyPassword = 'user';
    const base64auth = btoa(kinveyUsername + ":" + kinveyPassword);
    const authHeaders = { 'Authorization': 'Basic ' + base64auth };

    return authHeaders;
}

function showUpdateForm() {
    $('#add-form').hide();
    $('#update-form').show();
}

function showAddForm() {
    $('#add-form').show();
    $('#update-form').hide();
}
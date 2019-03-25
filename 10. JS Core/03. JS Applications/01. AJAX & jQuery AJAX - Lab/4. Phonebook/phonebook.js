
//Lead all phonebook contacts
$('#btnLoad').on('click', () => {
    let url = generateURL('');
    request('GET', url, '', onContactsLoadedSuccess);
});

function onContactsLoadedSuccess(data) {
    clearPhoneBook();

    for (const contact of Object.entries(data)) {
        let $contact = $('<li>');
        $contact.text(`${contact[1].Person}: ${contact[1].Phone}`);

        let $deleteButton = $('<button>Delete</button>');
        $deleteButton.attr('id', contact[0]);
        $deleteButton.on('click', deleteContact);

        $contact.append($deleteButton);

        $('#phonebook').append($contact);
    }
}

//Create new contact
$('#btnCreate').on('click', () => {
    let url = generateURL('');

    let $person = $('#person').val();
    let $phone = $('#phone').val();

    let contact = {
        Person: $person,
        Phone: $phone
    };

    request('POST', url, JSON.stringify(contact), onContactCreateSuccess);
    $('#btnLoad').click();
});

function onContactCreateSuccess(data) {
    let $person = $('#person').val('');
    let $phone = $('#phone').val('');

}

//Delete contact
function deleteContact(event) {
    let id = event.target.id;

    let url = generateURL(id);
    request('DELETE', url, '', onContactDeleteSuccess);
}

function onContactDeleteSuccess(data) {
    $('#btnLoad').click();
    console.log('delete result: ' + data);
}


function clearPhoneBook() {
    $('#phonebook').empty();
}

function request(method, url, data, onSuccess) {
    $.ajax({
        method: method,
        url: url,
        success: onSuccess,
        data: data
    });
}

function generateURL(param) {

    let url = `https://phonebook-6a5f8.firebaseio.com/${param}.json`;

    console.log('url: ' + url);

    return url;
}
function attachEvents() {
    $('#btnLoad').on('click', () => {
        getAllContacts();
    });

    $('#btnCreate').on('click', () => {
        createContact();
    });
}

//Lead all phonebook contacts
function getAllContacts() {
    let url = generateURL('');
    request('GET', url, '', onContactsLoadedSuccess);
}

function onContactsLoadedSuccess(data) {
    clearPhoneBook();


    for (const contact of Object.entries(data)) {
        let $contact = $('<li>');
        $contact.text(`${contact[1].person}: ${contact[1].phone} `);

        let $deleteButton = $('<button>Delete</button>');
        $deleteButton.attr('id', contact[0]);
        $deleteButton.on('click', deleteContact);

        $contact.append($deleteButton);

        $('#phonebook').append($contact);
    }
}

//Create new contact
function createContact() {
    let url = generateURL('');
    let $person = $('#person').val();
    let $phone = $('#phone').val();

    let contact = {
        person: $person,
        phone: $phone
    };

    request('POST', url, JSON.stringify(contact), onContactCreateSuccess);
}


function onContactCreateSuccess(data) {
    let $person = $('#person').val('');
    let $phone = $('#phone').val('');

    getAllContacts();
}

//Delete contact
function deleteContact(event) {
    let id = event.target.id;

    let url = generateURL('/' + id);
    request('DELETE', url, '', onContactDeleteSuccess);
}

function onContactDeleteSuccess() {
    getAllContacts();
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
    let url = `https://phonebook-nakov.firebaseio.com/phonebook${param}.json`;
    return url;
}
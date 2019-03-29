let lastID;

function loadStudents() {
    request.get(listStudents, onError);
}

function listStudents(students) {
    console.log(students);

    students.sort((a, b) => (a.ID > b.ID) ? 1 : ((b.ID > a.ID) ? -1 : 0));
    students.forEach(s => {
        listStudent(s);
    });
}

function listStudent(student) {
    let $table = $('#results');

    let $row = $(`<tr>
    <th>${student.ID}</th>
    <th>${student.FirstName}</th>
    <th>${student.LastName}</th>
    <th>${student.FacultyNumber}</th>
    <th>${student.Grade}</th>
</tr>`);

    $table.append($row);

    lastID = student.ID;
}


function addStudent() {
    let firstName = $('#first-name').val();
    let lastName = $('#last-name').val();
    let facultyNumber = $('#faculty-number').val();
    let grade = +$('#grade').val();

    let studentData = {
        ID: lastID === undefined ? 1 : lastID,
        FirstName: firstName,
        LastName: lastName,
        FacultyNumber: facultyNumber,
        Grade: grade
    };
    console.log(studentData);

    request.post(JSON.stringify(studentData), onSuccess, onError);
}


let request = function () {
    let appId = 'kid_BJXTsSi-e';
    let headers = getAuthHeaders();

    function getAsync(resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/students`;

        $.ajax({
            method: 'GET',
            url: url,
            headers: headers
        })
            .then(resolve)
            .catch(reject);
    }

    function postAsync(data, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/students`;
        headers['Content-type'] = 'application/json';

        $.ajax({
            method: 'POST',
            url: url,
            headers: headers,
            data: data
        })
            .then(resolve)
            .catch(reject);
    }

    return {
        get: getAsync,
        post: postAsync
    };
}();

function getAuthHeaders() {
    let username = 'guest';
    let password = 'guest';
    let base64auth = btoa(username + ':' + password);
    let header = { 'Authorization': `Basic ${base64auth}` };

    return header;
}

function onSuccess(data) {
    console.log(data);
}

function onError(err) {
    console.log(err);
}
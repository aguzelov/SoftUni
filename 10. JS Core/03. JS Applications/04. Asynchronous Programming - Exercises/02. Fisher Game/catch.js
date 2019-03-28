function attachEvents() {
    $('.load').on('click', loadItems);
    $('.add').on('click', addItem);
}

//BEGIN Load items
function loadItems() {
    $('#catches').empty();
    request.get(listCatches, onError);
}

function listCatches(catches) {
    catches.forEach(c => {
        listCatch(c._id, c.angler, c.weight, c.species, c.location, c.bait, c.captureTime);
    });
}

function listCatch(id, angler, weight, species, location, bait, captureTime) {
    let $catchInfoBlock = $(`<div class="catch" data-id="${id}">
<label>Angler</label>
<input type="text" class="angler" value="${angler}"/>
<label>Weight</label>
<input type="number" class="weight" value="${weight}"/>
<label>Species</label>
<input type="text" class="species" value="${species}"/>
<label>Location</label>
<input type="text" class="location" value="${location}"/>
<label>Bait</label>
<input type="text" class="bait" value="${bait}"/>
<label>Capture Time</label>
<input type="number" class="captureTime" value="${captureTime}"/>
<button class="update">Update</button>
<button class="delete">Delete</button>
</div>`);

    $($catchInfoBlock).children('.update').on('click', updateItem);
    $($catchInfoBlock).children('.delete').on('click', deleteItem);

    $('#catches').append($catchInfoBlock);
}


//END Load items
//BEGIN Add item
function addItem() {
    let $addForm = $('#addForm');
    let angler = $addForm.children('.angler').val();
    let weight = +$addForm.children('.weight').val();
    let species = $addForm.children('.species').val();
    let location = $addForm.children('.location').val();
    let bait = $addForm.children('.bait').val();
    let captureTime = +$addForm.children('.captureTime').val();

    let data = { "angler": angler, "weight": weight, "species": species, "location": location, "bait": bait, "captureTime": captureTime };

    request.post(JSON.stringify(data), onSucced, onError);
}

//END Add item
//BEGIN Update item

function updateItem(e) {
    let $selectedCatch = $(e.target);
    let $parent = $selectedCatch.parent();
    let id = $parent.attr("data-id");
    let angler = $parent.children('.angler').val();
    let weight = +$parent.children('.weight').val();
    let species = $parent.children('.species').val();
    let location = $parent.children('.location').val();
    let bait = $parent.children('.bait').val();
    let captureTime = +$parent.children('.captureTime').val();

    let data = { "angler": angler, "weight": weight, "species": species, "location": location, "bait": bait, "captureTime": captureTime };
    request.update(id, JSON.stringify(data), onSucced, onError);
}

//END Update item
//BEGIN Delete item

function deleteItem(e) {
    let $selectedCatch = $(e.target);
    let $parent = $selectedCatch.parent();
    let id = $parent.attr("data-id");
    request.delete(id, onSucced, onError);
}

//END Delete item
//

let request = function request() {
    let appId = 'kid_ry1w9f5_4';
    let headers = getAuthHeaders();

    function getAsync(resolve, reject) {
        const serviceUrl = `https://baas.kinvey.com/appdata/${appId}/biggestCatches`;

        $.ajax({
            url: serviceUrl,
            method: 'GET',
            headers: headers
        })
            .then(resolve)
            .catch(reject);
    }

    function postAsync(data, resolve, reject) {
        const serviceUrl = `https://baas.kinvey.com/appdata/${appId}/biggestCatches`;
        headers['Content-type'] = 'application/json';

        $.ajax({
            url: serviceUrl,
            method: 'POST',
            headers: headers,
            data: data
        })
            .then(resolve)
            .catch(reject);
    }

    function updateAsync(id, data, resolve, reject) {
        const serviceUrl = `https://baas.kinvey.com/appdata/${appId}/biggestCatches/${id}`;
        headers['Content-type'] = 'application/json';

        $.ajax({
            url: serviceUrl,
            method: 'PUT',
            headers: headers,
            data: data
        })
            .then(resolve)
            .catch(reject);
    }

    function deleteAsync(id, resolve, reject) {
        const serviceUrl = `https://baas.kinvey.com/appdata/${appId}/biggestCatches/${id}`;
        headers['Content-type'] = 'application/json';

        $.ajax({
            url: serviceUrl,
            method: 'DELETE',
            headers: headers
        })
            .then(resolve)
            .catch(reject);
    }

    return {
        get: getAsync,
        post: postAsync,
        update: updateAsync,
        delete: deleteAsync
    };
}();


function onSucced(data) {
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
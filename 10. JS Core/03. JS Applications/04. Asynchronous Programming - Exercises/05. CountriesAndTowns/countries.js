function attachEvents() {
    $('#list-countries-btn').on('click', getAllCountries);
    $('#add-country-btn').on('click', addCountry);
}
//BEGIN Countries
function addCountry() {
    let name = $('#add-country-form').find('input').val();
    $('#add-country-form').find('input').val('');

    let country = {
        name: name
    };

    request.post('Country', JSON.stringify(country), getAllCountries, onError);
}

function getAllCountries() {
    $('#countries-list').empty();
    request.get('Country', '', listCountries, onerror);
}

function listCountries(countries) {
    countries.forEach((c) => {
        listCountry(c);
    });
}

function listCountry(c) {
    let $country = $(`<div>
    <div id="${c._id}" class="country">
    <h3>${c.name}</h3>
    <div class="country-btns">
    <button class="edit-btn" type="button">Edit</button>
    <button class="delete-btn"  type="button">Delete</button>
    <button class="add-town-btn" type="button">Add Town</button>
    <button class="show-towns-btn" type="button">Show Towns</button>    
    </div>
    </div>
    <div class="country-edit">
                            <label>Name</label>
                            <input type="text" >
                            <br>
                            <br>
                            <button class="edit-btn2" type="button">Edit</button>
                        </div>
                        <div class="country-delete">
                                <label>Name</label>
                                <input type="text" >
                                <br>
                                <br>
                                <button class="delete-btn2" type="button">Delete</button>
                            </div>
                            <div class="add-town">
                            <label>Name</label>
                            <input type="text" >
                            <br>
                            <br>
                            <button class="add-town-btn2" type="button">Add</button>
                        </div>
                            <div class="towns-list">
                                <div>
                                    <h5>town</h5>
                                    <button class="edit-town-btn" type="button">Edit</button>
                                    <button class="delete-town-btn"  type="button">Delete</button>
                                </div>
                                </div>
</div>`);

    $country.find('.edit-btn').on('click', () => {
        editCountry(c._id);
    });
    $country.find('.delete-btn').on('click', () => {
        deleteCountry(c._id);
    });
    $country.find('.add-town-btn').on('click', () => {
        addTownInCountry(c._id, c.name);

    });
    $country.find('.show-towns-btn').on('click', () => {
        getAllTownsByCountryId(c._id, c.name);
    });

    $('#countries-list').append($country);
}

function addTownInCountry(CountryId, CountryName) {
    let $country = $(`#${CountryId}`);

    let $parent = $country.parent();
    let $addTown = $parent.find('.add-town');
    showHideElement($addTown);

    $addTown.find('.add-town-btn2').on('click', () => {
        let name = $addTown.find('input').val();
        $addTown.find('input').val('');

        let town = {
            country: CountryName,
            name: name
        };

        request.post('Town', JSON.stringify(town), () => {
            getAllTownsByCountryId(CountryId, CountryName);
            showHideElement($addTown);
        }, onError);
    });
}

function getAllTownsByCountryId(id, name) {
    let $townList = $(`#${id}`).parent().find('.towns-list');
    $townList.empty();
    $townList.hide();
    let query = `/?query={"country": "${name}"}`;
    request.get('Town', query, listAllTowns, onError);

    function listAllTowns(towns) {
        showHideElement($townList);

        towns.forEach(t => {
            let $town = $(`<div id="${t._id}">
            <h5>${t.name}</h5>
            <button class="edit-town-btn" type="button">Edit</button>
            <button class="delete-town-btn"  type="button">Delete</button>
        </div>`);

            $town.find('.edit-town-btn').on('click', () => {
                editTown(t._id, t.country);
            });
            $town.find('.delete-town-btn').on('click', () => {
                deleteTown(t._id);
            });

            $townList.append($town);
            showHideElement($town);
        });
    }
}

function editTown(id, country) {
    let $town = $(`#${id}`);
    let oldTownName = $town.find('h5').text();
    $town.find('h5').remove();

    $town.prepend($(`<input type="text" value="${oldTownName}">`));
    $town.find('.edit-town-btn').off('click');
    $town.find('.edit-town-btn').on('click', () => {
        let townName = $town.find('input').val();
        let town = {
            name: townName,
            country: country
        };
        request.put('Town', id, JSON.stringify(town), (town) => {
            $town.find('input').remove();
            $town.prepend($(`<h5>${town.name}</h5>`));

            $town.find('.edit-town-btn').off('click');
            $town.find('.edit-town-btn').on('click', () => {
                editTown(id, country);
            });
        }, onError);
    });
}

function deleteTown(id) {
    request.delete('Town', id, deleteCurrentTown, onError);

    function deleteCurrentTown(count) {
        console.log($(`#${id}`));

        $(`#${id}`).remove();
    }
}

function editCountry(id) {
    let $country = $(`#${id}`);
    let countryName = $country.find('h3').text();

    let $parent = $country.parent();
    let $countryEdit = $parent.find('.country-edit');

    console.log($countryEdit);
    showHideElement($countryEdit);

    $countryEdit.find('input').val(countryName);

    $countryEdit.find('.edit-btn2').on('click', () => {
        let newName = $countryEdit.find('input').val();

        let country = {
            name: newName
        };

        request.put('Country', id, JSON.stringify(country), changeCurrentCountryName, onError);
    });

    function changeCurrentCountryName(country) {
        $country.find('h3').text(`${country.name}`);

        showHideElement($countryEdit);
    }
}

function deleteCountry(id) {
    let $country = $(`#${id}`);
    let countryName = $country.find('h3').text();

    let $parent = $country.parent();
    let $countryDelete = $parent.find('.country-delete');

    showHideElement($countryDelete);

    $countryDelete.find('input').val(countryName);
    $countryDelete.find('input').prop('disabled', true);

    $countryDelete.find('.delete-btn2').on('click', () => {
        request.delete('Country', id, removeCurrentCountryName, onError);
    });

    function removeCurrentCountryName(country) {
        let $country = $(`#${id}`);
        $country.parent().remove();
        showHideElement($countryDelete);
    }
}

//END Countries

let request = (function () {
    let appId = 'kid_H1YP1uT_N';
    let headers = getAuthHeader();

    function getAsync(pathToken, query, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/${pathToken}${query}`;
        console.log(url);

        $.ajax({
                method: 'GET',
                url: url,
                headers: headers
            })
            .then(resolve)
            .catch(reject);
    }

    function postAsync(pathToken, data, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/${pathToken}`;
        headers['Content-Type'] = 'application/json';

        $.ajax({
                method: 'POST',
                url: url,
                headers: headers,
                data: data
            })
            .then(resolve)
            .catch(reject);
    }

    function putAsync(pathToken, id, data, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/${pathToken}/${id}`;
        headers['Content-Type'] = 'application/json';

        $.ajax({
                method: 'PUT',
                url: url,
                headers: headers,
                data: data
            })
            .then(resolve)
            .catch(reject);
    }

    function patchAsync(pathToken, id, data, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/${pathToken}/${id}`;
        headers['Content-Type'] = 'application/json';

        $.ajax({
                method: 'PATCH',
                url: url,
                headers: headers,
                data: data
            })
            .then(resolve)
            .catch(reject);
    }

    function deleteAsync(pathToken, id, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/${pathToken}/${id}`;

        $.ajax({
                method: 'DELETE',
                url: url,
                headers: headers
            })
            .then(resolve)
            .catch(reject);
    }

    return {
        get: getAsync,
        post: postAsync,
        put: putAsync,
        patch: patchAsync,
        delete: deleteAsync
    };
})();

function getAuthHeader() {
    let username = 'User';
    let password = 'user';
    let base64 = btoa(username + ':' + password);
    let header = {
        Authorization: `Basic ${base64}`
    };

    return header;
}

function onSuccess(data) {
    console.log(data);
}

function onError(err) {
    console.log(err);
}

function showHideElement($element) {

    if ($element.is(':visible')) {
        $element.hide();
    } else {
        $element.css('display', 'inline-block');
    }
}
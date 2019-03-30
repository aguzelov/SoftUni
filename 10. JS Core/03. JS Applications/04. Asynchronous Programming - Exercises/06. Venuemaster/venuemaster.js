function attachEvents() {
    $('#getVenues').on('click', getIds);
}

function getIds() {
    let date = $('#venueDate').val();
    request.post('calendar', `query=${date}`, getVenues, onError);
}

function getVenues(ids) {
    $('#venue-info').empty();
    ids.forEach(id => {
        request.get(id, addVenue, onError);
    });
}

function addVenue(venue) {
    let $venue = $(`<div class="venue" id="${venue._id}">
    <span class="venue-name"><input class="info" type="button" value="More info">${venue.name}</span>
    <div class="venue-details" style="display: none;">
      <table>
        <tr><th>Ticket Price</th><th>Quantity</th><th></th></tr>
        <tr>
          <td class="venue-price">${venue.price} lv</td>
          <td><select class="quantity">
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
          </select></td>
          <td><input class="purchase" type="button" value="Purchase"></td>
        </tr>
      </table>
      <span class="head">Venue description:</span>
      <p class="description">${venue.description}</p>
      <p class="description">Starting time: ${venue.startingHour}</p>
    </div>
  </div>
  `);

    $venue.find('.info').on('click', (e) => {
        let $div = $venue.find('.venue-details');
        if ($div.is(':visible')) {
            $div.hide();
            e.target.value = 'More info';
        } else {
            $div.show();
            e.target.value = 'Less info';
        }

    });

    $venue.find('.purchase').on('click', makePurchase);

    $('#venue-info').append($venue);
}

function makePurchase(e) {
    let $venue = $(e.target).closest('.venue');

    let id = $venue.attr('id');
    let name = $venue.find('.venue-name').text();
    let quantity = +$venue.find('.quantity option:selected').val();
    let price = +$venue.find('.venue-price').text().split(' ')[0];


    let $venueInfoContainer = $('#venue-info');
    $venueInfoContainer.empty();

    let $confirmation = $(`<span class="head">Confirm purchase</span>
    <div class="purchase-info">
    <span style="display: none">${id}</span>
      <span>${name}</span>
      <span>${quantity} x ${addZeros(price)}</span>
      <span>Total: ${addZeros(quantity * price)} lv</span>
      <input type="button" value="Confirm">
    </div>
    `);

    $confirmation.find('input').on('click', confirmPurchase);

    $venueInfoContainer.append($confirmation);
}

function confirmPurchase() {
    let $purchaseInfo = $('.purchase-info');

    let id = $purchaseInfo.children()[0].textContent;

    let quantity = +$purchaseInfo.children()[2].textContent;
    request.post('purchase', `venue=${id}&qty=${quantity}`, confirmation, onError);
}

function confirmation(htmlFragment) {
    let $venueInfoContainer = $('#venue-info');
    $venueInfoContainer.empty();

    $venueInfoContainer.append($('<p>You may print this page as your ticket</p>'));
    console.log('here');
    let $fragment = $(htmlFragment.html);
    console.log($fragment);

    $venueInfoContainer.append($fragment);
}

let request = function () {
    let appId = 'kid_BJ_Ke8hZg';
    let headers = getAuthHeaders();

    function getAsync(id, resolve, reject) {
        let url = `https://baas.kinvey.com/appdata/${appId}/venues/${id}`;

        $.ajax({
            method: 'GET',
            url: url,
            headers: headers
        })
            .then(resolve)
            .catch(reject);
    }

    function postAsync(pathToken, parameters, resolve, reject) {
        let url = `https://baas.kinvey.com/rpc/${appId}/custom/${pathToken}?${parameters}`;

        $.ajax({
            method: 'POST',
            url: url,
            headers: headers
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
    let password = 'pass';
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

function addZeros(num) {
    return num + ".00";
}
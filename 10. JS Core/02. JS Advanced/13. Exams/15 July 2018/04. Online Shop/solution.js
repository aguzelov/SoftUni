function onlineShop(selector) {
    let form = `<div id="header">Online Shop Inventory</div>
    <div class="block">
        <label class="field">Product details:</label>
        <br>
        <input placeholder="Enter product" class="custom-select">
        <input class="input1" id="price" type="number" min="1" max="999999" value="1"><label class="text">BGN</label>
        <input class="input1" id="quantity" type="number" min="1" value="1"><label class="text">Qty.</label>
        <button id="submit" class="button" disabled>Submit</button>
        <br><br>
        <label class="field">Inventory:</label>
        <br>
        <ul class="display">
        </ul>
        <br>
        <label class="field">Capacity:</label><input id="capacity" readonly>
        <label class="field">(maximum capacity is 150 items.)</label>
        <br>
        <label class="field">Price:</label><input id="sum" readonly>
        <label class="field">BGN</label>
    </div>`;
    $(selector).html(form);
    // Write your code here
    $('.custom-select').on('change keyup copy paste cut', function () {
        if (this.value) {
            $('#submit').removeAttr("disabled");
        } else {
            $('#submit').attr("disabled", true);
        }

    });

    $('#submit').on('click', () => {
        let name = $('.custom-select').val();
        let price = +$('#price').val();
        let quantity = +$('#quantity').val();

        let product = $('<li></li>').text(`Product: ${name} Price: ${price} Quantity: ${quantity}`);
        $('.display').append(product);

        changeCapacityAndPrice(price, quantity);

        $('.custom-select').val('');
        $('#price').val(1);
        $('#quantity').val(1);
        $('#submit').attr("disabled", true);
    });

    function changeCapacityAndPrice(price, quantity) {
        let currentCapacity = +$('#capacity').val();
        if (currentCapacity === undefined) {
            currentCapacity = 0;
        }

        currentCapacity += quantity;

        if (currentCapacity >= 150) {
            $('#capacity').val('full');
            $('#capacity').addClass('fullCapacity');

            $('.custom-select').attr("disabled", true);
            $('#price').attr("disabled", true);
            $('#quantity').attr("disabled", true);
            $('#submit').attr("disabled", true);

        } else {
            $('#capacity').val(currentCapacity);
        }

        let currentSum = +$('#sum').val();

        if (currentSum === undefined) {
            currentSum = 0;
        }

        currentSum += price;
        $('#sum').val(currentSum);

    }
}

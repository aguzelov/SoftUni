function priceCalculator(fruitType, grams, pricePerKilo){
    let weight = parseFloat(+grams * 0.001);
    let price = parseFloat(weight * +pricePerKilo);

    console.log(`I need ${price.toFixed(2)} leva to buy ${weight.toFixed(2)} kilograms ${fruitType}.`);
}


priceCalculator('apple', 1563, 2.35);
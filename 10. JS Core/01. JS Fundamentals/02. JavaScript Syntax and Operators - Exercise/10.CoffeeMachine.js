function machine(arr){
    let total = 0;
    for (let index = 0; index < arr.length; index++) {
        let order = arr[index].split(", ");
        let drinkPrice = 0;


        let coins = order[0];
        let drinkType = order[1];
        
        if(drinkType === "coffee"){
            let coffeeType = order[2];
            if(coffeeType === "caffeine"){
                drinkPrice = 0.80;

                let hasMilk = order.length === 5;
                let sugar = hasMilk ? +order[4] : +order[3];
                drinkPrice = hasMilk ? (+((drinkPrice * 10)/100).toFixed(1) + drinkPrice) : drinkPrice;
          
                if(sugar !== 0){
                    drinkPrice += 0.10;
                }

            }else{
                drinkPrice = 0.90;

                let hasMilk = order.length === 5;
                let sugar = hasMilk ? +order[4] : +order[3];
                drinkPrice = hasMilk ? (+((drinkPrice * 10)/100).toFixed(1) + drinkPrice) : drinkPrice;
          
                if(sugar !== 0){
                    drinkPrice += 0.10;
                }

            }
        }else{
            drinkPrice = 0.80;

            let hasMilk = order.length === 4;
            let sugar = hasMilk ? +order[3] : +order[2];
            drinkPrice = hasMilk ? (+((drinkPrice * 10)/100).toFixed(1) + drinkPrice) : drinkPrice;
          
            if(sugar !== 0){
                drinkPrice += 0.10;
            }
        }

        if(coins >= drinkPrice){
            total += drinkPrice;
            console.log(`You ordered ${drinkType}. Price: ${drinkPrice.toFixed(2)}$ Change: ${(coins - drinkPrice).toFixed(2)}$`);
        
        }else{
            console.log(`Not enough money for ${drinkType}. Need ${(drinkPrice - coins).toFixed(2)}$ more.`);
        }
    }
    console.log(`Income Report: ${total.toFixed(2)}$`);

}


machine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
'1.00, coffee, decaf, 0']
);
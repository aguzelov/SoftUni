function gymCalculator(day, service, time){
    let price = 0;

    if(day === "Saturday" || day === "Sunday"){
        if(service === "Fitness"){
            price = 8.00;
        }else if(service === "Sauna"){
            price = 7.00;
        }else {
            price = 15.00;
        }
    }else{
        if(service === "Fitness"){
             price = 5.00;

            if(time > 15.00){
                price += 2.50;
            }            
        }else if(service === "Sauna"){
            price = 4.00;

            if(time > 15.00){
                price += 2.50;
            }  
        }else{
            price = 10.00;

            if(time > 15.00){
                price += 2.50;
            }  
        }
    }

    console.log(price);
}

gymCalculator('Sunday', 'Fitness', 22.00);
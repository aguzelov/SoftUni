function area(param){
    if(typeof(param) !== "number"){
        console.log(`We can not calculate the circle area, because we receive a ${typeof(param)}.`);
    }else{
        let result = Math.pow(param, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
}

area(5);
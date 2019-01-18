function toObject(arr){
    let obj = {};
    for(let index = 0; index < arr.length; index += 2){
        let propertyName = arr[index];
        obj[propertyName] = +arr[index+1];
    }
    console.log(obj);
}

toObject(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);
let myList = (function () {
    let collection = [];

    let obj = {
        add: (element) => {
            collection.push(+element);
            collection = collection.sort((a, b) => a - b);
            obj.size++;
        },
        remove: (index) => {
            if (index < 0 || index >= obj.size) {
                throw new Error('Index is outside of collection!');
            }
            console.log(`after ${collection}`);

            collection.splice(index, 1);
            collection = collection.sort((a, b) => a - b);

            console.log(`before ${collection}`);

            obj.size--;
        },
        get: (index) => {
            if (index < 0 || index >= obj.size) {
                throw new Error('Index is outside of collection!');
            }
            return collection[index];
        },
        size: 0
    };
    return obj;
})();

for (let i = 0; i < 10; i++) {
    myList.add(i);
}

myList.remove(9);

var expectedArray = [0, 1, 2, 3, 4, 5, 6, 7, 8];
for (let i = 0; i < expectedArray.length; i++) {
    console.log(`${myList.get(i)} === expected ${expectedArray[i]} index ${i}`);
}
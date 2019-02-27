function solve() {
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

            collection.splice(index, 1);
            collection = collection.sort((a, b) => a - b);
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
}
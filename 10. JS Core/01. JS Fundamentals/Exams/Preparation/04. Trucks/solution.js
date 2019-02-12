function solve() {
    let fieldsets = document.querySelectorAll('#exercise section fieldset');

    let sections = document.querySelectorAll('#exercise section');
    let reportSection = sections[sections.length - 1];

    let trucks = [];
    let tiresCollection = [];
    let tireIdCounter = 0;

    //NEWTRUCK
    let newTruckFieldset = fieldsets[0];
    let newTruckButton = newTruckFieldset.querySelector('button');
    newTruckButton.addEventListener('click', newTruck);

    function newTruck() {
        let plateNumber = document.getElementById('newTruckPlateNumber').value;

        let tiresCondition = document.getElementById('newTruckTiresCondition').value;

        let truck = {
            'plate': plateNumber,
            'tires': tiresCondition.split(' ').map(Number),
            'distance': 0
        };

        addTruck(truck);

        console.log(`Truck added ${JSON.stringify(truck)}`);
        console.log(`TRUCKS ${JSON.stringify(trucks)}`);
    }

    function addTruck(truck) {
        if (!isExistTruckWithTires(truck)) {
            trucks.push(truck);
            addTruckPlateToReport(truck.plate);
        }
    }

    function isExistTruckWithTires(truck) {
        return trucks.filter(t => t.plate === truck.plate &&
            t.tires === truck.tires).length > 0;
    }

    function addTruckPlateToReport(plate) {
        let trucksElement = reportSection.querySelectorAll('fieldset')[1];

        let tuckElement = document.createElement('div');
        tuckElement.classList.add('truck');

        tuckElement.innerHTML = plate;

        trucksElement.appendChild(tuckElement);
    }

    //NEWTIRES
    let newTiresFieldset = fieldsets[1];
    let newTiresButton = newTiresFieldset.querySelector('button');
    newTiresButton.addEventListener('click', addTires);

    function addTires() {
        let tires = document.getElementById('newTiresCondition').value;

        let tire = {
            'conditions': tires.split(' ').map(Number),
            'id': 'tire' + tireIdCounter++
        };

        tiresCollection.push(tire);
        addTiresToReport(tire);
        console.log(`Tires added ${tires}`);
    }

    function addTiresToReport(tire) {
        let tiresElement = reportSection.querySelectorAll('fieldset')[0];
        let tireElement = document.createElement('div');
        tireElement.classList.add('tireSet');
        tireElement.id = tire.id;

        tireElement.innerHTML = tire.conditions.join(' ');

        tiresElement.appendChild(tireElement);
    }

    function removeTiresFromReport(id) {
        console.log(`Remove id: ${id}`);

        let tireElement = document.getElementById(id);

        tireElement.parentElement.removeChild(tireElement);
    }

    //WORK
    let workFieldset = fieldsets[2];
    let workButton = workFieldset.querySelector('button');
    workButton.addEventListener('click', work);

    function work() {
        let workPlateNumber = document.getElementById('workPlateNumber').value;
        let distance = +document.getElementById('distance').value;

        if (isExistTruckByPlate(workPlateNumber)) {
            let truck = trucks.find(t => t.plate === workPlateNumber);

            doWork(truck, distance);
            console.log(`Work: ${JSON.stringify(truck)}`);

        }
    }

    function isExistTruckByPlate(plate) {
        return trucks.filter(t => t.plate === plate).length > 0;
    }

    function doWork(truck, distance) {
        if (hasCondition(truck.tires, distance)) {
            reduceTiresCondition(truck, distance);
            truck.distance += distance;
        } else {
            if (tiresCollection.length > 0) {
                let tireToRemove = tiresCollection.shift();
                truck.tires = tireToRemove.conditions;

                removeTiresFromReport(tireToRemove.id);
                if (hasCondition(truck.tires, distance)) {
                    reduceTiresCondition(truck, distance);
                    truck.distance += distance;
                }
            }

        }
    }

    function hasCondition(tires, distance) {
        totalTiresCondition = tires.reduce((a, b) => {
            return a + b;
        }, 0);
        return ((totalTiresCondition * 1000) / tires.length) >= distance;
    }

    function reduceTiresCondition(truck, distance) {
        console.log(`Reduce Condition : truck ${JSON.stringify(truck)} distance ${distance}`);

        truck.tires = truck.tires.map(function (tire) {
            return tire -= distance / 1000;
        });


        console.log(`Reduced Condition : truck ${JSON.stringify(truck)} distance ${distance}`);
    }


    //End of the shift
    let endOfTheShiftButton = document.querySelector('#exercise section>button');
    endOfTheShiftButton.addEventListener('click', report);

    function report() {
        let reportTextarea = reportSection.querySelector('textarea');

        for (const truck of trucks) {
            reportTextarea.value += `Truck ${truck.plate} has traveled ${truck.distance}.\n`;
        }
        reportTextarea.value += `You have ${tiresCollection.length} sets of tires left.\n`;
    }
}
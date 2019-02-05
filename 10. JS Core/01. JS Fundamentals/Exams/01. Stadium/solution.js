function solve() {
    let sections = document.querySelectorAll('#exercise section');
    let sectors = ['A', 'B', 'C'];
    let price = {
        'A': function (zone) {
            if (zone == 'VIP') {
                return 25;
            }
            return 10;
        },
        'B': function (zone) {
            if (zone == 'VIP') {
                return 15;
            }
            return 7;
        },
        'C': function (zone) {
            if (zone == 'VIP') {
                return 10;
            }
            return 5;
        },
    };

    let profit = 0;
    let fans = 0;

    for (const section of sections) {
        let zone = section.className;

        let tbody = section.querySelector('table tbody');

        let rows = tbody.querySelectorAll('tr');

        for (const row of rows) {
            let td = row.querySelectorAll('td');
            for (let indexOfSector = 0; indexOfSector < 3; indexOfSector++) {
                let money = price[sectors[indexOfSector]](zone);

                let currentButton = td[indexOfSector].querySelector('button');
                currentButton.addEventListener('click', function () {
                    markSeat(money, zone, sectors[indexOfSector], currentButton);
                });
            }
        }
    }

    function markSeat(money, zone, sector, currentButton) {
        let outputTextarea = document.getElementById('output');
        let number = +currentButton.innerHTML;

        if (!currentButton.getAttribute("style")) {
            currentButton.style.color = 'rgb(255,0,0)';

            fans++;
            profit += money;

            outputTextarea.value += ` Seat ${number} in zone ${zone} sector ${sector} was taken.`;
        } else {
            outputTextarea.value += ` Seat ${number} in zone ${zone} sector ${sector} is unavailable.`;
        }

        outputTextarea.value += '\n';
        console.log(profit);
        console.log(fans);
    }


    let summaryDiv = document.getElementById('summary');
    let summaryButton = summaryDiv.querySelector('button');

    summaryButton.addEventListener('click', summary);

    function summary() {
        let summarySpan = summaryDiv.querySelector('span');
        summarySpan.textContent = `${profit} leva, ${fans} fans.`;
    }
}
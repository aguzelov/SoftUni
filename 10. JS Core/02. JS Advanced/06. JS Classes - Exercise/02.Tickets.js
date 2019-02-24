function solve(arr, sorting) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (const ticketInfo of arr) {
        let ticketTokens = ticketInfo.split('|');
        let destination = ticketTokens[0];
        let price = +ticketTokens[1];
        let status = ticketTokens[2];

        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    tickets.sort((a, b) => {
        if (a[sorting] < b[sorting]) {
            return -1;
        }
        if (a[sorting] > b[sorting]) {
            return 1;
        }

        return 0;
    });

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

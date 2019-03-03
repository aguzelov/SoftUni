class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }
    get numberOfChildren() {
        let count = 0;
        for (const key in this.kids) {
            if (this.kids.hasOwnProperty(key)) {
                count += this.kids[key].length;
            }
        }

        return count;
    }

    registerChild(name, grade, budget) {
        if (budget < this.budget) {
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }

        if (!this.kids.hasOwnProperty(grade)) {
            this.kids[grade] = [];
        }

        if (this.kids[grade].join(' ').includes(name)) {
            return `${name} is already in the list for this ${this.destination} vacation.`;
        }

        this.kids[grade].push(`${name}-${budget}`);

        return this.kids[grade];
    }

    removeChild(name, grade) {
        if (!Object.keys(this.kids).join(' ').includes(grade) || !this.kids[grade].join(' ').includes(name)) {
            return `We couldn't find ${name} in ${grade} grade.`;
        }

        let indexOfKid = -1;
        for (let index = 0; index < this.kids[grade].length; index++) {
            let elem = this.kids[grade][index];
            if (elem.indexOf(name) !== -1) {
                indexOfKid = index;
                break;
            }
        }
        this.kids[grade].splice(indexOfKid, 1);

        return this.kids[grade];
    }

    toString() {
        let grades = Object.keys(this.kids);
        if (grades.length === 0) {
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        }

        grades.sort((a, b) => +a - +b);

        let result = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

        for (const grade of grades) {
            result += `Grade: ${grade}\n`;

            let kidNumber = 1;
            for (const kid of this.kids[grade]) {
                result += `${kidNumber}. ${kid}\n`;
            }
            result += '\n';
        }

        return result.trim();
    }
}
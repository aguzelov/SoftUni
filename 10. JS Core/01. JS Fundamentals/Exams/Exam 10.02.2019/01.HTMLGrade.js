function solve(points, homework, totalHomework) {

    if (points === 400) {
        let maxGrade = 6;
        return maxGrade.toFixed(2);
    }

    let forOnePoint = 90 / 400;
    let maxPoints = points * forOnePoint;

    let forOneHomework = 10 / totalHomework;
    let homewortPoints = homework * forOneHomework;
    let totalPoints = maxPoints + homewortPoints;
    let grade = 3 + 2 * (totalPoints - 100 / 5) / (100 / 2);

    if (grade < 3.00) {
        let minGrade = 2;
        return minGrade.toFixed(2);
    }

    if (grade > 6.00) {
        let maxGrade = 6;
        return maxGrade.toFixed(2);
    }
    console.log(grade.toFixed(2));
}

solve(300, 10, 10);
function solve(worker) {
    if (!worker.handsShaking) {
        return worker;
    }

    let weight = worker.weight;
    let experience = worker.experience;

    let requiredAmound = (weight * experience) * 0.1;

    worker.bloodAlcoholLevel += requiredAmound;
    worker.handsShaking = false;
    return worker;
}
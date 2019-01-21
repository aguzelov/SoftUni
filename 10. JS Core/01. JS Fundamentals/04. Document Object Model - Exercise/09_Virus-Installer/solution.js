function solve() {
    let exerciseElement = document.getElementById('exercise');

    let buttonsDiv = document.getElementById('buttons');

    let nextButtonElement = buttonsDiv.firstElementChild;
    let cancelButtonElement = buttonsDiv.lastElementChild;

    let stepIds = getStepsId();
    let currentStepIndex = -1;

    nextButtonElement.addEventListener('click', function () {
        hideBackgroundImg();



        if (currentStepIndex === 0 && isDisagreeIdSelected()) {
            return;
        } else {
            currentStepIndex++;
            switchStep();

            if (currentStepIndex === 1) {
                hideButton(nextButtonElement);

                setTimeout(function () {
                    nextButtonElement.style.display = 'inline-block';
                }, 3000);
            } else if (currentStepIndex === 2) {
                hideButton(nextButtonElement);
                cancelButtonElement.textContent = 'Finish';
            }
        }
    });

    cancelButtonElement.addEventListener('click', function () {
        let sectionElement = exerciseElement.querySelector('section');
        sectionElement.style.display = 'none';
    });

    function hideButton(button) {
        button.style.display = 'none';
    }

    function getStepsId() {
        let steps = document.querySelectorAll('#content div');
        let stepIds = [];
        for (let step of steps) {
            stepIds.push(step.id);
        }

        return stepIds;
    }

    function hideBackgroundImg() {
        if (currentStepIndex === -1) {
            let mainElement = document.getElementById('content');
            mainElement.style.background = 'none';
        }
    }

    function switchStep() {
        if (currentStepIndex - 1 >= 0) {
            let element = document.getElementById(stepIds[currentStepIndex - 1]);
            element.style.display = 'none';
        }

        let element = document.getElementById(stepIds[currentStepIndex]);
        element.style.display = 'block';
    }

    function isDisagreeIdSelected() {
        let stepElement = document.getElementById(stepIds[0]);
        let isDisagreeRadioElementChecked = stepElement.querySelectorAll('input')[1].checked;

        return isDisagreeRadioElementChecked;
    }
}
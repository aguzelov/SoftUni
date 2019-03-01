function attachEventsListeners() {
    let convertButton = document.getElementById('convert');

    let converter = {
        km: {
            km: (value) => value,
            m: (value) => value * 1000,
            cm: (value) => value * 100000,
            mm: (value) => value * 1000000,
            mi: (value) => value * 0.621371192,
            yrd: (value) => value * 1093.6133,
            ft: (value) => value * 3280.8399,
            in: (value) => value * 39370.0787,
        },
        m: {
            km: (value) => value / 1000,
            m: (value) => value,
            cm: (value) => value * 100,
            mm: (value) => value * 1000,
            mi: (value) => value * 0.000621371192,
            yrd: (value) => value * 1.0936133,
            ft: (value) => value * 3.2808399,
            in: (value) => value * 39.3700787,
        },
        cm: {
            km: (value) => value * 0.00001,
            m: (value) => value * 0.01,
            cm: (value) => value,
            mm: (value) => value * 10,
            mi: (value) => value * 0.000006213711922,
            yrd: (value) => value * 0.010936133,
            ft: (value) => value * 0.03280839895,
            in: (value) => value * 0.393700787,
        },
        mm: {
            km: (value) => value * 0.000001,
            m: (value) => value * 0.001,
            cm: (value) => value * 0.1,
            mm: (value) => value,
            mi: (value) => value * 6.213711922e-7,
            yrd: (value) => value * 0.001093613298,
            ft: (value) => value * 0.003280839895,
            in: (value) => value * 0.03937007874,
        },
        mi: {
            km: (value) => value * 1.609344,
            m: (value) => value * 1609.344,
            cm: (value) => value * 160934.4,
            mm: (value) => value * 1609344,
            mi: (value) => value,
            yrd: (value) => value * 1760,
            ft: (value) => value * 5280,
            in: (value) => value * 63360,
        },
        yrd: {
            km: (value) => value * 0.0009144,
            m: (value) => value * 0.9144,
            cm: (value) => value * 91.44,
            mm: (value) => value * 914.4,
            mi: (value) => value * 0.0005681818182,
            yrd: (value) => value,
            ft: (value) => value * 3,
            in: (value) => value * 36,
        },
        ft: {
            km: (value) => value * 0.0003048,
            m: (value) => value * 0.3048,
            cm: (value) => value * 30.48,
            mm: (value) => value * 304.8,
            mi: (value) => value * 0.0001893939394,
            yrd: (value) => value * 0.33333333,
            ft: (value) => value,
            in: (value) => value * 12,
        },
        in: {
            km: (value) => value * 0.0000254,
            m: (value) => value * 0.0254,
            cm: (value) => value * 2.54,
            mm: (value) => value * 25.4,
            mi: (value) => value * 1.578E-5,
            yrd: (value) => value * 0.02777777778,
            ft: (value) => value * 0.08333333333,
            in: (value) => value,
        }
    };

    convertButton.addEventListener('click', (e) => {
        let inputDistance = +document.getElementById('inputDistance').value;

        let inputUnits = document.getElementById("inputUnits");
        let inputUnit = inputUnits.options[inputUnits.selectedIndex].value;

        let outputUnits = document.getElementById("outputUnits");
        let outputUnit = outputUnits.options[outputUnits.selectedIndex].value;

        document.getElementById('outputDistance').value = converter[inputUnit][outputUnit](inputDistance);
    });
}

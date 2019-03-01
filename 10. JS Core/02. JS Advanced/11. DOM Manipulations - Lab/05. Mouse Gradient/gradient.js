function attachGradientEvents() {
    let gradientElem = document.getElementById('gradient');
    gradientElem.addEventListener('mousemove', function (event) {
        let pct = (+event.offsetX) / + gradientElem.clientWidth;

        let percentage = Math.floor(pct * 100);

        document.getElementById('result').textContent = percentage + '%';
    });
}
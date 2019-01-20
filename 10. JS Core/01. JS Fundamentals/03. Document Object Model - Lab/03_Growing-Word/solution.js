
function solve() {
   document.getElementsByTagName('button')[0].addEventListener('click', () => {
      let queue = ['blue', 'green', 'red'];

      let paragraphElement = document.querySelector('#exercise p');
      let currentColor = paragraphElement.style.color;
      let currentSize = paragraphElement.style.fontSize.slice(0, -2);
      let size = +currentSize + 2;

      let indexOfCurrentColor = queue.indexOf(currentColor);
      let nextColorIndex = indexOfCurrentColor + 1;
      let nextColor = nextColorIndex >= queue.length ? queue[0] : queue[nextColorIndex];

      paragraphElement.style.cssText = `color: ${nextColor}; font-size: ${size}px`;
   });
}
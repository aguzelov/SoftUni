function solve() {
  let linkElements = document.querySelectorAll('#exercise div');

  for (let index = 0; index < linkElements.length; index++) {
    let element = linkElements[index];
    element.id = `link${index}`;
    element.children[0].addEventListener('click', function () {
      let spanElement = document.querySelector(`#${element.id} span`);

      let currentCount = +spanElement.textContent.match(/\d+/);
      spanElement.textContent = spanElement.textContent.replace(/\d+/, ++currentCount);
    });
  }
}
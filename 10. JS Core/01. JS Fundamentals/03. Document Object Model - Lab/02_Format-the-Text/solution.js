function solve() {
  let input = document.getElementById('input');
  let output = document.getElementById('output');

  let sentencesArr = input.textContent.split('.');
  console.log(input.textContent);
  console.log(sentencesArr);

  for (let index = 0; index < sentencesArr.length; index += 3) {
    let paragraph = document.createElement("p");

    paragraph.innerHTML = sentencesArr[index];

    if (sentencesArr.length > index + 1) {
      paragraph.textContent += '. ' + sentencesArr[index + 1];
    }

    if (sentencesArr.length > index + 2) {
      paragraph.textContent += '. ' + sentencesArr[index + 2];
    }

    output.appendChild(paragraph);

  }

}
function extractText() {
   console.log('Extract');

   let texts = $('#items li')
      .toArray()
      .map(l => l.textContent)
      .join(', ');

   $('#result').text(texts);
}

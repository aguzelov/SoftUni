function search() {
   $('#towns li').css('font-weight', 'normal');

   let searchTerm = $('#searchText').val();

   let count = $('#towns li')
      .filter((index, elem) => {
         return elem.textContent.indexOf(searchTerm) > -1;
      }).css('font-weight', 'bold');

   $('#result').text(`${count.length} matches found.`);
}
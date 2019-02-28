function attachEvents() {
	$('#items li').on('click', (e) => {
		let $target = $(e.target);

		if ($target.is('[data-selected]')) {
			$target.removeAttr('data-selected');
			$target.css('background-color', '');
		} else {
			$target.attr('data-selected', 'true');
			$target.css('background-color', '#DDD');
		}
	});

	$('#showTownsButton').on('click', () => {
		let selectedTowns = $('#items li')
			.filter((index, elem) => {
				return $(elem).is('[data-selected]');
			})
			.toArray()
			.map(t => '' + t.textContent);
		console.log(selectedTowns.join(', '));

		$('#selectedTowns').text(selectedTowns.join(', '));
	});
}
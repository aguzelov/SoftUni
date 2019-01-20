function solve() {
	let titleText = document.getElementById('createTitle').value;
	let contentText = document.getElementById('createContent').value;

	if (titleText !== '' && contentText !== '') {

		document.getElementById('createTitle').value = '';
		document.getElementById('createContent').value = '';

		console.log('here');

		let article = document.createElement('article');

		let title = document.createElement('h3');
		title.innerHTML = titleText;
		article.appendChild(title);

		let content = document.createElement('p');
		content.innerHTML = contentText;
		article.appendChild(content);

		document.getElementById('articles').appendChild(article);

	}
}
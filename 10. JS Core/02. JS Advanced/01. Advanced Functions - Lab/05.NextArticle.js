function getArticleGenerator(articles) {
    let initArr = articles;

    return () => {
        if (initArr.length !== 0) {
            let firstElement = initArr.shift();

            let article = document.createElement('article');
            article.textContent = firstElement;

            let div = document.getElementById('content');
            div.appendChild(article);
        }
    };
}
function solution(arr) {
    let text = arr.join(",");
    let words = text.split(/\W+/);
    let nonEmptyWords = words.filter(w=> w.length > 0);
    let upWords = nonEmptyWords.filter(str => str === str.toUpperCase());

    console.log(upWords.join(", "));
}

let arr = ['We start by HTML, CSS, JavaScript, JSON and REST.\n' +
'\n' +
'\n' +
'Later we touch some PHP, MySQL and SQL.\n' +
'\n' +
'\n' +
'Later we play with C#, EF, SQL Server and ASP.NET MVC.\n' +
'\n' +
'\n' +
'Finally, we touch some Java, Hibernate and Spring.MVC.'];
solution(arr);
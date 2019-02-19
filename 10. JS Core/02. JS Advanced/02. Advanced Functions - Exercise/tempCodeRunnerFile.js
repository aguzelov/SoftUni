function solve(post, command) {
    let obj = (() => {
        function upvote(post) {
            post.upvotes++;
        }
        function downvote(post) {
            post.downvotes++;
        }

        function score(post) {
            let upvotes = post.upvotes;
            let downvotes = post.downvotes;
            let totalVotes = upvotes + downvotes;
            let balance;
            let rating;
            if (totalVotes > 50) {
                let numberToAdd = Math.ceil((Math.max(upvotes, downvotes) / 100) * 25);
                upvotes += numberToAdd;
                downvotes += numberToAdd;
            }

            balance = upvotes - downvotes;
            if (balance > (downvotes * 0.66)) {
                rating = 'hot';
            }

            if (balance >= 0 && totalVotes > 100) {
                rating = 'controversial';
            }

            if (balance < 0) {
                rating = 'unpopular';
            }

            if (totalVotes < 10) {
                rating = 'new';
            }

            return [upvotes, downvotes, balance, rating];
        }

        return { upvote, downvote, score };
    })();
    return obj[command](post);
}

let post = {
    id: '1234',
    author: 'author name',
    content: 'these fields are irrelevant',
    upvotes: 200,
    downvotes: 200
};

let solution = solve();

solution.call(post, 'upvote');

let answer = solution.call(post, 'score');

console.log(answer[0]);


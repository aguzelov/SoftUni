(function () {

    Object.assign(String.prototype, {
        ensureStart(str) {
            let temp = '' + this;
            if (!temp.startsWith(str)) {
                temp = temp.replace(/^/, `${str}`);
            }

            return temp;
        }
    });

    Object.assign(String.prototype, {
        ensureEnd(str) {
            let temp = '' + this;
            if (!temp.endsWith(str)) {
                return temp + str;
            }

            return temp;
        }
    });

    Object.assign(String.prototype, {
        isEmpty() {
            return this.length === 0;
        }
    });

    Object.assign(String.prototype, {
        truncate(n) {
            let temp = '' + this;

            if (temp.length <= n) {
                return temp;
            }
            let ellipsis = '...';

            if (n < 4) {
                return ellipsis.slice(0, n);
            }

            if (!temp.includes(' ')) {
                return temp.slice(0, n - 3) + ellipsis;
            }

            let tempStr = temp;

            while (tempStr.length + ellipsis.length > n) {
                let workinArr = tempStr.split(' ');
                workinArr.pop();
                tempStr = workinArr.join(' ');
            }

            return tempStr + ellipsis;
        }
    });

    String.format = function (text, ...args) {
        let regex = new RegExp('{\\d}', 'gm');
        let matches = text.match(regex);

        for (let index = 0; index < matches.length; index++) {
            let currentMatch = matches[index];
            let currentParam = args[index];

            if (index < args.length) {
                text = text.replace(currentMatch, currentParam);
            }
        }

        return text;
    };
})();
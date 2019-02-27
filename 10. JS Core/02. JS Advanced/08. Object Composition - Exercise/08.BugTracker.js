function solve() {
    return (function () {
        let counter = 0;
        let reports = [];
        let resultElement;
        return {
            report: (author, description, reproducible, severity) => {
                let report = {
                    ID: counter++,
                    author: author,
                    description: description,
                    reproducible: reproducible,
                    severity: severity,
                    status: 'Open'
                };
                reports.push(report);
                if (typeof resultElement !== undefined) {
                    display(report, resultElement);
                }
            },
            setStatus: (id, newStatus) => {
                let report = reports.find(r => r.ID === id);

                report.status = newStatus;
                displayReports(reports, resultElement);
            },
            remove: (id) => {
                for (let index = 0; index < reports.length; index++) {
                    if (reports[index].ID === id) {
                        reports.splice(index, 1);
                    }
                }

                displayReports(reports, resultElement);
            },
            sort: (method) => {
                console.log('after');
                console.log(reports);

                reports.sort((a, b) => {
                    if (a[method] < b[method]) {
                        return -1;
                    }
                    if (a[method] > b[method]) {
                        return 1;
                    }

                    return 0;
                });

                console.log('before');
                console.log(reports);

                displayReports(reports, resultElement);
            },
            output: (selector) => {
                selector = selector.substring(1);
                resultElement = document.getElementById(selector);
                displayReports(reports, resultElement);
            }
        };
    })();

    function displayReports(reports, resultElement) {
        clearResultElement(resultElement);
        for (const report of reports) {
            display(report, resultElement);
        }
    }

    function display(report, resultElement) {
        let divReport = document.createElement('div');
        divReport.classList += 'report';
        divReport.id = `report_${report.ID}`;

        let divReportBody = document.createElement('div');
        divReportBody.classList += 'body';

        let pDescription = document.createElement('p');
        pDescription.innerHTML = `${report.description}`;
        divReportBody.appendChild(pDescription);
        divReport.appendChild(divReportBody);

        let divTitle = document.createElement('div');
        divTitle.classList += 'title';

        let authorSpan = document.createElement('span');
        authorSpan.classList += 'author';
        authorSpan.textContent = `Submitted by: ${report.author}`;
        divTitle.appendChild(authorSpan);

        let statusSpan = document.createElement('span');
        statusSpan.classList += 'status';
        statusSpan.textContent = `${report.status} | ${report.severity}`;
        divTitle.appendChild(statusSpan);

        divReport.appendChild(divTitle);

        resultElement.appendChild(divReport);
    }

    function clearResultElement(resultElement) {
        resultElement.innerHTML = '';
    }
}

let result = solve();
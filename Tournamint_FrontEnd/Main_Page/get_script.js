const url = 'https://localhost:7065/api/Match/';
const options = {
    method: 'get'
}

const response = {};

function loadData() {
    fetch(url, options)
    .then((response) => response.json())
    .then((a) => {
        console.log(a);

        a.forEach(element => {
            console.log(element);
        });
    })
}

//loadData();
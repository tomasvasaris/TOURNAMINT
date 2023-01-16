function sendData() {
    const match = {
        MatchId: 1,
        TournamentId: 1,
        PlayerOne: "TestPlayerOne",
        PlayerTwo: "TestPlayerTwo",
        PlayerOneScore: 0,
        PlayerTwoScore: 1
        };


    console.log(match);
    let obj = {};

    fetch('https://localhost:7065/api/Match/matches/', {
        method: 'post',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj) 
    })
    .then(async res => {
        console.log(res.status);

        if(res.ok)
        {
            // If success
            // window.location.href = "./index.html";
        }
        
        console.log(res);
        var resBody = await res.json();
        errorEle.textContent = resBody.message;
    })
    .catch((err) => console.log(err));
}

scores.addEventListener('click', (e) => {
    sendData();
})
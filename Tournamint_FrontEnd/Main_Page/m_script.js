// Startup. Display user name and update Tournament List

var user = JSON.parse(sessionStorage.getItem('activeUser'));
var userno = JSON.parse(sessionStorage.getItem('activeUserID'));

function mainLoad(){
    let username = user.firstName + " " + user.lastName;
    document.getElementById("hh").innerHTML = "･ﾟ: *✧ " + username + " ✧* :ﾟ･";

    TournamentView();
}


// Navigation Buttons and Functions

gobck1.addEventListener('click', () => {
    ChangeTabs(0);
});

gobck2.addEventListener('click', () => {
    ChangeTabs(0);
});

addnew.addEventListener('click', () => {
    ChangeTabs(1);
});


scores.addEventListener('click', (e) => {
    TournamentAddScores();
})

create.addEventListener('click', () => {
    TournamentCreate();
});

logout.addEventListener('click', () => {
    window.location.href = '../index.html'
});

function ChangeTabs(tabno) {
    document.getElementById("FieldMain").style.display   = "none";
    document.getElementById("FieldCreate").style.display = "none";
    document.getElementById("FieldStats").style.display  = "none";
    document.getElementById("NavMain").style.display     = "none";
    document.getElementById("NavCreate").style.display   = "none";
    document.getElementById("NavStats").style.display    = "none";

    switch (tabno) {
        case 0:
            document.getElementById("FieldMain").style.display   = "block";
            document.getElementById("NavMain").style.display     = "block";
            TournamentView();
            break;
        case 1:
            document.getElementById("FieldCreate").style.display = "block";
            document.getElementById("NavCreate").style.display   = "block";
            break;
        case 2:
            document.getElementById("FieldStats").style.display  = "block";
            document.getElementById("NavStats").style.display    = "block";
            break;
        default:
            break;
    }
}


// See All Active Tournaments

function TournamentView() {
    let tourneyList = [];
    
    if (JSON.parse(localStorage.getItem(0)) !== null) {
        tourneyList = JSON.parse(localStorage.getItem(0));

        const allTournItems = document.getElementById("FieldMain");
        allTournItems.innerHTML = "";
        tournCount=0;
    
        tourneyList.forEach(tourn => {
            const tournitem0 = document.createElement("p");
            const tournitem1 = document.createElement("span");
            const tournitem2 = document.createElement("button");
    
            tournitem1.className = "nameSpan";
    
            tournitem2.className = "openit";
            tournitem2.type = "button";
            let attributeName = "SeeTable(" + tournCount + ")";
            tournitem2.setAttribute("onclick", attributeName);
    
            const tournpart1 = document.createTextNode(tourn.Name);
            const tournpart2 = document.createTextNode("view");
    
            tournitem1.appendChild(tournpart1);
            tournitem2.appendChild(tournpart2);
    
            tournitem0.appendChild(tournitem1);
            tournitem0.appendChild(tournitem2);
    
            allTournItems.appendChild(tournitem0);
    
            tournCount++;
        })
    }
}


// Create New Tournament

function TournamentCreate() {
    let tourName = document.getElementById("newName").value;
    let tourType = document.getElementById("newType").value;
    let tourDate = document.getElementById("newDate").value;

    if (tourType === "robin") {tourType = "Round Robin";}
    
    let tourParticipants = [];
    tourParticipants.push(user);

    if (tourName === "" || tourType === "" || tourDate === "") {
        alert('All fields need to be filled in!');

    } else {
        let tourney = {Name: tourName, Type: tourType, Date: tourDate, Players: tourParticipants};
        let tourneyList = [];

        if (JSON.parse(localStorage.getItem(0)) !== null) {
            tourneyList = JSON.parse(localStorage.getItem(0));
        }

        tourneyList.push(tourney);
        localStorage.setItem(0, JSON.stringify(tourneyList));
    
        document.getElementById("newName").value = "";
        document.getElementById("newDate").value = "";
        ChangeTabs(0);        
    }
}


// See Tournament Table and Statistics

function SeeTable(itemno) {
    let matches = []; // every match from the selected tournament
    selectedTourNo = itemno;
    
    const urlGet = url + 'Match?TournamentId=' + selectedTourNo;

    fetch(urlGet, options)
    .then((response) => response.json())
    .then((data) => {
        sessionStorage.setItem('importedData', JSON.stringify(data));
        matches = data;
    })
    .catch(error => console.log(error));

    matches = JSON.parse(sessionStorage.getItem('importedData'));
    console.log(matches);

    let tourneyList = JSON.parse(localStorage.getItem(0));
    const selectedTourn = tourneyList[itemno];

    const allTournItems = document.getElementById("FieldStatsTable");
    allTournItems.innerHTML = "";
    tournCount=0;
    
    const tournitem0 = document.createElement("p");    // the main block
    const tournitem1 = document.createElement("div");  // name of tournament
    const tournitem2 = document.createElement("div");  // all matches with score
    const tournitem3 = document.createElement("div");  // score update field

    tournitem1.className = "tournName";
    tournitem2.className = "tournMatches";
    tournitem3.className = "tournEnterScore";
    
    // 01 Tournament name
    tournitem1.innerHTML = selectedTourn.Name;

    // 02 Tournament table
    let tournTable = "";

    selectedTourn.Players.forEach(player1 => {
        selectedTourn.Players.forEach(player2 => {
            if (player1.firstName === user.firstName && player1.lastName === user.lastName) {
                isParticipant = true;
            }
            if (player1.firstName !== player2.firstName || player1.lastName !== player2.lastName) {
                let p1score = '0';
                let p2score = '0';

                matches.forEach(match => {
                    console.log('enter');
                    if (player1.firstName === match.winnerFirstName &&
                        player1.lastName === match.winnerLastName &&
                        player2.firstName === match.loserFirstName &&
                        player2.lastName === match.loserLastName) {
                            console.log('win');
                            p1score = 'W';
                            p2score = 'L';
                        };
                    if (player1.firstName === match.loserFirstName &&
                        player1.lastName === match.loserLastName &&
                        player2.firstName === match.winnerFirstName &&
                        player2.lastName === match.winnerLastName) {
                            console.log('loss');
                            p1score = 'L';
                            p2score = 'W';
                        };
                })


                let score = p1score + '/' + p2score;

                tournTable = tournTable + player1.firstName + " " + player1.lastName;
                tournTable = tournTable + " " + score + " " ;
                tournTable = tournTable + player2.firstName + " " + player2.lastName + "<br/>";
            }
        });
        tournTable = tournTable + "<br/>";
    });

    tournitem2.innerHTML = tournTable

    // Finish up
    tournitem0.appendChild(tournitem1)
    tournitem0.appendChild(tournitem2)
    tournitem0.appendChild(tournitem3);

    allTournItems.appendChild(tournitem0);

    ChangeJoinOrLeaveButton();
    ChangeTabs(2);
}


// Add Scores to Selected Tournament

var enteredMatch = {};

function TournamentAddScores() {
    let winnerFirstName = document.getElementById("WinnerFirstName").value;
    let winnerLastName = document.getElementById("WinnerLastName").value;
    let loserFirstName = document.getElementById("LoserFirstName").value;
    let loserLastName = document.getElementById("LoserLastName").value;

    if (winnerFirstName === "" || winnerLastName === "" || loserFirstName === "" || loserLastName === "") {
        alert('All fields need to be filled in!');

    } else {

        enteredMatch = {WinnerFirstName: winnerFirstName, 
            WinnerLastName: winnerLastName, 
            LoserFirstName: loserFirstName, 
            LoserLastName: loserLastName,
            TournamentId: selectedTourNo};
            
        sendData();
        enteredMatch = {};
    
        document.getElementById("WinnerFirstName").value = "";
        document.getElementById("WinnerLastName").value = "";
        document.getElementById("LoserFirstName").value = "";
        document.getElementById("LoserLastName").value = "";
        
        SeeTable(selectedTourNo);       
    }    
}


// Join or Leave Selected Tournament

var isParticipant = false;
var selectedTourNo;

function ChangeJoinOrLeaveButton() {
    let button = document.getElementById("change");
    button.removeAttribute("onclick");

    if (isParticipant === true) {
        button.innerHTML = "Leave";
        button.setAttribute("onclick", "TournamentLeave(" + selectedTourNo + ")");
        isParticipant = false;

    } else {
        button.innerHTML = "Join In";
        button.setAttribute("onclick", "TournamentJoin(" + selectedTourNo + ")");
    }
}

function TournamentJoin() {
    const allTourns = JSON.parse(localStorage.getItem(0));
    allTourns[selectedTourNo].Players.push(user);
    localStorage.setItem(0, JSON.stringify(allTourns));
    SeeTable(selectedTourNo);
}

function TournamentLeave() {
    const confirmation = confirm("Are you sure you want to leave the tournament?");

    if(confirmation === true) {
        const allTourns = JSON.parse(localStorage.getItem(0));
        const allPlayers = allTourns[selectedTourNo].Players;
        const allPlayersNew = [];
    
        allPlayers.forEach(player => {
            if (player.firstName !== user.firstName && player.lastName !== user.lastName ) {
                allPlayersNew.push(player);
            }
        });
    
        allTourns[selectedTourNo].Players = allPlayersNew;
        localStorage.setItem(0, JSON.stringify(allTourns));
        SeeTable(selectedTourNo);
    }
}
    

// API part

const url = 'https://localhost:7040/';

// GET all matches

const options = {
    method: 'get',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }
}

const response = {};

// POST new match

function sendData() {
    console.log(enteredMatch);
    const urlPost = url + 'Match/';

    fetch(urlPost, {
        method: 'post',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(enteredMatch) 
    })
    .catch((error) => console.log(error));
}
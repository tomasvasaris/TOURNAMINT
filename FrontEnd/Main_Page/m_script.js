// Startup. Display user name and update Tournament List

function mainLoad(){
    let user = JSON.parse(sessionStorage.getItem('activeUser'));
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

gobck3.addEventListener('click', () => {
    ChangeTabs(0);
});

addnew.addEventListener('click', () => {
    ChangeTabs(1);
});

joinin.addEventListener('click', () => {
    ChangeTabs(2);
});


create.addEventListener('click', () => {
    TournamentCreate();
});

scores.addEventListener('click', () => {
    TournamentAddScores();
});

joinup.addEventListener('click', () => {
    TournamentJoin();
});

logout.addEventListener('click', () => {
    window.location.href = '../index.html'
});

function ChangeTabs(tabno) {
    document.getElementById("FieldMain").style.display   = "none";
    document.getElementById("FieldCreate").style.display = "none";
    document.getElementById("FieldJoin").style.display   = "none";
    document.getElementById("FieldStats").style.display  = "none";
    document.getElementById("NavMain").style.display     = "none";
    document.getElementById("NavCreate").style.display   = "none";
    document.getElementById("NavJoinIn").style.display   = "none";
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
    let activeuser = JSON.parse(sessionStorage.getItem('activeUser'));
    let allUserTourns = [];
    allUserTourns = activeuser.tourns;

    const allTournItems = document.getElementById("FieldMain");
    allTournItems.innerHTML = "";
    tournCount=0;

    allUserTourns.forEach(tourn => {
        const tournitem0 = document.createElement("p");
        const tournitem1 = document.createElement("span");
        const tournitem2 = document.createElement("span");
        const tournitem3 = document.createElement("button");

        tournitem1.className = "lspan";
        tournitem2.className = "rspan";

        tournitem3.className = "openit";
        tournitem3.type = "button";
        let attributeName = "SeeTable(" + tournCount + ")";
        tournitem3.setAttribute("onclick", attributeName);

        const tournpart1 = document.createTextNode(tourn[0]);
        const tournpart2 = document.createTextNode(tourn[2]);
        const tournpart3 = document.createTextNode("view");

        tournitem1.appendChild(tournpart1);
        tournitem2.appendChild(tournpart2);
        tournitem3.appendChild(tournpart3);

        tournitem0.appendChild(tournitem1);
        tournitem0.appendChild(tournitem2);
        tournitem0.appendChild(tournitem3);

        allTournItems.appendChild(tournitem0);

        tournCount++;
    })
}


// Create New Tournament

function TournamentCreate() {
    let tourName = document.getElementById("newName").value;
    let tourType = document.getElementById("newType").value;
    let tourDate = document.getElementById("newDate").value;

    if (tourName === "" || tourType === "" || tourDate === "") {
        alert('All fields need to be filled in!');

    } else {

        let tourney = [tourName, tourType, tourDate];
        let userno = JSON.parse(sessionStorage.getItem('activeUserID'));
        let user = JSON.parse(sessionStorage.getItem('activeUser'));
    
        let newTourns = [];
        newTourns = user.tourns;
        newTourns.push(tourney);
    
        let updatedUser = {
            firstName: user.firstName, 
            lastName: user.lastName, 
            eMail: user.eMail, 
            tourns: newTourns
        };
    
        localStorage.setItem(userno, JSON.stringify(updatedUser));
        sessionStorage.setItem('activeUser', JSON.stringify(updatedUser));
    
        document.getElementById("newName").value = "";
        tourndate = document.getElementById("newDate").value = "";
        ChangeTabs(0);
    }
}


// See Tournament Table and Statistics

function SeeTable(itemno) {
    let activeuser = JSON.parse(sessionStorage.getItem('activeUser'));
    let allUserTourns = [];
    allUserTourns = activeuser.tourns;

    const allTournItems = document.getElementById("FieldStats");
    allTournItems.innerHTML = "";
    tournCount=0;
    
    const tournitem0 = document.createElement("p");      // the main block
    const tournitem1 = document.createElement("div");    // name of tournament
    const tournitem2 = document.createElement("div");    // all matches with score
    const tournitem3 = document.createElement("div");    // score update field
    const tournitem4 = document.createElement("button"); // score update button
    const tournitem5 = document.createElement("button"); // leave tourney button
    const tournitem6 = document.createElement("button"); // go back button


    tournitem1.className = "tournName";
    tournitem2.className = "tournMatches";
    tournitem3.className = "tournEnterScore";

    tournitem4.className = "updateScore";
    tournitem4.type = "button";
    let attributeNameB1 = "TournamentAddScores()";
    tournitem4.setAttribute("onclick", attributeNameB1);

    tournitem5.className = "leaveTourney";
    tournitem5.type = "button";
    let attributeNameB2 = "TournamentLeave(" + itemno + ")";
    tournitem5.setAttribute("onclick", attributeNameB2);

    tournitem6.className = "goBack";
    tournitem6.type = "button";
    let attributeNameB3 = "ChangeTabs(0)";
    tournitem6.setAttribute("onclick", attributeNameB3);


    const tournpart1 = document.createTextNode(tourn[0]);
    const tournpart2 = document.createTextNode(tourn[2]);
    const tournpart3 = document.createTextNode("view");

    tournitem1.appendChild(tournpart1);
    tournitem2.appendChild(tournpart2);
    tournitem3.appendChild(tournpart3);

    tournitem0.appendChild(tournitem1);
    tournitem0.appendChild(tournitem2);
    tournitem0.appendChild(tournitem3);

    allTournItems.appendChild(tournitem0);

    ChangeTabs(3);
}


// Add Scores to Selected Tournament

function TournamentAddScores() {

}


// Join Selected Tournament

function TournamentJoin() {

}


// Leave Tournament

function TournamentLeave(itemno) {
    const confirmation = confirm("Are you sure you want to leave the tournament?");

    if(confirmation === true) {
        let activeuser = JSON.parse(sessionStorage.getItem('activeUser'));
        let userno = JSON.parse(sessionStorage.getItem('activeUserID'));
        let allUserTourns = [];
        let allUserTournsNew = [];
        allUserTourns = activeuser.tourns;
        tourncount=0;
    
        allUserTourns.forEach(tourn => {
            if (tourncount !== itemno) {
                allUserTournsNew.push(tourn);
            }
            tourncount++;
        });
    
        let updatedUser = {
            firstName: activeuser.firstName, 
            lastName: activeuser.lastName, 
            eMail: activeuser.eMail, 
            tourns: allUserTournsNew
        };
    
        localStorage.setItem(userno, JSON.stringify(updatedUser));
        sessionStorage.setItem('activeUser', JSON.stringify(updatedUser));
        
        ChangeTabs(0);
    }
}
    
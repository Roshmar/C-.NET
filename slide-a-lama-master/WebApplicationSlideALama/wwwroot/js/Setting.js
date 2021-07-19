function changeColorText(player,cgColor) {

    if (Number(player) == 1) {
      
        document.getElementById('NameFirstPlayer').style.color = cgColor;
    }
    if (Number(player) == 2) {
       
        document.getElementById('NameSecondPlayer').style.color =  cgColor ;
    }
}

function changePlayerIcon(player, icon) {
    var element, element2;
    if (Number(player) == 1) {
        element = document.getElementById('FirstPlayerIcon');
        element2 = document.getElementById('IconFirstPlayer');
    }
    if (Number(player) == 2) {
       element = document.getElementById('SecondPlayerIcon');
       element2 = document.getElementById('IconSecondPlayer');
    }

    switch (icon) {
        case 1:
            element.style.backgroundImage = 'url("../img/PlayerIcon1.png")';
            element2.style.backgroundImage = 'url("../img/PlayerIcon1.png")';
            break;
        case 2:
            element.style.backgroundImage = 'url("../img/PlayerIcon2.png")';
            element2.style.backgroundImage = 'url("../img/PlayerIcon2.png")';
            break;
        case 3:
            element.style.backgroundImage = 'url("../img/PlayerIcon3.png")';
            element2.style.backgroundImage = 'url("../img/PlayerIcon3.png")';
            break;
        case 4:
            element.style.backgroundImage = 'url("../img/PlayerIcon4.png")';
            element2.style.backgroundImage = 'url("../img/PlayerIcon4.png")';
            break;
        case 5:
            element.style.backgroundImage = 'url("../img/PlayerIcon5.png")';
            element2.style.backgroundImage = 'url("../img/PlayerIcon5.png")';
            break;
        default:
            element.style.backgroundImage = 'url("../img/PlayerIcon.png")';
            element2.style.backgroundImage = 'url("../img/PlayerIcon.png")';
            break;
    }
}

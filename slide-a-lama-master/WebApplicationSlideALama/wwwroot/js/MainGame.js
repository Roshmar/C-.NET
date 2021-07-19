function SetBacground() {
    for (let i = 0; i < 27; i++) {
        var id = 'cell' + i;
        
        var element = document.getElementById(id);
        var number = Number(element.getAttribute('img-value'));
        //element.getAttribute('img-value');
        switch (number){
            case 1:
                element.style.border = 'solid 1.5px black';
                element.style.backgroundImage = 'url("../img/Bel.png")';
                break;
            case 2:
                element.style.border = 'solid 1.5px black';
                element.style.backgroundImage = 'url("../img/Banana.png")';
                break;
            case 3:
                element.style.border = 'solid 1.5px black';
                element.style.backgroundImage = 'url("../img/Plump.png")';
                break;
            case 4:
                element.style.border = 'solid 1.5px black';
                element.style.backgroundImage = 'url("../img/pear.png")';
                break;
            case 5:
                element.style.border = 'solid 1.5px black';
                element.style.backgroundImage = 'url("../img/Cherry.png")';
                break;
            case 6:
                element.style.border = 'solid 1.5px black';
                element.style.backgroundImage = 'url("../img/bar.png")';
                break;
            case 7:
                element.style.border = 'solid 1.5px black';
                element.style.backgroundImage = 'url("../img/Seven.png")';
                break;
            default:
                
                element.style.backgroundImage = "none";
                element.style.border = "none";
                break;

        }
            element.style.backgroundSize = 'contain,cover';
    }
    
}


SetBacground();
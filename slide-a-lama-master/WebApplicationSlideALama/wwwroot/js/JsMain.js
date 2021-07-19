function validateForm() {
    var x = document.forms["myForm"]["name"]["age"]["country"]["comment"].value;
    if (x == null || x == "") {
        alert("You must fill in the field");
        return false;
    }
}

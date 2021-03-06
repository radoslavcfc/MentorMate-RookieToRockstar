//Initialize home content
var homeHtml = document.getElementById("home");
var mainDoc = document.getElementById("mainArea");

function Initialize(){
    mainDoc.innerHTML = homeHtml.innerHTML;
}

Initialize();

//DropDown function:
var dropdown = document.getElementsByClassName("dropdown-btn");
var i;

for (i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function() {
       this.classList.toggle("active");
       var dropdownContent = this.nextElementSibling;
       if (dropdownContent.style.display === "block") {
          dropdownContent.style.display = "none";
       } 
       else {
           dropdownContent.style.display = "block";
       }
    });
}

//Main content toggle function

function Toggle(currentId){
    var currentElement = document.getElementById(currentId);
    mainDoc.innerHTML = currentElement.innerHTML;
}
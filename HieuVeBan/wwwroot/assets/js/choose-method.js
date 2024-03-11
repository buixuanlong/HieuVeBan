var modal = document.getElementById("hollandPopup");
var modal1 = document.getElementById("mbtiPopup");
var modalHolland = document.getElementById("holland_modal");
var modalMBTI = document.getElementById("mbti_modal");

// Get the button that opens the modal
var btnShowHollandModal = document.getElementById("holland_modal");
var btnShowMBTIModal = document.getElementById("mbti_modal");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
var span1 = document.getElementsByClassName("close1")[0];

// When the user clicks the button, open the modal
btnShowHollandModal.onclick = function () {
    modal.style.display = "block";
}
btnShowMBTIModal.onclick = function () {
    modal1.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}
span1.onclick = function () {
    modal1.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
    if (event.target == modal1) {
        modal1.style.display = "none";
    }
}

$('#hrefHolland').on('click', function (e) {
    if (e.target != modalHolland) {
        window.location = '/phuong-phap-dinh-huong-nghe-nghiep/holland/';
    }
});

$('#hrefMBTI').on('click', function (e) {
    if (e.target != modalMBTI) {
        window.location = '/phuong-phap-dinh-huong-nghe-nghiep/mbti/';
    }
});
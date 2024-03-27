// JavaScript
const cenbuton = document.getElementById("cenbuton");
cenbuton.addEventListener("click", openPopup);

function openPopup() {
    const popup = document.getElementById("popup");
    popup.style.display = "block";
}

function submitForm() {
    const name1 = document.getElementById("name1").value;
    const name2 = document.getElementById("name2").value;
    const email = document.getElementById("email").value;
    const number = document.getElementById("number").value;


    // Perform any required data validation or processing
    // You can then send this data to a server or perform any desired action

    // Close the popup
    const popup = document.getElementById("popup");
    popup.style.display = "none";
}

//neshto
function submitForm() {
    // Get the input values
    var name1 = document.getElementById("name1").value;
    var name2 = document.getElementById("name2").value;
    var email = document.getElementById("email").value;
    var number = document.getElementById("number").value;

    // Get the error message containers
    var name1Error = document.getElementById("name1-error");
    var name2Error = document.getElementById("name2-error");
    var emailError = document.getElementById("email-error");
    var numberError = document.getElementById("number-error");

    // Reset the input values
    document.getElementById("name1").value = "";
    document.getElementById("name2").value = "";
    document.getElementById("email").value = "";
    document.getElementById("number").value = "";

    // Reset error messages and field highlights
    name1Error.textContent = "";
    name1Error.style.display = "none";
    name2Error.textContent = "";
    name2Error.style.display = "none";
    emailError.textContent = "";
    emailError.style.display = "none";
    numberError.textContent = "";
    numberError.style.display = "none";

    // Check if all fields are filled in
    if (name1 !== "" && name2 !== "" && number !== "") {
        // All fields are filled in, submit the form
        var messageElement = document.getElementById("message");
        messageElement.textContent = "Успешна резервация!";
        messageElement.style.marginTop = "10px";
        messageElement.style.color = "green";
        messageElement.style.fontWeight = "bold";
        messageElement.style.fontSize = "25";
        messageElement.style.transition = "opacity 2s";
        messageElement.style.opacity = "1";

        setTimeout(function () {
            messageElement.style.opacity = "0";
        }, 2000);

        // Close the popup
        document.getElementById("popup").style.display = "none";
    } else {
        // Some fields are empty, display an error message
        if (name1 === "") {
            name1Error.textContent = "Моля въведете име!";
            name1Error.style.display = "block";
            document.getElementById("name1").style.border = "1px solid red";
        }
        if (name2 === "") {
            name2Error.textContent = "Моля въведете фамилия!";
            name2Error.style.display = "block";
            document.getElementById("name2").style.border = "1px solid red";
        }
        if (email === "") {
            emailError.textContent = "Моля въведете имейл!";
            emailError.style.display = "block";
            document.getElementById("email").style.border = "1px solid red";
        }
        if (number === "") {
            numberError.textContent = "Моля въведете телефонен номер!";
            numberError.style.display = "block";
            document.getElementById("number").style.border = "1px solid red";
        }
    }
}
function openPopup() {
    const popup = document.getElementById("popup");

    // Create the close button element
    const closeButton = document.createElement("span");
    closeButton.textContent = "X";
    closeButton.style.cursor = "pointer";

    // Add inline CSS for positioning the close button in the corner
    closeButton.style.position = "absolute";
    closeButton.style.top = "5px";
    closeButton.style.right = "5px";
    closeButton.style.padding = "5px";

    // Add an event listener to hide the popup when the close button is clicked
    closeButton.addEventListener("click", function () {
        popup.style.display = "none";
    });

    // Append the close button to the popup
    popup.appendChild(closeButton);

    // Display the popup
    popup.style.display = "block";
}


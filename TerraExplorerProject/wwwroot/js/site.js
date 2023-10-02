document.addEventListener("DOMContentLoaded", function () {
    var cardTextElements = document.querySelectorAll(".card-text");

    cardTextElements.forEach(function (cardText) {
        var textContent = cardText.textContent;

        // Check if the text content is longer than 30 characters
        if (textContent.length > 30) {
            // Truncate the text and add "..."
            var truncatedText = textContent.substring(0, 30) + "...";
            cardText.textContent = truncatedText;
        }
    });
});





// Get the navbar element
const navbar = document.getElementById("navbar");

// Add a scroll event listener
window.addEventListener("scroll", () => {
    // Check if the user has scrolled down by 100vh (viewport height)
    if (window.scrollY >= window.innerHeight) {
        // If yes, display the navbar
        navbar.style.display = "block";
    } else {
        // Otherwise, hide the navbar
        navbar.style.display = "none";
    }
});



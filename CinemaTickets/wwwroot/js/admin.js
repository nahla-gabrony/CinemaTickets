/* -------------------------------  Show Image after Select it ---------------------------------*/
const formImage = document.getElementById("form-image");
const imageURL = document.getElementById("image-url");
if (imageURL != null) {
    imageURL.addEventListener("change", (event) => {
        formImage.src = URL.createObjectURL(event.target.files[0]);
        formImage.style.visibility = "visible";
        imageURL.classList.remove("hide-file-name");
    })
}



/* -------------------------------------Initialize toasts -----------------------------------------------*/
window.onload = (event) => {
    let myAlert = document.querySelector('.toast');
    if (myAlert != null) {
            let bsAlert = new bootstrap.Toast(myAlert);
            bsAlert.show();
    }
}

/* ----------------------------------------------Active Movie Buttons --------------------------------------------------*/
window.addEventListener('load', () => {
   
    const currentElement = window.location.pathname.split('/');
    let Element = "";
    if (currentElement.length > 2) {
         Element = currentElement[2];
    }
    else {
         Element = currentElement[1];
    }
    const currentLink = document.getElementById(Element);
    const movieBtn = document.querySelectorAll(".movie-btn");
    if (currentLink != null) {
        
        movieBtn.forEach(btn => {
            btn.classList.remove("active");
        })
        currentLink.classList.add("active");
    }
});
/* ---------------------------------------------- Booking Seats --------------------------------------------------*/
const ticketNumber = document.getElementById("ticket-number");
const List = document.getElementById("tickets-list");
const reservedTickets = document.querySelectorAll("#reserved_tickets li");
const seats = document.querySelectorAll(".seat");
let count = 0;
let ticketList = [];
if (seats != null) {
    seats.forEach(seat => {
        seat.addEventListener("click", () => {
            if (!seat.classList.contains("reserved")) {
                seat.classList.toggle("booked");
                if (!seat.classList.contains("booked")) {
                    count -= 1;
                    ticketNumber.innerText = count;
                    // Remove Site number from list
                    var index = ticketList.indexOf(seat.id);
                    if (index !== -1) {
                        ticketList.splice(index, 1);
                    }
                }
                else {
                    count += 1;
                    ticketNumber.innerText = count;
                    // Add Site number from list
                    ticketList.push(seat.id);
                    List.insertAdjacentHTML('beforeend', `<option value="${seat.id}" selected>${seat.id}</option>`);
                }

            }
        });
    /* ---------------------------------------------- Reserved Seats --------------------------------------------------*/
        if (reservedTickets != null) {
            reservedTickets.forEach(x => {
                if (seat.id == x.getAttribute("value")) {
                    seat.classList.add('reserved');
                }
            });
        }
    });
}
/* ---------------------------------------------- Add form Section height --------------------------------------------------*/
const section = document.querySelector(".section");
if (section != null) {
    window.addEventListener("load", function () {
        const navbar = document.querySelector(".navbar");
        const footer = document.querySelector(".footer");
        if (navbar !== null && footer !== null) {
            const sectionHeight = window.innerHeight - navbar.offsetHeight - footer.offsetHeight;
            section.style.height = sectionHeight + "px";
        }
    });
}

/* ----------------------------------Add Color to Navbar after scroll -----------------------------------------*/
const navbar = document.getElementById("navbar");
const dropdownMenu = document.getElementById("dropdown-menu");
const mainSection = document.getElementById("section-header");

//if (navbar != null && dropdownMenu != null && mainSlide != null) {

document.addEventListener("scroll", () => {
   
    let scrollHeight = window.pageYOffset;
    if (mainSection != null) {;
        if (scrollHeight > mainSection.offsetHeight) {
            navbar.classList.add('nav-active');
            if (dropdownMenu != null) {
                dropdownMenu.classList.add('active');
            }
                
        } else {
            navbar.classList.remove('nav-active');
            if (dropdownMenu != null) {
                dropdownMenu.classList.remove('active');
            }
        }
    } else {
        navbar.classList.add('nav-active');
        if (dropdownMenu != null) {
            dropdownMenu.classList.add('active');
        }
    }
});


/* ------------------------------- Slides ---------------------------------*/
let slideIndex = 0;
let slidePlay = true;

const mainSlides = document.querySelector(".mainSlides");
const imgSlides = document.querySelectorAll(".slide");
const slideBtns = document.querySelectorAll(".slide-btn");
const slideNext = document.querySelector(".slide-next");
const slidePrev = document.querySelector(".slide-prev");
const carouselItem = document.querySelector(".carousel-item");
if (carouselItem !=null) {
    imgSlides[0].classList.add("active");
    slideBtns[0].classList.add("active");

    hideAllSlide = () => {
        imgSlides.forEach((slide) => {
            slide.classList.remove("active");
        });

        slideBtns.forEach((btn) => {
            btn.classList.remove("active");
        });
    };

    showSlide = () => {
        hideAllSlide();
        imgSlides[slideIndex].classList.add("active");
        slideBtns[slideIndex].classList.add("active");
    };

    nextSlide = () =>
        (slideIndex = slideIndex + 1 === imgSlides.length ? 0 : slideIndex + 1);

    prevSlide = () =>
        (slideIndex = slideIndex - 1 < 0 ? imgSlides.length - 1 : slideIndex - 1);

    /* play/stop slider */
    mainSlides.addEventListener("mouseover", () => (slidePlay = false));
    mainSlides.addEventListener("mouseleave", () => (slidePlay = true));

    /* Slider Control */
    slideNext.addEventListener("click", () => {
        nextSlide();
        showSlide();
    });
    slidePrev.addEventListener("click", () => {
        prevSlide();
        showSlide();
    });

    setInterval(() => {
        if (!slidePlay) return;
        nextSlide();
        showSlide();
    }, 3000);
}





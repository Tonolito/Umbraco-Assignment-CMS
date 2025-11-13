document.addEventListener("DOMContentLoaded", function () {
    const cards = document.querySelectorAll(".expert-card");
    const prevBtn = document.querySelector(".prev-btn");
    const nextBtn = document.querySelector(".next-btn");
    const pageInfo = document.querySelector(".page-info");

    const cardsPerPage = 3; // antal kort per sida på mobil
    let currentPage = 1;

    function isMobile() {
        return window.innerWidth < 768;
    }

    function showPage(page) {
        const totalPages = Math.ceil(cards.length / cardsPerPage);

        if (!isMobile()) {
            // Visa alla kort på desktop
            cards.forEach((card) => (card.style.display = "block"));
            pageInfo.textContent = "";
            return;
        }

        // Visa rätt kort på mobil
        const start = (page - 1) * cardsPerPage;
        const end = start + cardsPerPage;

        cards.forEach((card, index) => {
            card.style.display = index >= start && index < end ? "block" : "none";
        });

        pageInfo.textContent = `Page ${page} of ${totalPages}`;
        prevBtn.disabled = page === 1;
        nextBtn.disabled = page === totalPages;
    }

    prevBtn.addEventListener("click", () => {
        if (currentPage > 1) {
            currentPage--;
            showPage(currentPage);
        }
    });

    nextBtn.addEventListener("click", () => {
        const totalPages = Math.ceil(cards.length / cardsPerPage);
        if (currentPage < totalPages) {
            currentPage++;
            showPage(currentPage);
        }
    });

    window.addEventListener("resize", () => {
        currentPage = 1;
        showPage(currentPage);
    });

    showPage(currentPage);
});

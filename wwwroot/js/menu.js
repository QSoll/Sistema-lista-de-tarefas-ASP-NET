window.iniciarMenuHamburguer = function () {
    const menuToggle = document.getElementById('menu-toggle');
    const menu = document.getElementById('hamburguer-menu');

    if (menuToggle && menu) {
        menuToggle.addEventListener('click', () => {
            menu.style.display = menu.style.display === 'flex' ? 'none' : 'flex';
        });
    }

    document.querySelectorAll('.submenu-toggle').forEach(button => {
        const targetId = button.getAttribute('data-target');
        const submenu = document.getElementById(targetId);
        if (submenu) {
            button.addEventListener('click', () => {
                submenu.style.display = submenu.style.display === 'flex' ? 'none' : 'flex';
            });
        }
    });
};

document.addEventListener("DOMContentLoaded", function () {
    window.iniciarMenuHamburguer();
});


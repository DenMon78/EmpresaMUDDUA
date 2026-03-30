/* ═══════════════════════════════════════════════════
   MUDDUA — JavaScript del sitio
   ═══════════════════════════════════════════════════ */

document.addEventListener('DOMContentLoaded', function () {

    /* ── 1. Navbar sombra al hacer scroll ─────── */
    const navbar = document.getElementById('main-navbar');
    window.addEventListener('scroll', function () {
        if (navbar) {
            navbar.style.boxShadow = window.scrollY > 20
                ? '0 4px 16px rgba(0,0,0,.1)'
                : '0 1px 4px rgba(0,0,0,.06)';
        }
    });

    /* ── 2. Marcar link activo en el navbar ───── */
    const ruta = window.location.pathname.toLowerCase();
    document.querySelectorAll('.nav-pill-link').forEach(link => {
        const href = link.getAttribute('href')?.toLowerCase();
        if (!href) return;
        const esInicio = (href === '/' || href.includes('index'));
        if (esInicio) {
            if (ruta === '/' || ruta === '/home/index' || ruta === '/home') {
                link.classList.add('active');
            }
        } else if (ruta.includes(href.replace('/home/', '').toLowerCase())) {
            link.classList.add('active');
        }
    });

    /* ── 3. Animaciones de entrada (scroll) ───── */
    const elementos = document.querySelectorAll('.fade-in');
    if ('IntersectionObserver' in window) {
        const obs = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (!entry.isIntersecting) return;
                const delay = parseInt(entry.target.style.animationDelay) || 0;
                setTimeout(() => entry.target.classList.add('visible'), delay);
                obs.unobserve(entry.target);
            });
        }, { threshold: 0.1 });
        elementos.forEach(el => obs.observe(el));
    } else {
        // Fallback para navegadores sin soporte
        elementos.forEach(el => el.classList.add('visible'));
    }

    /* ── 4. Botón de contacto: feedback visual ── */
    const form = document.querySelector('form[action*="EnviarContacto"]');
    if (form) {
        form.addEventListener('submit', function () {
            const btn = form.querySelector('button[type="submit"]');
            if (btn) {
                btn.disabled = true;
                btn.innerHTML = '<span class="spinner-border spinner-border-sm me-2"></span>Enviando...';
            }
        });
    }

});
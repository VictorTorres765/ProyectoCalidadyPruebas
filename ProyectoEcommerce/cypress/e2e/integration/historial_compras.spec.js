describe('Prueba ver historial de compras', () => {
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Prevenir que Cypress falle la prueba en caso de errores inesperados
        return false;
    });

    it('Iniciar sesión y verificar sección de Mis Compras', () => {
        // Abrir la página web
        cy.visit('https://localhost:7157');

        // Hacer clic en el ícono del menú (toggler)
        cy.get('.navbar-toggler-icon').click();

        // Hacer clic en el enlace "Iniciar Sesión"
        cy.contains('Iniciar Sesión').click();

        // Completar los campos de inicio de sesión
        cy.get('#Username').type('user@gmail.com');
        cy.get('#Password').type('user123');

        // Hacer clic en el botón de inicio de sesión
        cy.get('.btn-primary').click();

        // Hacer clic en el ícono del menú (toggler)
        cy.get('.navbar-toggler-icon').click();

        // Verificar que el saludo con el nombre de usuario esté presente
        cy.get('.nav-link > strong').should('contain.text', 'Hola! user@gmail.com');

        // Hacer clic en "Mis Compras"
        cy.contains('Mis Compras').click();

        // Verificar que el título de la página de pedidos esté presente
        cy.get('.card-title').should('contain.text', 'Tus Pedidos (user@gmail.com)');

        // Cerrar sesión
        cy.get('.navbar-toggler-icon').click();
        cy.contains('Cerrar Sesión').click();
    });
});

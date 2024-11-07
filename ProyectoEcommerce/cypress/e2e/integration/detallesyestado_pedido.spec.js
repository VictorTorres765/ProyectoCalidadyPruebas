describe('Prueba ver estado y detalles de pedido', () => {
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Prevenir que Cypress falle la prueba en caso de errores inesperados
        return false;
    });

    it('Iniciar sesión y verificar pedidos', () => {
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

        // Verificar que el nombre de usuario esté visible en la barra de navegación
        cy.get('.navbar-toggler-icon').click();
        cy.get('.nav-link > strong').should('contain.text', 'Hola! user@gmail.com');

        // Hacer clic en "Mis Compras"
        cy.contains('Mis Compras').click();

        // Verificar que el título de la página de pedidos esté presente
        cy.get('.card-title').should('contain.text', 'Tus Pedidos (user@gmail.com)');

        // Verificar el estado del pedido y su descripción
        cy.get('.odd:nth-child(1) .btn').click();
        cy.get('.pb-3 > h4:nth-child(1)').should('contain.text', 'Pedido');
        cy.get('.col-sm-2:nth-child(9)').should('contain.text', 'EstadoPedido');

        // Cerrar sesión
        cy.get('.navbar-toggler-icon').click();
        cy.contains('Cerrar Sesión').click();
    });
});

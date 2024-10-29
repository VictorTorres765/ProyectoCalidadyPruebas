describe('Prueba de registro de usuario', () => {
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Devuelve false para prevenir que Cypress falle la prueba
        return false;
    });

    it('Registrar un nuevo usuario', () => {
        // Abrir la página web
        cy.visit('https://localhost:7157');

        // Hacer clic en el ícono del menú (toggler)
        cy.get('.navbar-toggler-icon').click();

        // Hacer clic en el enlace "Iniciar Sesión"
        cy.contains('Iniciar Sesión').click();

        // Hacer clic en el enlace "Registrar Nuevo Usuario"
        cy.contains('Registrar Nuevo Usuario').click();

        // Asegurarse de que el título de la página esté presente
        cy.get('h4').should('exist');

        // Verificar el texto "Registrar Usuario"
        cy.get('h4').contains('Registrar Usuario');

        // Generar un correo y nombre de usuario aleatorio y guardarlos en una variable
        cy.generateUser().then((user) => {
            // Completar el formulario de registro con los valores generados
            cy.get('#Username').type(user.email);
            cy.get('#Password').type('123456');
            cy.get('#PasswordConfirm').type('123456');
            cy.get('#Nombre').type(user.name);
            cy.get('#PhoneNumber').type('911222618');

            // Hacer clic en el botón de registro
            cy.get('.btn-sm').click();

            // Hacer clic en el ícono del menú (toggler) para verificar el usuario
            cy.get('.navbar-toggler-icon').click();

            // Verificar que el mensaje de bienvenida contenga el correo generado
            cy.get('.nav-link > strong').should('contain.text', `Hola! ${user.email}`);
        });
    });
});
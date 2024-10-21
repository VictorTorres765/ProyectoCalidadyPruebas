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

        // Completar el formulario de registro
        cy.get('#Username').type('cypresst2@gmail.com');
        cy.get('#Password').type('123456');
        cy.get('#PasswordConfirm').type('123456');

        cy.get('#Nombre').type('cypresst2');
        cy.get('#PhoneNumber').type('911222618');

        // Subir una imagen de perfil, en este caso es opcional
        //cy.get('input[name="Imagen"]').attachFile('C:/Users/Denys/Pictures/Imágenes Usuarios/user1sel.jiff');

        // Hacer clic en el botón de registro
        cy.get('.btn-sm').click();

        // Hacer clic en el ícono del menú (toggler) para verificar el usuario
        cy.get('.navbar-toggler-icon').click();

        // Verificar que el mensaje de bienvenida aparezca
        cy.get('.nav-link > strong').should('contain.text', 'Hola! cypresst2@gmail.com');
    });
});

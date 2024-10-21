describe('Test de agregar categorías ', () => {
    // Manejar las excepciones no capturadas
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Devuelve false para prevenir que Cypress falle la prueba
        return false;
    });

    it('Debería iniciar sesión, verificar el título y crear una categoría', () => {
        // Abrir la URL
        cy.visit('https://localhost:7157');

        // Hacer clic en el icono del navbar
        cy.get('.navbar-toggler-icon').should('be.visible').click();

        // Hacer clic en el enlace de "Iniciar Sesión"
        cy.contains('Iniciar Sesión').should('be.visible').click();

        // Ingresar el correo electrónico en el campo de Username
        cy.get('#Username').should('be.visible').type('admin@gmail.com');

        // Ingresar la contraseña en el campo de Password
        cy.get('#Password').should('be.visible').type('123456');

        // Hacer clic en el botón de "Iniciar Sesión"
        cy.get('.btn-primary').should('be.visible').click();

        // Hacer clic en el icono del navbar nuevamente
        cy.get('.navbar-toggler-icon').should('be.visible').click();

        // Verificar que el elemento con clase .nav-link > strong está presente
        cy.get('.nav-link > strong').should('exist');

        // Verificar que el texto del elemento es "Hola! admin@gmail.com"
        cy.get('.nav-link > strong').should('have.text', 'Hola! admin@gmail.com');

        // Hacer clic en el dropdown del navbar
        cy.get('#offcanvasNavbarDropdown').should('be.visible').click();

        // Hacer clic en el enlace de "Categorías"
        cy.contains('Categorías').should('be.visible').click();

        // Verificar que el elemento de la lista de categorías está presente
        cy.get('.mb-0').should('exist');

        // Verificar que el texto del elemento es "Lista de Categorías"
        cy.get('.mb-0').should('have.text', 'Lista de Categorías');

        // Hacer clic en el enlace de "Agregar Categoría"
        cy.contains('Agregar Categoría').should('be.visible').click();

        // Verificar que el título "Crear Categoría" está presente
        cy.get('.col-md-12 h5').should('exist');

        // Verificar que el texto del encabezado es "Crear Categoría"
        cy.get('.col-md-12 h5').should('contain.text', 'Crear Categoría');

        // Hacer clic en el campo de nombre de la categoría
        cy.get('#nombre').should('be.visible').click();

        // Escribir "Autobiografía" en el campo de nombre
        cy.get('#nombre').type('PruebaCypress', { delay: 0 });

        // Hacer clic en el botón de "Crear"
        cy.get('.btn-success').should('be.visible').click();

        // Verificar que la alerta de éxito está presente
        cy.get('.alert').should('exist');

        // Verificar que el texto de la alerta es "Éxito! Categoría creada exitosamente!!!"
        cy.get('.alert').should('contain.text', 'Éxito! Categoría creada exitosamente');

        // Esperar 10 segundos antes de continuar e ir a la pestaña 2 para verificar
        cy.wait(10000);

        // Eliminar
        cy.deleteCategory();
    });
});

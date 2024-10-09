describe('Test de detalles del libro', () => {
    // Manejar las excepciones no capturadas para que no interrumpan la prueba
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Devuelve false para evitar que Cypress falle la prueba
        return false;
    });

    it('Debería abrir la página, hacer clic en el enlace y verificar el encabezado', () => {
        // Paso 1: Abrir la URL
        cy.visit('https://localhost:7157');

        // Paso 2: Hacer clic en el enlace con el texto "Ver Detalles"
        cy.contains('Ver Detalles').click();

        // Paso 3: Verificar que el elemento con el selector .card-header > h5 está presente
        cy.get('.card-header > h5').should('exist');

        // Paso 4: Verificar que el texto del elemento es "Detalles del Libro"
        cy.get('.card-header > h5').should('have.text', 'Detalles del Libro');
    });
});

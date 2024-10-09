describe('Página principal', () => {
    beforeEach(() => {
        Cypress.on('uncaught:exception', (err, runnable) => {
            // Retorna false para prevenir que Cypress falle el test
            return false;
        });
    });

    it('Carga la página principal correctamente', () => {
        cy.visit('https://localhost:7157/'); // Se asegura de que la app esté corriendo
        cy.contains('Tienda de Libros'); // Verifica el título de 'Tienda'
    });
});

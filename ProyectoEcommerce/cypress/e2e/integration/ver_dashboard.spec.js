describe('examen', () => {
    beforeEach(() => {
        Cypress.on('uncaught:exception', (err, runnable) => {
            return false;
        });
    });

    it('ver dashboard', () => {
        cy.visit('https://localhost:7157/');
        cy.get('.navbar-toggler-icon').click();
        cy.contains('Iniciar Sesión').click();
        cy.get('#Username').type('admin@gmail.com');
        cy.get('#Password').type('123456');
        cy.get('.btn-primary').click();
        cy.get('.navbar-toggler-icon').click();
        cy.get('#offcanvasNavbarDropdown').click();
        cy.contains('Dashboard').click();    
    });
});

Cypress.Commands.add('deleteCategory', () => {
    // Click on the link with text "2"
    cy.contains('2').should('be.visible').click();

    // Click on the delete button using its CSS selector
    cy.get('.even .btn-outline-danger > .fa').should('be.visible').click();

    // Confirm the deletion by clicking the "Yes" button
    cy.get('#btnYesDelete').should('be.visible').click();
});

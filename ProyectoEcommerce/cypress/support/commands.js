Cypress.Commands.add('deleteCategory', () => {
    // Click on the link with text "2"
    cy.contains('2').should('be.visible').click();

    // Click on the delete button using its CSS selector
    cy.get('.even .btn-outline-danger > .fa').should('be.visible').click();

    // Confirm the deletion by clicking the "Yes" button
    cy.get('#btnYesDelete').should('be.visible').click();
});

//ELIMINAR UN LIBRO CREADO RECIENTEMENTE  (CREAR-LIBRO)
Cypress.Commands.add('eliminarLibroReciente', () => {
    // Hacer clic en el enlace de paginación "2"
    cy.contains('2').click();

    // Hacer clic en el botón de eliminar del cuarto elemento en la fila par
    cy.get('.even:nth-child(4) .btn-outline-danger').click();

    // Confirmar la eliminación haciendo clic en el botón "Sí" en el modal
    cy.get('#btnYesDelete').click();
});


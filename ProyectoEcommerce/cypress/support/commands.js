Cypress.Commands.add('deleteCategory', () => {
    cy.get('td')  // Aumentar el tiempo de espera a 10 segundos
        .contains('ZZPruebaCypress')
        .parent()
        .within(() => {
            cy.get('button.deleteItem').click();
        });
    cy.get('#btnYesDelete').click();
});

Cypress.Commands.add('eliminarLibroReciente', () => {
    cy.get('td')  // Aumentar el tiempo de espera a 10 segundos
        .contains('ZZLibroCypress')
        .parent()
        .within(() => {
            cy.get('button.deleteItem').click();
        });
    cy.get('#btnYesDelete').click();
});

//CREAR UNA NUEVA CUENTA DE USUARIO 
Cypress.Commands.add('generateUser', () => {
    const randomStr = Math.random().toString(36).substring(2, 15);
    const email = `${randomStr}@gmail.com`;
    const name = randomStr;

    return { email, name };
});

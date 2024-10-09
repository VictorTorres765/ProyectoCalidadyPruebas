describe('Añadir y comprar en el carrito', () => {
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Devuelve false para prevenir que Cypress falle la prueba
        return false;
    });
    it('should complete the order process', () => {
        // Abrir la página
        cy.visit('https://localhost:7157');

        // Abrir el menú de navegación
        cy.get('.navbar-toggler-icon').click();

        // Hacer clic en "Iniciar Sesión"
        cy.contains('Iniciar Sesión').click();

        // Ingresar nombre de usuario y contraseña
        cy.get('#Username').type('user@gmail.com');
        cy.get('#Password').type('user123');

        // Hacer clic en el botón de inicio de sesión
        cy.get('.btn-primary').click();

        // Abrir el menú de navegación nuevamente
        cy.get('.navbar-toggler-icon').click();

        // Verificar el nombre de usuario
        cy.get('.nav-link > strong').should('contain.text', 'Hola! user@gmail.com');

        // Cerrar la ventana offcanvas
        cy.get('.offcanvas-header > .btn-close').click();

        // Hacer clic en el botón "Ver Carrito"
        cy.get('.col-lg-3:nth-child(6) .btn:nth-child(2)').click();

        // Hacer clic en "Ver Carrito (1)"
        cy.contains('Ver Carrito (1)').click();

        // Verificar que el elemento con el resumen de pedido esté presente
        cy.get('.bg-primary > h4').should('be.visible');

        // Verificar que el texto del resumen de pedido sea "Resumen de Pedido"
        cy.get('.bg-primary > h4').should('contain.text', 'Resumen de Pedido');

        // Verificar el primer ítem con la cantidad de productos
        cy.get('.col-6:nth-child(1) > h5').should('be.visible');  // Verifica que el elemento h5 esté presente
        cy.get('.col-6:nth-child(1) > h3').should('contain.text', '1');  // Verifica que la cantidad sea 1

        // Verificar el precio total del pedido
        cy.get('.col-6:nth-child(2) > h5').should('be.visible');  // Verifica que el elemento h5 esté presente
        cy.get('.col-6:nth-child(2) > h3').should('contain.text', 'S/ 76.10');  // Verifica que el precio sea S/ 76.10

        // Verificar el comentario del pedido
        cy.get('.bg-secondary > h4').should('contain.text', 'Comentario del Pedido');
        // Verificar que el texto "Carro de Compras" esté presente
        cy.get('h3:nth-child(1)').should('contain.text', 'Carro de Compras');

        // Almacenar una variable y mostrarla en la consola
        let myvar = 1;
        cy.log(myvar);


        // Añadir un comentario
        cy.get('#Comentario').type('El libro debe ser de la edición de tapa dura');

        // Finalizar el pedido
        cy.get('.btn-outline-primary').click();

        // Verificar mensaje de éxito
        cy.get('h2').should('contain.text', '¡Gracias!');
        cy.get('.card-body').should('contain.text', 'Su pedido fue registrado con éxito');
    });
});

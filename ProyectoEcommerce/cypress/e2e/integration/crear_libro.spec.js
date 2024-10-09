describe('Prueba de flujo - Creación de Libro', () => {
        Cypress.on('uncaught:exception', (err, runnable) => {
            // Devuelve false para prevenir que Cypress falle la prueba
            return false;
        });
    it('should complete the book creation process', () => {
        // Abrir la página
        cy.visit('https://localhost:7157');

        // Abrir el menú de navegación
        cy.get('.navbar-toggler-icon').click();

        // Hacer clic en "Iniciar Sesión"
        cy.contains('Iniciar Sesión').click();

        // Ingresar nombre de usuario y contraseña
        cy.get('#Username').type('admin@gmail.com');
        cy.get('#Password').type('123456');

        // Hacer clic en el botón de inicio de sesión
        cy.get('.btn-primary').click();

        // Abrir el menú de navegación nuevamentes
        cy.get('.navbar-toggler-icon').click();

        // Verificar que el nombre de usuario esté presente
        cy.get('.nav-link > strong').should('contain.text', 'Hola! admin@gmail.com');

        // Hacer clic en el dropdown del menú de usuario
        cy.get('#offcanvasNavbarDropdown').click();

        // Hacer clic en el enlace de "Libros"
        cy.contains('Libros').click();

        // Verificar que la lista de libros esté presente
        cy.get('.card-header > h5').should('contain.text', 'Lista de Libros');

        // Hacer clic en el botón para crear un nuevo libro
        cy.get('p > .btn').click();

        // Verificar que el texto "Crear Libro" esté presente
        cy.get('.col-md-12:nth-child(1) h5').should('contain.text', 'Crear Libro');

        // Ingresar el nombre del libro
        cy.get('#Nombre').type('LibroPrueba');

        // Seleccionar la categoría
        cy.get('#CategoriaId').select('3');

        // Ingresar la descripción del libro
        cy.get('#Descripcion').type('Descripcion del libro de prueba');

        // Ingresar el precio
        cy.get('#Precio').type('62.10');

        // Ingresar la cantidad en inventario
        cy.get('#Inventario').type('27');

        // Cargar una imagen
        cy.get('input[name="Imagen"]').attachFile('C:\\Users\\Denys\\Pictures\\Imágenes Libros\\corazon.webp');

        // Hacer clic en el botón de guardar
        cy.get('.btn-success').click();
    });
});

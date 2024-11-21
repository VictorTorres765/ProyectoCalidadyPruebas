//describe('examen', () => {
//    beforeEach(() => {
//        Cypress.on('uncaught:exception', (err, runnable) => {
//            return false;
//        });
//    });

//    it('subir imagen', () => {
//        cy.visit('https://localhost:7157/');
//        cy.contains('Tienda de Libros');
//        cy.get('.navbar-toggler-icon').should('be.visible').click();
//        cy.contains('Iniciar Sesión').click();
//        cy.get('#Username').should('be.visible').type('admin@gmail.com');
//        cy.get('#Password').should('be.visible').type('123456');
//        cy.get('.btn-primary').click();
//        cy.get('.navbar-toggler-icon').should('be.visible');
//        cy.get('.navbar-toggler-icon').should('be.visible').click();
//        cy.get('.nav-link > strong').should('exist');
//        cy.get('.nav-link > strong').should('have.text', 'Hola! admin@gmail.com');
//        cy.get('#offcanvasNavbarDropdown').click();
//        cy.contains('Categorías').should('be.visible').click();
//        cy.contains('Agregar Categoría').click();
//        cy.get('h5').should('contain.text', 'Crear Categoría');
//        cy.get('#nombre').type('zzexamen');
//        cy.contains('Guardar').click();
//    });
//});

//describe('examen', () => {
//    beforeEach(() => {
//        Cypress.on('uncaught:exception', (err, runnable) => {
//            return false;
//        });
//    });

//it('crear usuario', () => {
//    cy.visit('https://localhost:7157/');
//    cy.get('.navbar-toggler-icon').click();
//    cy.contains('Iniciar Sesión').click();
//    cy.contains('Registrar Nuevo Usuario').click();
//    cy.get('#Username').type('internet');
//    cy.get('#Password').type('123456');
//    cy.get('#PasswordConfirm').type('123456');
//    cy.get('#PhoneNumber').type('937467312');
//    cy.contains('Registrar').click();
//    });
//});

//describe('examen', () => {
//    beforeEach(() => {
//        Cypress.on('uncaught:exception', (err, runnable) => {
//            return false;
//        });
//    });

//    it('crear usuario', () => {
//        cy.visit('https://localhost:7157/');

//    });
//});



//describe('examen', () => {
//    beforeEach(() => {
//        Cypress.on('uncaught:exception', (err, runnable) => {
//            return false;
//        });
//    });

//    it('crear usuario', () => {
//        cy.visit('https://localhost:7157/');
//        cy.get('.navbar-toggler-icon').click();
//        cy.get('a.nav-link.text-dark').should('contain.text', 'Iniciar Sesión').click();
//        cy.get('h4').should('contain.text', 'Iniciar Sesión');
//        cy.get('#Username').type('admin@gmail.com');
//        cy.get('#Password').type('123456');
//        cy.get('.btn.btn-primary').should('contain.text', 'Iniciar Sesión').click();
//        cy.get('.navbar-toggler-icon').click();
//        cy.contains('Menu').click();
//        cy.contains('Categorías').click();
//        cy.get('h5').should('be.visible', 'contain.text', 'Lista de Categorías');
//        cy.contains('Agregar Categoría').click();
//        cy.get('h5').should('be.visible', 'contain.text', 'Crear Categoría');
//        cy.get('#nombre').type('zzexamen');
//        cy.contains('Guardar').click();
//        cy.get('h5').should('be.visible', 'contain.text', 'Lista de Categorías');
//        cy.get('a.paginate_button.next').click();

//    });
//});

describe('examen', () => {
    beforeEach(() => {
        Cypress.on('uncaught:exception', (err, runnable) => {
            return false;
        });
    });

    it('crear usuario', () => {
        cy.visit('https://localhost:7157/');
        cy.get('.navbar-toggler-icon').click();
        cy.contains('Iniciar Sesión').click();
        cy.get('#Username').type('admin@gmail.com');
        cy.get('#Password').type('123456');
        cy.get('.btn-primary').should('contain.text', 'Iniciar Sesión').click();
        cy.get('.navbar-toggler-icon').click();
        cy.contains('Menu').click();
        cy.contains('a.dropdown-item strong', 'Libros').click();
        cy.contains("Agregar un libro").click();
        cy.get('#CategoriaId').select('2');
        cy.get('#Descripcion').type('examen');
        cy.get('.btn.btn-sm.btn-success').click();


    });
});

//describe('examen', () => {
//    beforeEach(() => {
//        Cypress.on('uncaught:exception', (err, runnable) => {
//            return false;
//        });
//    });

//it('crear usuario', () => {
//    cy.visit('https://localhost:7157/');
//    cy.get('.navbar-toggler-icon').click();
//    cy.contains('Iniciar Sesión').click();
//    cy.get('#RememberMe').click();
//    });
//});



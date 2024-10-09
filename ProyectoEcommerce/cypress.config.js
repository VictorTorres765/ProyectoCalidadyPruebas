const { defineConfig } = require("cypress");

module.exports = defineConfig({
    e2e: {
        baseUrl: 'https://localhost:7157/',  // Establece la URL base de tu servidor local
        specPattern: 'cypress/e2e/**/*.spec.js',  // Ruta correcta para las pruebas
        supportFile: 'cypress/support/e2e.js',  // Deshabilita el archivo de soporte si no lo estás usando
    },
});

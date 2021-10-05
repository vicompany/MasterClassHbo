describe('Registration', () => {
    it('Register John doe, should be registered', () => {
        // Arange
        cy.visit('/');
        cy.contains('Your email:').next().type('johndoe@vicompany.nl');
        cy.contains('Stocks').prev().click();
        cy.contains('Expected to buy:').next().clear().type('250');

        // Act
        cy.contains('Signup').click();

        // Assert
        cy.url().should('include', '/Registered');
    });

    it('Register John doe again, error should show', () => {
       // Arange
      cy.visit('/');
      cy.contains('Your email:').next().clear().type('johndoe@vicompany.nl');
      cy.contains('Expected to buy:').next().clear().type('250');

      // Act
      cy.contains('Signup').click();

      // Assert
      cy.contains('johndoe@vicompany.nl already registered');
    });

    it('Register to much amount, error should show', () => {
      // Arange 
      cy.visit('/');
      cy.contains('Your email:').next().clear().type('janedoe@vicompany.nl');
      cy.contains('Expected to buy:').next().clear().type('25000'); 

      // Act
      cy.contains('Signup').click();

      // Assert
      cy.contains(' The field Amount must be between 1 and 500.');
    });

    it('Register both interest in stocks and certifactes, error should show', () => {
      // Arange 
      cy.visit('/');
      cy.contains('Your email:').next().clear().type('janedoe@vicompany.nl');
      cy.contains('Expected to buy:').next().clear().type('250');
      cy.contains('Stocks').prev().click();
      cy.contains('Certificates').prev().click();

      // Act
      cy.contains('Signup').click();

      // Assert
      cy.contains('You can\'t choose stocks and certificates');
    });

    it('Register jane doe', () => {
      // Arange
      cy.visit('/');
      cy.contains('Your email:').next().clear().type('janedoe@vicompany.nl');
      cy.contains('Expected to buy:').next().clear().type('500');
      cy.contains('Stocks').prev().click();
      cy.contains('Derivatives').prev().click();

      // Act
      cy.contains('Signup').click();

      // Assert
      cy.url().should('include', '/Registered');
    });
  })
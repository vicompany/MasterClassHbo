describe('Overview', () => {
    it('No Items', () => {
      // Arange + Act
      cy.visit('/overview');
      
      // Assert
      cy.contains('There are no registrations yet');
    })
  })
describe('Overview', () => {
  it('Some Items', () => {
    // Arange + Act
    cy.visit('/overview');
    
    // Assert
    cy.contains('Total volume: 750');
    cy.contains('2 people are interested');
    cy.contains('2 people are interested stock');
    cy.contains('0 people are interested certificates');
    cy.contains('1 people are interested derivatives');
  })
})
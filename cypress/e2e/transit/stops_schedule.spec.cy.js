describe('Transit Stops Schedule', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001');
    });

    it('should display the correct title', () => {
        cy.contains('h1', 'Transit Stops Schedule');
    });

    it('should populate the stops dropdown', () => {
        cy.intercept('GET', '/Routes', {
            statusCode: 200,
            body: [
                { number: 1, name: 'Stop 1' },
                { number: 2, name: 'Stop 2' }
            ]
        }).as('getStops');

        cy.reload(); // Reload to trigger fetchStops

        cy.wait('@getStops');

        cy.get('#stops').should('have.length', 1);
        cy.get('#stops option').should('have.length', 3); // Including default option
        cy.get('#stops').contains('Stop 1');
        cy.get('#stops').contains('Stop 2');
    });

    it('should display an error message if no stop is selected', () => {
        cy.get('#getSchedule').click();
        cy.on('window:alert', (txt) => {
            expect(txt).to.contains('Please select a stop.');
        });
    });

    it('should fetch and display the schedule for the selected stop', () => {
        cy.intercept('GET', '/Routes', {
            statusCode: 200,
            body: [
                { number: 1, name: 'Stop 1' },
                { number: 2, name: 'Stop 2' }
            ]
        }).as('getStops');

        cy.reload(); // Reload to trigger fetchStops

        cy.wait('@getStops');

        cy.get('#stops').select('Stop 1');

        cy.intercept('GET', `/Routes/1/*`, {
            statusCode: 200,
            body: { timepoint: 1234 }
        }).as('getSchedule');

        cy.get('#getSchedule').click();
        cy.wait('@getSchedule');

        cy.get('#scheduleResult').should('contain', 'Next schedule time: 12:34');
    });

    it('should display an error message if no schedule is found', () => {
        cy.intercept('GET', '/Routes', {
            statusCode: 200,
            body: [
                { number: 1, name: 'Stop 1' },
                { number: 2, name: 'Stop 2' }
            ]
        }).as('getStops');

        cy.reload(); // Reload to trigger fetchStops

        cy.wait('@getStops');

        cy.get('#stops').select('Stop 1');

        cy.intercept('GET', `/Routes/1/*`, {
            statusCode: 404,
            body: {}
        }).as('getSchedule');

        cy.get('#getSchedule').click();
        cy.wait('@getSchedule');

        cy.get('#scheduleResult').should('contain', 'No schedule found for the selected stop.');
    });
});

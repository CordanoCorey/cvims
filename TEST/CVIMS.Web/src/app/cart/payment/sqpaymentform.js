var paymentForm;

function requestCardNonce(event) {

  // Don't submit the form until SqPaymentForm returns with a nonce
  event.preventDefault();

  // Request a nonce from the SqPaymentForm object
  paymentForm.requestCardNonce();
}

function setupSqPaymentForm(locationId, applicationId) {
  // Create and initialize a payment form object
  paymentForm = new SqPaymentForm({

    // Initialize the payment form elements
    applicationId: applicationId,
    locationId: locationId,
    inputClass: 'sq-input',

    // Customize the CSS for SqPaymentForm iframe elements
    inputStyles: [{
      fontSize: '.9em'
    }],
    // Initialize the credit card placeholders
    cardNumber: {
      elementId: 'sq-card-number',
      placeholder: '•••• •••• •••• ••••'
    },
    cvv: {
      elementId: 'sq-cvv',
      placeholder: 'CVV'
    },
    expirationDate: {
      elementId: 'sq-expiration-date',
      placeholder: 'MM/YY'
    },
    postalCode: {
      elementId: 'sq-postal-code'
    },

    // SqPaymentForm callback functions
    callbacks: {

      /*
       * callback function: cardNonceResponseReceived
       * Triggered when: SqPaymentForm completes a card nonce request
       */
      cardNonceResponseReceived: function (errors, nonce, cardData) {
        if (errors) {
          // Log errors from nonce generation to the Javascript console
          console.log("Encountered errors:");
          errors.forEach(function (error) {
            console.log('  ' + error.message);
          });

          return;
        }
        // Assign the nonce value to the hidden form field
        document.getElementById('card-nonce').value = nonce;
        localStorage.setItem('CVIMS_SQUARE_NONCE', nonce);
      },

      /*
       * callback function: unsupportedBrowserDetected
       * Triggered when: the page loads and an unsupported browser is detected
       */
      unsupportedBrowserDetected: function () {
        /* PROVIDE FEEDBACK TO SITE VISITORS */
      },

      /*
       * callback function: inputEventReceived
       * Triggered when: visitors interact with SqPaymentForm iframe elements.
       */
      inputEventReceived: function (inputEvent) {
        switch (inputEvent.eventType) {
          case 'focusClassAdded':
            /* HANDLE AS DESIRED */
            break;
          case 'focusClassRemoved':
            /* HANDLE AS DESIRED */
            break;
          case 'errorClassAdded':
            /* HANDLE AS DESIRED */
            break;
          case 'errorClassRemoved':
            /* HANDLE AS DESIRED */
            break;
          case 'cardBrandChanged':
            /* HANDLE AS DESIRED */
            break;
          case 'postalCodeChanged':
            /* HANDLE AS DESIRED */
            break;
        }
      },

      /*
       * callback function: paymentFormLoaded
       * Triggered when: SqPaymentForm is fully loaded
       */
      paymentFormLoaded: function () {
        /* HANDLE AS DESIRED */
      }
    }
  });

  paymentForm.build();
}

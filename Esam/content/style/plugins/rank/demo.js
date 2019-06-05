jQuery(document).ready(function($) {


    // Custom options
    $('.rate-circle').rateCircle({
        size: 24, // Sets the size of the circle
        lineWidth: 2, // Sets the width of circle line
        fontSize: 0, // Font size of rate value
        referenceValue: 100, // Used to calculate color and percentage
        valuePrefix: '', // Sets a text before the rate value
        valueSufix: '' // Sets a text after the rate value
    });
  
  $('.rate-circle-1').rateCircle({
        size: 24, // Sets the size of the circle
        lineWidth: 2, // Sets the width of circle line
        fontSize: 0, // Font size of rate value
        referenceValue: 100, // Used to calculate color and percentage
        valuePrefix: '', // Sets a text before the rate value
        valueSufix: '' // Sets a text after the rate value
    });


   
});

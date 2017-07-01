function createViewModel(response) {
    window.RescueViewModel = new Vue({
        el: '#puppies',
        data: response,
    });
}

$.when(
    $.ajax('http://api.adoptapet.com/search/pets_at_shelter?key=8059dcbb48596dd74e3f424368018f42&output=json&shelter_id=95658'), 
    $.ajax('http://api.adoptapet.com/search/pets_at_shelter?key=dc618ad6fe052fe942eff360409180c6&output=json&shelter_id=95500')
    ).then( function(nyResponse, txResponse) {
        // TODO: Merge the data from these calls.
        createViewModel(txResponse[0]);
    });
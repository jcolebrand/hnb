function createViewModel(response) {
    window.RescueViewModel = new Vue({
        el: '#puppies',
        data: response,
    });
}

// Get our data and build our viewmodel
$.when(
    $.ajax('http://api.adoptapet.com/search/pets_at_shelter?key=8059dcbb48596dd74e3f424368018f42&output=json&shelter_id=95658'), 
    $.ajax('http://api.adoptapet.com/search/pets_at_shelter?key=dc618ad6fe052fe942eff360409180c6&output=json&shelter_id=95500')
    ).then( function(nyResponse, txResponse) {
        // Start with the final array equaling the first set of pets.
        // We will compare with the second response and merge only the unique ones.
        // Additionally, we need to add an attribute to new york pets, if its doppleganger exists.
        var allPets = nyResponse[0];
        var txPets = txResponse[0];

        txPets.pets.forEach(function(txPet) {
            var hasDoppleganger = false;

            allPets.pets.map(function(pet) {
                if (pet.pet_name === txPet.pet_name) {
                    // If we find a match, this means that a pet is moving locations.
                    // Add in a destination attribute onto the pet object as well as
                    // an indicator it has a doppleganger.
                    var destination = txPet.addr_city + ', ' + txPet.addr_state_code;
                    pet.destination = destination;
                    pet.hasDoppleganger = true;

                    hasDoppleganger = true;
                }
            })

            if (!hasDoppleganger) {
                // TODO: We should push to a temp array instead of the main one.
                // That will prevent us from iterating over a larger and larger array.
                allPets.pets.push(txPet);
            }
        });

        // TODO: Merge the data from these calls.
        createViewModel(allPets);
    });
// Start it up!
$(function () {
    // This will initiate the sidebar menu when screen size is mobile width.
    // http://materializecss.com/navbar.html
    $(".button-collapse").sideNav();

    // Click binding for the donation link in the header.
    $('#donate').on('click', function(e) {
        $(e.currentTarget).closest('form').submit();
    })
});
       


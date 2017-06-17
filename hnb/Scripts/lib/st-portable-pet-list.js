// This library is slightly modified to use jQuery to append the iframe instead
// of injecting it at the bottom of the page.
// Taken from https://dq25e8j0im0tm.cloudfront.net/js/st-portable-pet-list.js
(function(){

    // Each setting used to be defined globally. To prevent naming conflicts
    // they were moved into AAPPetScrollerSettings. This method preserves
    // backward compatibility for sites that still have them defined globally.
    function get_settings(){
	if(typeof AAPPetScrollerSettings === 'undefined'){
	    return {
		'searchtools_box_width': window.searchtools_box_width,
		'searchtools_box_height': window.searchtools_box_height,
		'size': window.size,
		'title': window.title,
		'clan_name': window.clan_name,
		'color': window.color,
		'shelter_id': window.shelter_id,
		'sort_by': window.sort_by
	    };	    
	} else {
	    return AAPPetScrollerSettings;
	}
    }

    function quote(val) {
	return val != null ? '"' + val + '"' : '""';
    }

    function DoWrite() {
	var settings = get_settings();
        var base_url = settings.searchtools_root_url ? settings.searchtools_root_url : "//searchtools.adoptapet.com";
	var height = Number(settings.searchtools_box_height) + 10;
	var url = base_url + "/cgi-bin/searchtools.cgi/portable_pet_list?shelter_id=" + settings.shelter_id + "&size=" + settings.size + "&color=" + settings.color + "&clan_name=" + settings.clan_name + "&title=" + settings.title;
        if (settings.sort_by) {
            url += "&sort_by=" + settings.sort_by;
        }
        if (settings.clan_name) {
            url += "&hide_clan_filter_p=1";
        }

	$('#content').append('<iframe name="sap_searchtools_frame" width='
		       + quote(settings.searchtools_box_width) + ' height='
		       + quote(height) + 'frameborder="0" src=' + quote(url)
		       + ' marginwidth="0" marginheight="0" vspace="0" hspace="0" allowtransparency="true" scrolling="auto"></iframe>'
		       );
    }

    DoWrite();
})()

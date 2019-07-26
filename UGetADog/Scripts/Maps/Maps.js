var map;

function initMap(user_position) {
    var user = { lat: user_position.coords.latitude, lng: user_position.coords.longitude };
    var map = new google.maps.Map($('#map')[0], {
        center: user,
        zoom: 15
    });
    new google.maps.Marker({ position: user, map: map });
}

function CheckAddress() {
    var geocoder = new google.maps.Geocoder();
    var Address = document.getElementById('Address');
    Address.addEventListener('blur', (event) => {
        convertAddressToGeolocation(geocoder, Address.value);
    });
}

var searchAddress;

function convertAddressToGeolocation(geocoder,Address) {
    geocoder.geocode({ address: Address }, handleGeocoderResult);
}

function insertintolatlng(position) {
    var lat = document.getElementById("Latitude");
    var lng = document.getElementById("Longtitude");
    lat.value = position.lat();
    lng.value = position.lng();
}

function handleGeocoderResult(results, status) {
    if (status == 'OK') {
        insertintolatlng(results[0].geometry.location);
    }
    else if (status == 'ZERO_RESULTS' || status == 'INVALID_REQUEST' ) {
        showAddressIsNotValid();
    }
    else {
        console.log(status);
    }
}


function showAddressIsNotValid() {
    $("#Address").val("Not Valid");
}

function deleteMap() {
    $('#map').remove();
}

/*
function putMarkerOnMapAndSetMapCenter(geolocation) {
    var location = geolocation.geometry.location;
    var position = { lat: location.lat(), lng: location.lng() };

    map.setCenter(position);

    var marker = new google.maps.Marker({
        position: position
    });
    marker.setMap(map);

    setInfoWindowForMarker(geolocation.formatted_address, marker);
}
*/
/*
function setInfoWindowForMarker(content, marker) {
    var infoWindow = new google.maps.InfoWindow({
        content: content
    });
    infoWindow.open(map, marker);
}
*/

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(initMap);
    }
    else {
        $('#map')[0].innerHTML = "Geolocation is not supported by this browser.";
    }
}

function getreverseLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(reversegeocode);
    }
    else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}
function reversegeocode(position) {

    var latlng = { lat: position.coords.latitude, lng: position.coords.longitude };
    var geocoder = new google.maps.Geocoder;
    geocoder.geocode({ 'location': latlng }, function (results, status) {
        if (status === 'OK') {
            x.innerHTML = results[0].address_components[2].short_name;
        }
        else {
            window.alert('Geocoder failed due to: ' + status);
        }
    });
}
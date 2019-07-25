var map;

function initMap() {
    map = new google.maps.Map($('#map')[0], {
        zoom: 15
    });
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

function defaultMap() {
    map.setCenter({ lat: 31.771959, lng: 35.217018 });
}

function showAddressIsNotValid() {
    $("#Address").val("Not Valid");
}

function deleteMap() {
    $('#map').remove();
}

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

function setInfoWindowForMarker(content, marker) {
    var infoWindow = new google.maps.InfoWindow({
        content: content
    });
    infoWindow.open(map, marker);
}

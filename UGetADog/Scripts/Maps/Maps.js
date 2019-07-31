var map;

function initMap(user_position) {
    var user = { lat: user_position.coords.latitude, lng: user_position.coords.longitude };
    var map = new google.maps.Map($('#map')[0], {
        center: user,
        zoom: 15
    });
    new google.maps.Marker({ position: user, map: map });
    buildCircle(map, user);
    tableToMap("FullGiverTable", map);
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
        navigator.geolocation.watchPosition(showPosition);
    }
    else {
        $('#map')[0].innerHTML = "Geolocation is not supported by this browser.";
    }
}
// noa's function
function getreverseLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(reversegeocode);
    }
    else {
        $('#map')[0].innerHTML = "Geolocation is not supported by this browser.";
    }
}
//noa's function
function reversegeocode(position) {

    var latlng = { lat: position.coords.latitude, lng: position.coords.longitude };
    var geocoder = new google.maps.Geocoder;
    geocoder.geocode({ 'location': latlng }, function (results, status) {
        if (status === 'OK') {
            $('#map')[0].innerHTML = results[0].address_components[2].short_name;
        }
        else {
            window.alert('Geocoder failed due to: ' + status);
        }
    });
}


function tableToMap(tableID, map) {
    var table = document.getElementById(tableID);
    var lat;
    var lng;
    if (table != null) {
        for (var i = 0, col; col = table.rows[0].cells[i]; i++) {
            if (col.innerText.includes('Latitude')) {
                lat = i;
            }
            if (col.innerText.includes('Longtitude')) {
                lng = i;
            }
        }
        for (var i = 1, row; row = table.rows[i]; i++) {
            putMarkerOnMap(map, row.cells[lat].innerText, row.cells[lng].innerText);
        }
    }
}
function putMarkerOnMap(map, markerlat, markerlng) {
    var markerlocation = { lat: parseFloat(markerlat), lng: parseFloat(markerlng) };
    new google.maps.Marker({ position: markerlocation, map: map });

}
var userCircle;
function buildCircle(map, currentlocation) {
    userCircle = new google.maps.Circle({
        strokeColor: '#FF0000',
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: '#FF0000',
        fillOpacity: 0.35,
        map: map,
        center: currentlocation,
        radius: 20000
    });
    return userCircle;
}

function IsIn20KmFromMe(user) {
    var bounds = userCircle.getBounds();
    var pointa = bounds.contains(user);
    return pointa;

}

function initSerch(user_position) {
    var user = { lat: user_position.coords.latitude, lng: user_position.coords.longitude };
    var map = new google.maps.Map($('#map')[0], {
        center: user,
        zoom: 15
    });
    new google.maps.Marker({ position: user, map: map });
    buildCircle(map, user);
}

function allForSearch() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(initSerch);
    }
    else {
        $('#map')[0].innerHTML = "Geolocation is not supported by this browser.";
    }
}


function getCurrentLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}
function showPosition(position) {
    document.getElementById("giver_Latitude").value = position.coords.latitude;
    document.getElementById("giver_Longtitude").value = position.coords.longitude;
}

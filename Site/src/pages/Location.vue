<template>
  <div>
    <h2 class="text-h5 text-weight-bolder text-blue-10 no-margin">Location QR Code</h2>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-xs-12 col-md-6">
          <q-input filled v-model.number="latitude" step="0.01" type="number" placeholder="Latitude" />
        </div>
        <div class="col-xs-12 col-md-6">
          <q-input filled v-model.number="longitude" step="0.01" type="number" placeholder="Longitude" />
        </div>
        <div class="col-12">
          <div id="map" style="max-height: 50vh;min-height: 300px;"></div>
        </div>
      </div>
    </q-form>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        latitude: 26.820553,
        longitude: 30.802498
      }
    }
    , mounted() {
      let module = this;
      var map;
      function initialize() {
        let center = { lat: module.latitude, lng: module.longitude };

        var mapOptions = {
          zoom: 3,
          center: center
        };
        map = new google.maps.Map(document.getElementById('map'), mapOptions);

        var marker = new google.maps.Marker({
          position: center,
          draggable: true,
          map: map
        });

        var infowindow = new google.maps.InfoWindow({
          content: '<p>Marker Location:' + marker.getPosition() + '</p>'
        });

        google.maps.event.addListener(marker, 'click', function () {
          infowindow.open(map, marker);
        });
      }

      google.maps.event.addDomListener(window, 'load', initialize);
    }
  }
</script>

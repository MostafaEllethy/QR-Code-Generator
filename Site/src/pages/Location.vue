<template>
  <div>
    <h1 class="text-h4 text-weight-bolder h-color no-margin">Location QR Code</h1>
    <small class="text-caption"><span class="text-weight-bold">Drag The Marker and Choose Your Location.</span> Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-xs-12 col-md-6">
          <q-input filled v-model.number="latitude" step="0.01" type="number" label="Latitude" stack-label />
        </div>
        <div class="col-xs-12 col-md-6">
          <q-input filled v-model.number="longitude" step="0.01" type="number" label="Longitude" stack-label />
        </div>
        <div class="col-12">
          <div id="map" style="max-height: 50vh;min-height: 300px;"></div>
        </div>
      </div>
    </q-form>
  </div>
</template>

<script>
  let map = null
  let marker = null

  export default {
    beforeRouteEnter(to, from, next) {
      if (!(typeof google === 'object' && typeof google.maps === 'object')) {
        let el = document.createElement('script')
        el.setAttribute('src', 'https://maps.googleapis.com/maps/api/js?key=AIzaSyBl7pbD9dLSBvz8CC2Z5nnvVJVtSOb5-rQ')
        el.setAttribute('async', '')
        document.head.appendChild(el)
      }
      next();
    }
    , data() {
      return {
        latitude: 26.820553,
        longitude: 30.802498
      }
    }
    , mounted() {
      let module = this;
      initMap()
      function initMap() {
        if (typeof google === 'object' && typeof google.maps === 'object') {
          let center = { lat: module.latitude, lng: module.longitude };
          var mapOptions = {
            zoom: 3,
            center: center
          };
          map = new google.maps.Map(document.getElementById('map'), mapOptions);

          marker = new google.maps.Marker({
            position: center,
            draggable: true,
            map: map
          });

          marker.addListener('dragend', function (e) {
            module.latitude = e.latLng.lat();
            module.longitude = e.latLng.lng();
          });

          var infowindow = new google.maps.InfoWindow({
            content: '<p>Marker Location:' + marker.getPosition() + '</p>'
          });

          google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
          });
        } else {
          setTimeout(initMap, 500)
        }
      }
    }
    , watch: {
      latitude() {
        marker.setPosition({ lat: this.latitude, lng: this.longitude })
        this.$emit('updateQR', 'geo:' + this.latitude + ',' + this.longitude)
      }
      , longitude() {
        marker.setPosition({ lat: this.latitude, lng: this.longitude })
        this.$emit('updateQR', 'geo:' + this.latitude + ',' + this.longitude)
      }
    }
  }
</script>

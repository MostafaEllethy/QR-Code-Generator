<template>
  <div>

    <h1 id="AppTitle">QR <span class="text-weight-bolder">&lt;CODE/&gt;</span> Generator</h1>
    <q-tabs class="text-white">
      <q-route-tab name="text" icon="description" label="TEXT" to="" exact/>
      <q-route-tab name="url" icon="link" label="URL" to="/url" exact/>
      <q-route-tab name="wifi" icon="wifi" label="WIFI" to="/wifi" exact/>
      <q-route-tab name="phone" icon="local_phone" label="PHONE" to="/phone" exact/>
      <q-route-tab name="sms" icon="sms" label="SMS" to="/sms" exact/>
      <q-route-tab name="email" icon="alternate_email" label="EMAIL" to="/email" exact/>
      <q-route-tab name="vcard" icon="contacts" label="VCARD" to="/vcard" exact/>
      <q-route-tab name="location" icon="location_on" label="location" to="/location" exact/>
      <q-route-tab name="event" icon="event" label="EVENT" to="/event" exact/>
      <q-route-tab name="app_store" icon="apps" label="APP STORE" to="/app-store" exact/>
      <!--<q-btn-dropdown auto-close stretch flat label="More...">
        <q-list>
          <q-item clickable @click="tab = 'movies'">
            <q-item-section>Movies</q-item-section>
          </q-item>
          <q-item clickable @click="tab = 'photos'">
            <q-item-section>Photos</q-item-section>
          </q-item>
        </q-list>
      </q-btn-dropdown>-->
    </q-tabs>
    <div id="AppContent">
      <q-card>
        <q-card-section>
          <div class="row">
            <div class="col-9">
              <router-view/>

            </div>

            <div id="CanvasArea" class="col-3">
              <canvas id="Canvas"></canvas>
              <!--<q-input v-model="string"
              outlined
              autogrow />-->
            </div>
          </div>

        </q-card-section>
      </q-card>


    </div>

  </div>
</template>

<script>
  import QRCode from 'qrcode';

  let module = null;

  export default {
    name: 'MainLayout',
    data() {
      return {
        qr: "qwe",
        test: 'qwe'
      }
    },
    mounted() {
      module = this;
      //this.$on('updateQR', (val) => {
      //  console.log(val);
      //  module.qr = val
      //})
    },
    //watch: {
    //  qr(val) {
    //    console.log(val)
    //    if (val !== '') {
    //      var canvas = document.getElementById('Canvas');
    //      QRCode.toCanvas(canvas, this.qr, { width: 225, margin: 0 });
    //    }
    //  }
    //}
  }
</script>

<style lang="scss">
  #AppTitle {
    margin: 0;
    font-weight: 400;
    color: white;
    font-size: 3.75rem;
    padding: 1rem 0 0.75rem 0;
    text-align: center;
  }
  #AppContent {
    padding: 1rem 5rem;
  }
  #CanvasArea {
    border-left: 1px solid rgba(0,0,0,0.12);
  }
  #Canvas {
    display: block;
    margin: 0 auto;
  }
</style>

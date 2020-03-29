<template>
  <div>
    <h1 id="AppTitle">QR <span class="text-weight-bolder">&lt;CODE/&gt;</span> Generator</h1>
    <q-tabs class="text-white">
      <q-route-tab v-for="(menuItem, index) in menuList" :key="index" :to="menuItem.path" :icon="menuItem.icon" :label="menuItem.label" exact />
      <q-btn-dropdown auto-close stretch flat label="More...">
        <q-list>
          <q-item clickable @click="tab = 'movies'">
            <q-item-section>Movies</q-item-section>
          </q-item>
          <q-item clickable @click="tab = 'photos'">
            <q-item-section>Photos</q-item-section>
          </q-item>
        </q-list>
      </q-btn-dropdown>
    </q-tabs>
    <div id="AppContent">
      <q-card>
        <q-card-section>
          <div class="row q-col-gutter-md">
            <div class="col-9 q-pr-md">
              <router-view @updateQR="updateQR" @typing="typing" />
            </div>
            <div id="CanvasArea" class="col-3">
              <div style="position: relative">
                <canvas id="Canvas"></canvas>
                <q-inner-loading :showing="loading">
                  <q-circular-progress indeterminate
                                       size="3.75rem"
                                       :thickness="0.22"
                                       color="blue-10"
                                       track-color="grey-4" />
                </q-inner-loading>
              </div>
            </div>
          </div>
        </q-card-section>
      </q-card>
    </div>
    <q-dialog v-model="contactUs">
      <q-card style="width: 650px; max-width: 80vw;">
        <q-card-section>
          <iframe src="https://docs.google.com/forms/d/e/1FAIpQLSfpxafb4Un8wTqbCRCENkGC09nXVff6q1P_ZJjoUSB4n062XQ/viewform?embedded=true" width="600" height="750" frameborder="0" marginheight="0" marginwidth="0" style="display:block;margin:auto;">Loading…</iframe>
        </q-card-section>
      </q-card>
    </q-dialog>
    <div class="text-center q-mt-md">
      <a href="javascript:void();" class="text-grey-4" style="text-decoration: none;font-size: 1.25rem;font-weight: 500;" @click="showContactUs"><q-icon name="chat" /> Contact Us</a>
    </div>
  </div>
</template>

<script>
  import QRCode from 'qrcode';

  let module = null;

  const menuLinks = [
    { name: 'Text', icon: 'description' }
    , { name: 'Url', icon: 'link' }
    , { name: 'WiFi', icon: 'wifi' }
    , { name: 'Phone', icon: 'local_phone' }
    , { name: 'SMS', icon: 'sms' }
    , { name: 'Email', icon: 'alternate_email' }
    , { name: 'VCard', icon: 'contacts' }
    , { name: 'Location', icon: 'location_on' }
    , { name: 'Event', icon: 'event' }
    , { name: 'AppStore', icon: 'apps' }
  ]

  export default {
    name: 'MainLayout',
    data() {
      return {
        qr: "",
        menuList: [],
        contactUs: false,
        loading: true
      }
    }
    , beforeMount() {
      let module = this;
      menuLinks.forEach((item) => {
        let route = module.$router.resolve({
          name: item.name
        }).route;
        module.menuList.push({ label: route.meta.header, path: route.path, icon: item.icon });
      })
    }
    , mounted() {
      module = this;
      module.updateQR('http://qr-code-generator.info/');
    },
    methods: {
      typing() {
        module.loading = true;
      },
      updateQR(val) {
        if (val !== '') {
          var canvas = document.getElementById('Canvas');
          QRCode.toCanvas(canvas, val, { width: 225, margin: 0 });
        }
        module.loading = false;
      }
      , showContactUs() {
        this.contactUs = true;
      }
    }
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

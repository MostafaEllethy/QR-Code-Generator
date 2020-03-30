<template>
  <div style="overflow-x: hidden;">
    <h1 id="AppTitle">QR <span class="text-weight-bolder">&lt;CODE/&gt;</span> Generator</h1>
    <q-tabs class="text-white">
      <q-route-tab v-for="(menuItem, index) in menuList" :key="index" :to="menuItem.path" :icon="menuItem.icon" :label="menuItem.label" exact />
      <q-btn-dropdown auto-close stretch flat>
        <template v-slot:label>
          <div>
            <div class="row justify-around items-center no-wrap">
              <q-icon name="more" />
            </div>
            <div class="row items-center no-wrap">
              More...
            </div>
          </div>
        </template>

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
                <canvas id="ViewCanvas"></canvas>
                <canvas id="Canvas" style="display: none;"></canvas>
                <q-slider v-model="quality" :min="200" :max="2000" :step="5" :disable="downloading" />
                <div class="row no-wrap justify-between text-weight-bold q-mb-md" style="font-size:0.825rem;">
                  <div class="col-auto">Low Quality</div>
                  <div class="col-auto">{{quality}} × {{quality}} Pixel</div>
                  <div class="col-auto">High Quality</div>
                </div>
                <q-btn-dropdown class="full-width" color="positive" label="Download" icon="get_app" ref="DownloadPopup" :disable="downloading" :loading="downloading">
                  <div class="row no-wrap q-pa-md">
                    <div class="col">
                      <div class="text-h6 q-mb-sm">Download Formats</div>
                      <div class="row q-col-gutter-sm">
                        <div class="col-4">
                          <q-btn outline @click="download('png')" color="positive" class="full-width">.PNG</q-btn>
                        </div>
                        <div class="col-4">
                          <q-btn outline @click="download('jpeg')" color="positive" class="full-width">.JPEG</q-btn>
                        </div>
                        <div class="col-4">
                          <q-btn outline @click="download('webp')" color="positive" class="full-width">.WEBP</q-btn>
                        </div>
                        <div class="col-4">
                          <q-btn outline @click="download('svg')" color="positive" class="full-width">.SVG</q-btn>
                        </div>
                        <div class="col-4">
                          <q-btn outline @click="download('pdf')" color="positive" class="full-width">.PDF</q-btn>
                        </div>
                        <div class="col-4">
                          <q-btn outline @click="download('eps')" color="positive" class="full-width">.EPS</q-btn>
                        </div>
                      </div>
                    </div>
                  </div>
                </q-btn-dropdown>
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
    <div class="text-center q-py-md">
      <a href="javascript:void();" class="text-grey-4" style="text-decoration: none;font-size: 1.25rem;font-weight: 500;" @click="showContactUs"><q-icon name="chat" /> Contact Us</a>
    </div>
  </div>
</template>

<script>
  import QRCode from 'qrcode'
  import jsPDF from 'jspdf'

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
        , quality: 1100
        , downloading: false
      }
    }
    , created() {
      let module = this;
      module.$axios.get(window.location.origin + '/statics/config.json').then(function (response) {
        window.apiUrl = response.data.apiRoot;
        module.$emit("configLoaded")
      });
      menuLinks.forEach((item) => {
        let route = module.$router.resolve({
          name: item.name
        }).route;
        module.menuList.push({ label: route.meta.header, path: route.path, icon: item.icon });
      })
    }
    , mounted() {
      module = this;
      module.updateQR('https://qr-code-generator.info/');
      //module.$on("configLoaded", () => {
      //  QRCode.toString(module.qr, { type: 'svg' }, function (err, string) {
      //    if (err) throw err
      //    module.$axios.get(window.apiUrl + '/eps?data=' + encodeURIComponent(string)).then((response) => { console.log(response) })
      //  });
      //})
    },
    methods: {
      typing() {
        module.loading = true;
      }
      , updateQR(val) {
        if (val !== '') {
          var canvas = document.getElementById('Canvas');
          var viewCanvas = document.getElementById('ViewCanvas');
          QRCode.toCanvas(canvas, val, { width: module.quality, margin: 1 }, function (error) { });
          QRCode.toCanvas(viewCanvas, val, { width: 250, margin: 1 });
          module.qr = val;
        }
        module.loading = false;
      }
      , showContactUs() {
        this.contactUs = true;
      }
      , downloadingAsync(type) {
        return new Promise(resolve => {
          setTimeout(() => {
            var a = document.createElement("a");
            let fileName = Date.now();
            let fileExt = '';
            let options = { width: module.quality, margin: 1 };
            switch (type) {
              case 'png':
                options.type = 'image/png';
                QRCode.toDataURL(module.qr, options, function (err, string) {
                  if (err) throw err
                  a.href = string
                })
                fileExt = ".png";
                break;
              case 'jpeg':
                options.type = 'image/jpeg';
                QRCode.toDataURL(module.qr, options, function (err, string) {
                  if (err) throw err
                  a.href = string
                })
                fileExt = ".jpeg";
                break;
              case 'webp':
                options.type = 'image/webp';
                QRCode.toDataURL(module.qr, options, function (err, string) {
                  if (err) throw err
                  a.href = string
                })
                fileExt = ".webp";
                break;
              case 'svg':
                QRCode.toString(module.qr, { type: 'svg' }, function (err, string) {
                  if (err) throw err
                  a.href = 'data:image/svg+xml;utf8,' + encodeURIComponent(string)
                });
                fileExt = ".svg";
                break;
              case 'pdf':
                options.type = 'image/jpeg';
                options.width = 794;
                console.log(options)
                QRCode.toDataURL(module.qr, options, function (err, string) {
                  if (err) throw err
                  var pdf = new jsPDF();
                  pdf.addImage(string, 'JPEG', 0, 0);
                  pdf.save(fileName + '.pdf');
                })
                break;
            }
            if (type !== 'pdf') {
              a.download = fileName + fileExt;
              a.click();
            }
            resolve(true);
          }, 500);
        });
      }
      , async download(type) {
        module.downloading = true;
        module.$refs.DownloadPopup.hide();
        let result = await module.downloadingAsync(type);
        while (result) {
          module.downloading = false;
          break;
        }
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

  #ViewCanvas {
    display: block;
    margin: 0 auto;
  }
</style>

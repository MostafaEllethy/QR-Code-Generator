<template>
  <div style="overflow-x: hidden;">
    <app-header :screenSize="screenSize"></app-header>
    <div id="AppContent" v-bind:class="{'small': screenSize <= 2}">
      <q-card>
        <q-card-section>
          <div class="row q-col-gutter-md">
            <div class="col-9 q-pr-md">
              {{screenSize}}
              <router-view @updateQR="updateQR" @typing="typing" :screenSize="screenSize" />
            </div>
            <div id="CanvasArea" class="col-3">
              <div style="position: relative">
                <canvas id="ViewCanvas"></canvas>
                <canvas id="Canvas" style="display: none;"></canvas>
                <div class="row">
                  <div class="col-3 text-weight-bold self-center">
                    Quality <q-icon name="double_arrow" />
                  </div>
                  <div class="col-9">
                    <q-slider v-model="quality" :min="minQuality" :max="maxQuality" :step="5" :disable="downloading" />
                  </div>
                </div>
                <div class="row text-weight-bold" style="font-size:0.825rem;">
                  <div class="col-4"><q-input filled v-model.number="quality" dense :input-style="{textAlign: 'center'}" /></div>
                  <div class="col-2 text-center self-center text-h6">×</div>
                  <div class="col-4"><q-input filled v-model.number="quality" dense :input-style="{textAlign: 'center'}" /></div>
                  <div class="col-2 text-center text-subtitle2 self-center">Pixel</div>
                </div>
                <q-separator spaced />
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
                        <div class="col-4" v-if="configLoaded">
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
          <iframe src="https://docs.google.com/forms/d/e/1FAIpQLSfpxafb4Un8wTqbCRCENkGC09nXVff6q1P_ZJjoUSB4n062XQ/viewform?embedded=true" width="600" height="750" frameborder="0" marginheight="0" marginwidth="0" style="    display: block;
    margin: auto;
">
            Loading…
          </iframe>
        </q-card-section>
      </q-card>
    </q-dialog>
    <div class="text-center q-py-md">
      <a href="javascript:void();" class="text-grey-4" style="    text-decoration: none;
    font-size: 1.25rem;
    font-weight: 500;
" @click="showContactUs"><q-icon name="chat" /> Contact Us</a>
    </div>
  </div>
</template>
<script>
  import QRCode from 'qrcode'
  import jsPDF from 'jspdf'
  import axios from 'axios'
  import AppHeader from '../components/AppHeader'
  let module = null;
  export default {
    name: 'MainLayout',
    components: { AppHeader}
    , data() {
      return {
        qr: ""
        , contactUs: false
        , loading: true
        , minQuality: 100
        , maxQuality: 2000
        , defaultQuality: 512
        , quality: null
        , downloading: false
        , configLoaded: false
      }
    }
    , created() {
      let module = this;
      module.$axios.get(window.location.origin + '/statics/config.json').then(function (response) {
        window.apiUrl = response.data.apiRoot;
        module.configLoaded = true
      });
      module.quality = module.defaultQuality
    }
    , mounted() {
      module = this;
      module.updateQR('https://qr-code-generator.info/');
      module.fixTabs();
    },
    methods: {
      test() {
        alert('test');
      }
      , typing() {
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
        let quality = parseInt(module.quality);
        if (isNaN(quality) || module.minQuality > quality || quality > module.maxQuality) quality = module.defaultQuality;
        return new Promise(resolve => {
          setTimeout(() => {
            var a = document.createElement("a");
            let fileName = Date.now();
            let fileExt = '';
            let options = { width: quality, margin: 1 };
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
                QRCode.toDataURL(module.qr, options, function (err, string) {
                  if (err) throw err
                  var pdf = new jsPDF();
                  pdf.addImage(string, 'JPEG', 0, 0);
                  pdf.save(fileName + '.pdf');
                })
                break;
              case 'eps':
                options.type = 'image/jpeg';
                QRCode.toDataURL(module.qr, options, function (err, string) {
                  if (err) throw err
                  function getQueryString(data = {}) {
                    return Object.entries(data)
                      .map(([key, value]) => `${encodeURIComponent(key)}=${encodeURIComponent(value)}`)
                      .join('&');
                  }
                  const config = {
                    headers: {
                      'Content-Type': 'application/x-www-form-urlencoded'
                    }, transformRequest: getQueryString
                  }
                  axios.post(window.apiUrl + '/eps', { data: string.split(',')[1] }, config).then((response) => {
                    const url = window.URL.createObjectURL(new Blob([response.data]));
                    a.href = url;
                    a.download = fileName + ".eps";
                    a.click();
                  })
                });
                break;
            }
            if (!(['pdf', 'eps'].includes(type))) {
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
      }, fixTabs() {
        var tabs = document.getElementById('TabsDiv')
        var swipe = document.getElementById('SwipeDiv')
        if (module.$q.platform.is.mobile != null && module.$q.screen.width <= 850) {
          tabs.classList.add("mobileTabs");
          swipe.classList.remove("hidden");
        } else {
          tabs.classList.remove("mobileTabs");
          swipe.classList.add("hidden");
        }
      }
    },
    watch: {
      '$q.screen.width': function () {
        module.fixTabs();
      }
    },
    computed: {
      screenSize() {
        let size = 4;
        switch (this.$q.screen.name) {
          case 'xs': size = 1; break;
          case 'sm': size = 2; break;
          case 'md': size = 3; break;
        }
        return size;
      }
    }
  }
</script>

<style lang="scss">
    #AppContent {
      padding: 1rem 5rem;
    }

    #AppContent.small {
      padding: 1px 0 !important;
    }

      #AppContent.small .q-card {
        border-radius: 0 !important;
      }

  #CanvasArea {
    border-left: 1px solid rgba(0,0,0,0.12);
  }

  #ViewCanvas {
    display: block;
    margin: 0 auto;
  }


</style>

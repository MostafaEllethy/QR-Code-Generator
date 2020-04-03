<template>
  <div>
    <div class="xs">
      <q-separator />
    </div>
    <div id="QRPreview" class="full-width relative-position">
      <div class="svg">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 33 33" shape-rendering="crispEdges"><path fill="#ffffff" d="M0 0h33v33H0z" /><path stroke="#000000" d="M2 2.5h7m2 0h1m1 0h1m3 0h2m2 0h2m1 0h7M2 3.5h1m5 0h1m2 0h2m9 0h1m1 0h1m5 0h1M2 4.5h1m1 0h3m1 0h1m1 0h4m2 0h1m1 0h1m1 0h1m3 0h1m1 0h3m1 0h1M2 5.5h1m1 0h3m1 0h1m1 0h1m1 0h3m3 0h2m4 0h1m1 0h3m1 0h1M2 6.5h1m1 0h3m1 0h1m1 0h3m1 0h4m1 0h4m1 0h1m1 0h3m1 0h1M2 7.5h1m5 0h1m1 0h2m3 0h5m4 0h1m5 0h1M2 8.5h7m1 0h1m1 0h1m1 0h1m1 0h1m1 0h1m1 0h1m1 0h1m1 0h7M10 9.5h1m2 0h3m1 0h1m3 0h1M2 10.5h1m1 0h5m2 0h3m2 0h2m1 0h1m2 0h1m1 0h5M4 11.5h2m3 0h2m3 0h1m2 0h2m2 0h6m3 0h1M3 12.5h3m2 0h2m1 0h2m1 0h1m4 0h2m1 0h1m1 0h2M2 13.5h2m7 0h1m2 0h1m1 0h1m1 0h1m1 0h1m1 0h1m1 0h1m1 0h2m1 0h1M3 14.5h3m2 0h2m1 0h4m3 0h3m6 0h2M2 15.5h2m3 0h1m1 0h1m5 0h3m1 0h8m3 0h1M2 16.5h1m1 0h2m2 0h1m1 0h1m1 0h1m1 0h6m5 0h4M2 17.5h1m3 0h2m1 0h2m4 0h1m1 0h1m2 0h4m1 0h1m3 0h1M4 18.5h1m2 0h2m1 0h1m1 0h3m1 0h2m1 0h1m1 0h1m5 0h2M2 19.5h1m1 0h1m2 0h1m1 0h1m2 0h3m2 0h8m1 0h1m1 0h1m1 0h1M2 20.5h1m4 0h3m2 0h1m1 0h1m5 0h1m1 0h1m5 0h1M2 21.5h1m1 0h1m4 0h2m2 0h2m1 0h1m1 0h1m3 0h1m3 0h1m2 0h1M2 22.5h1m1 0h1m3 0h1m4 0h1m5 0h1m2 0h5m1 0h3M10 23.5h1m1 0h2m1 0h3m1 0h2m1 0h1m3 0h5M2 24.5h7m5 0h6m1 0h2m1 0h1m1 0h3M2 25.5h1m5 0h1m1 0h1m4 0h1m2 0h1m1 0h3m3 0h1m3 0h1M2 26.5h1m1 0h3m1 0h1m1 0h1m1 0h1m1 0h1m1 0h1m2 0h1m2 0h5m1 0h1m1 0h1M2 27.5h1m1 0h3m1 0h1m1 0h1m2 0h1m1 0h1m4 0h4m1 0h1m1 0h2M2 28.5h1m1 0h3m1 0h1m1 0h1m6 0h3m1 0h1m1 0h7M2 29.5h1m5 0h1m4 0h2m1 0h1m1 0h1m1 0h1m1 0h1m1 0h4m1 0h1M2 30.5h7m1 0h1m1 0h2m1 0h2m2 0h1m1 0h1m4 0h3" /></svg>
      </div>
      <q-inner-loading :showing="loading">
        <q-circular-progress indeterminate
                             size="3.75rem"
                             :thickness="0.22"
                             color="blue-10"
                             track-color="grey-4" />
      </q-inner-loading>
    </div>
    <canvas id="Canvas" class="hidden"></canvas>
    <div class="row">
      <div class="col-sm-4 col-3 text-weight-bold self-center">
        Quality <q-icon name="double_arrow" />
      </div>
      <div class="col-sm-8 col-9">
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
    <q-btn-dropdown class="full-width q-pa-xs" color="positive" label="Download" icon="get_app" ref="DownloadPopup" :disable="downloading" :loading="downloading">
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
  </div>
</template>

<script>
  import jsPDF from 'jspdf'
  import QRCode from 'qrcode'

  let module = null;

  export default {
    created() {
      module = this;
      module.quality = module.defaultQuality
    }
    , data() {
      return {
        qr: "https://qr-code-generator.info/"
        , minQuality: 100
        , maxQuality: 2000
        , defaultQuality: 512
        , quality: null
        , downloading: false
        , loading: false
      }
    }
    , methods: {
      updateQR(qr) {
        module.loading = true;
        QRCode.toString(qr, { type: 'svg', margin: 2 }, function (err, string) {
          if (err) throw err
          document.querySelector("#QRPreview .svg").innerHTML = string;
          module.qr = qr;
          module.loading = false
        });
      }
      , async download(type) {
        module.downloading = true;
        module.$refs.DownloadPopup.hide();
        await module.downloadingAsync(type);
      }
      , downloadingAsync(type) {
        let quality = parseInt(module.quality);
        if (isNaN(quality) || module.minQuality > quality || quality > module.maxQuality) quality = module.defaultQuality;
        return new Promise(resolve => {
          setTimeout(() => {
            var a = document.createElement("a");
            let fileName = 'qr_' + Date.now();
            let fileExt = '';
            let options = { width: quality, margin: 1, type };
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
                  module.downloading = false;
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
                  module.$axios.post(window.apiUrl + '/api/QR/Eps', { svg: string.split(',')[1] }, { responseType: 'arraybuffer' }).then((response) => {
                    const url = window.URL.createObjectURL(new Blob([response.data], { type: "octet/stream" }));
                    a.href = url;
                    a.download = fileName + ".eps";
                    a.click();
                    module.downloading = false;
                  }).catch(() => { module.downloading = false; })
                });
                break;
            }
            if (!(['pdf', 'eps'].includes(type))) {
              a.download = fileName + fileExt;
              a.click();
              module.downloading = false;
            }
            resolve(true);
          }, 500);
        });
      }
    }
  }
</script>

<style scoped>
</style>

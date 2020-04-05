<template>
  <div>
    <q-card-section>
      <div class="row">
        <div class="col-xs-12 col-sm-7 col-md-8" v-bind:class="{'q-pr-md': screenSize >= 2, 'q-pb-md': screenSize === 1}">
          <router-view @updateQR="updateQR" :screenSize="screenSize" />
        </div>
        <div id="CanvasArea" class="col-xs-12 col-sm-5 col-md-4" v-bind:class="{'border q-pl-md': $q.screen.name !== 'xs'}">
          <QR ref="QR"></QR>
        </div>
      </div>
    </q-card-section>
  </div>
</template>

<script>
  import QR from '../components/QR'

  let module = null;
  export default {
    props: ['screenSize']
    , components: { QR }
    , created() {
      module = this;
      if (document.readyState !== 'loading') {
        initCode();
      } else {
        document.addEventListener('DOMContentLoaded', function () {
          initCode();
        });
      }
      function initCode() {
        setTimeout(() => {
          module.loadGoogleAds()
        }, 2000)
        setTimeout(() => {
          module.loadScriptAsync('https://platform-api.sharethis.com/js/sharethis.js#property=5e821ab289347a0019b87623&product=sticky-share-buttons&cms=sop')
        }, 3000)
      }
    }
    , methods: {
      updateQR(val) {
        if (val !== '') {
          module.$refs.QR.updateQR(val);
        }
      }
      , loadScriptAsync(script) {
        let el = document.createElement('script')
        el.setAttribute('src', script)
        el.setAttribute('async', '')
        document.head.appendChild(el)
      }
      , loadGoogleAds() {
        let el = document.createElement('script')
        el.setAttribute('src', 'https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js')
        el.setAttribute('async', '')
        el.setAttribute('data-ad-client', 'ca-pub-1361355040123683')
        document.head.appendChild(el)
      }
    }
  }
</script>

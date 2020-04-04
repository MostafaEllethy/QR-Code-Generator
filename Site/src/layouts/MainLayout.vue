<template>
  <div id="Main" style="overflow-x: hidden;">
    <app-header :screenSize="screenSize"></app-header>
    <div id="AppContent" v-bind:class="{'small': screenSize <= 2}">
      <q-card>
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
      </q-card>
    </div>
    <Contact :screenSize="screenSize"></Contact>
  </div>
</template>
<script>
  import axios from 'axios'
  import AppHeader from '../components/AppHeader'
  import Contact from '../components/Contact'
  import QR from '../components/QR'
  let module = null;
  export default {
    name: 'MainLayout',
    components: { AppHeader, QR, Contact }
    , beforeRouteEnter(to, from, next) {
      axios.get(window.location.origin + '/statics/config.json').then(function (response) {
        next(() => { window.apiUrl = response.data.apiRoot; })
      }).catch(() => {
        console.log("Error while loading config file.")
      });;
    }
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

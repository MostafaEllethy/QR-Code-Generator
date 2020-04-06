<template>
  <div id="Main" style="overflow-x: hidden;">
    <app-header :screenSize="screenSize"></app-header>
    <div id="AppContent" v-bind:class="{'small': screenSize <= 2}">
      <q-card>
        <router-view :screenSize="screenSize" />
      </q-card>
    </div>
    <footer class="text-center text-white q-pb-md">
      <template v-for="(item, index) in footerLinks">
        {{(index !== 0) ? ' - ': ''}}
        <router-link :to="{ name: item.name}" :key="item.name">{{item.title}}</router-link>
      </template>
      <br /><small class="text-grey-4">"QR Code" is a registered trademark of DENSO WAVE INCORPORATED</small>
    </footer>
  </div>
</template>
<script>
  import axios from 'axios'
  import AppHeader from '../components/AppHeader'

  let module = null;

  export default {
    name: 'MainLayout',
    components: { AppHeader }
    , data() {
      return {
        footerLinks: [{
          name: 'Contact'
          , title: 'Contact'
        }
          , {
          name: 'PrivacyPolicy'
          , title: 'Privacy Policy'
        }
        ]
      }
    }
    , beforeRouteEnter(to, from, next) {
      axios.get(window.location.origin + '/statics/config.json').then(function (response) {
        next(() => {
          window.apiUrl = response.data.apiRoot;
          axios.get(window.apiUrl + '/api/contacts')
        })
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
      loadScriptAsync(script) {
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
    , computed: {
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
<style>
  footer a {
    text-decoration: none;
    color: white;
  }

    footer a:hover {
      text-decoration: underline;
    }
</style>

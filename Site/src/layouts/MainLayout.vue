<template>
  <div id="Main" style="overflow-x: hidden;">
    <app-header :screenSize="screenSize"></app-header>
    <div id="AppContent" v-bind:class="{'small': screenSize <= 2}">
      <q-card>
        <router-view :screenSize="screenSize" />
      </q-card>
    </div>
    <footer class="text-center text-white q-py-md">
      <template v-for="(item, index) in footerLinks">
        {{(index !== 0) ? ' - ': ''}}
        <router-link :to="{ name: item.name}" :key="item.name">{{item.title}}</router-link>
      </template>
    </footer>
    <!--<q-dialog id="CookieConsent" v-model="cookieConsent" seamless position="bottom">
      <q-card class="bg-blue-grey-2" style="max-width: 75vw">
        <q-card-section horizontal>
          <q-card-section>
            This website uses <a href="https://en.wikipedia.org/wiki/HTTP_cookie">cookies</a> to ensure you got the best possible experience, by continuing to use the site you agree that we can save them on your device. For more information please read our <a href="">Privacy Policy.</a>
            <q-btn icon="close" style="float:right;" flat round dense v-close-popup />
          </q-card-section>
        </q-card-section>
      </q-card>
    </q-dialog>-->
  </div>
</template>
<script>
  import axios from 'axios'
  import AppHeader from '../components/AppHeader'

  export default {
    name: 'MainLayout',
    components: { AppHeader }
    , data() {
      return {
        cookieConsent: true
        , footerLinks: [{
          name: 'Contact'
          , title: 'Contact'
        }
          , {
          name: 'PrivacyPolicy'
          , title: 'Privacy Policy'
        }
          , {
          name: 'FAQ'
          , title: 'FAQ'
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
    , mounted() {
      let module = this;

      if (this.$q.cookies.get('cookiesAccepted') == null) {

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

    #CookieConsent a:visited {
      color: black;
    }
</style>

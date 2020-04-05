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
        footerLinks: [{
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
        next(() => { window.apiUrl = response.data.apiRoot; })
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
</style>

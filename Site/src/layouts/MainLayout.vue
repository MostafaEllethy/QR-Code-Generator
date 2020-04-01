<template>
  <div style="overflow-x: hidden;">
    <app-header :screenSize="screenSize"></app-header>
    <div id="AppContent" v-bind:class="{'small': screenSize <= 2}">
      <q-card>
        <q-card-section>
          <div class="row">
            <div class="col-xs-12 col-sm-7 col-md-8 q-pr-sm-md q-pb-xs-md">
              <router-view @updateQR="updateQR" :screenSize="screenSize" />
            </div>
            <div id="CanvasArea" class="col-xs-12 col-sm-5 col-md-4 q-pl-sm-md" v-bind:class="{'border': $q.screen.name !== 'xs'}">
              <QR ref="QR"></QR>
            </div>
          </div>
        </q-card-section>
      </q-card>
    </div>
    <Contact></Contact>
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
      });
    }
    , created() {
      module = this;
    }
    , methods: {
      updateQR(val) {
        if (val !== '') {
          module.$refs.QR.updateQR(val);
        }
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
    padding: 1rem 5rem 0 5rem;
  }

    #AppContent.small {
      padding: 1px 0 !important;
    }

      #AppContent.small .q-card {
        border-radius: 0 !important;
      }

  #CanvasArea.border {
    border-left: 1px solid rgba(0,0,0,0.12);
  }
</style>

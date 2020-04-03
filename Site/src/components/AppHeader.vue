<template>
  <div v-show="componentLoaded" id="AppHeader">
    <h1 id="AppTitle" v-bind:class="{'q-py-md': screenSize >= 3}">
      <template v-if="screenSize >= 2">
        QR
        <span class="text-weight-bold">&lt;CODE/&gt;</span> Generator
      </template>
      <template v-else>
        <h1 class="text-center no-margin text-h5" style="display: inline-block;vertical-align:middle;">QR<br /><span class="text-weight-bold">&lt;CODE/&gt;</span></h1>
        <h1 class="q-ml-sm q-my-none" style="display: inline-block;vertical-align: middle;font-size:2.75rem">Generator</h1>
      </template>
    </h1>

    <q-carousel v-model="slide"
                animated
                swipeable
                control-type="push"
                height="56px"
                infinite
                :arrows="tabMode !== 3"
                style="background: rgba(0,0,0,0.125);"
                class="text-white">
      <q-carousel-slide name="slide" class="no-padding">
        <q-tabs v-bind:class="{'q-px-xl': tabMode !== 3}" dense narrow-indicator>
          <q-route-tab :to="{name: 'Text'}" icon="description" label="Text" exact />
          <q-route-tab :to="{name: 'URL'}" icon="link" label="URL" exact />
          <q-route-tab :to="{name: 'WiFi'}" icon="wifi" label="WiFi" exact />
          <template v-if="tabMode !== 1">
            <q-route-tab :to="{name: 'VCard'}" icon="contacts" label="VCard" exact />
            <q-route-tab :to="{name: 'Phone'}" icon="local_phone" label="Phone" exact />
            <template v-if="tabMode === 3">
              <q-route-tab :to="{name: 'SMS'}" icon="sms" label="SMS" exact />
              <q-route-tab :to="{name: 'Location'}" icon="location_on" label="Location" exact />
              <q-route-tab :to="{name: 'Email'}" icon="alternate_email" label="Email" exact />
              <q-route-tab :to="{name: 'Event'}" icon="event" label="Event" exact />
            </template>
          </template>
        </q-tabs>
      </q-carousel-slide>
      <template v-if="tabMode !== 3">
        <q-carousel-slide name="slide2" class="no-padding">
          <q-tabs class="q-px-xl" dense narrow-indicator>
            <template v-if="tabMode === 1">
              <q-route-tab :to="{name: 'VCard'}" icon="contacts" label="VCard" exact />
              <q-route-tab :to="{name: 'Phone'}" icon="local_phone" label="Phone" exact />
            </template>
            <q-route-tab :to="{name: 'SMS'}" icon="sms" label="SMS" exact />
            <template v-if="tabMode === 2">
              <q-route-tab :to="{name: 'Location'}" icon="location_on" label="Location" exact />
              <q-route-tab :to="{name: 'Email'}" icon="alternate_email" label="Email" exact />
              <q-route-tab :to="{name: 'Event'}" icon="event" label="Event" exact />
            </template>
          </q-tabs>
        </q-carousel-slide>
        <q-carousel-slide name="slide3" class="no-padding" v-if="tabMode === 1">
          <q-tabs class="q-px-xl" dense narrow-indicator>
            <q-route-tab :to="{name: 'Location'}" icon="location_on" label="Location" exact />
            <q-route-tab :to="{name: 'Email'}" icon="alternate_email" label="Email" exact />
            <q-route-tab :to="{name: 'Event'}" icon="event" label="Event" exact />
          </q-tabs>
        </q-carousel-slide>
      </template>
    </q-carousel>
  </div>
</template>
<script>
  let module = null;
  export default {
    props: ['screenSize']
    , data() {
      return {
        componentLoaded: false
        , slide: 'slide'
        , tabMode: 3
      }
    }
    , mounted() {
      module = this;
      module.fixTabs();
      module.componentLoaded = true;
    }
    , methods: {
      fixTabs() {
        this.slide = 'slide';
        let screenWidth = this.$q.screen.width;
        if (screenWidth <= 450) {
          this.tabMode = 1;
        } else if (screenWidth >= 700) {
          this.tabMode = 3;
        } else {
          this.tabMode = 2
        }
      }
    }
    , watch: {
      '$q.screen.width': function () {
        this.fixTabs();
      }
    }
  }
</script>

<style>
  #AppHeader .q-carousel__prev-arrow--horizontal {
    top: 11px;
  }

  #AppHeader .q-carousel__next-arrow--horizontal {
    top: 11px;
  }
</style>

<style scoped>
  #AppTitle {
    margin: 0;
    color: white;
    font-size: 3.75rem;
    text-align: center;
    line-height: 1.375;
  }

    #AppTitle h1 {
      line-height: 1 !important;
    }

  @media only screen and (max-width: 1024px) {
    #AppTitle {
      font-size: 3rem;
      line-height: 2.25;
    }
  }
</style>

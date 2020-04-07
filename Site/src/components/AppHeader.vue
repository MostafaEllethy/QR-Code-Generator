<template>
  <div v-show="componentLoaded" id="AppHeader">

    <div id="AppTitle" style="margin: 1.5rem auto;">
      <h1 class="text-h2 text-white no-margin">QR<span class="text-weight-bolder">CODE</span> Generator</h1>
      <q-btn round push color="transparent" icon="menu" id="IconMenu">
        <q-menu anchor="bottom middle" self="top middle" :offset=[0,5] content-class="text-center text-weight-bold text-cyan-9">
          <q-item clickable :to="($route.meta.header == null) ? {name: 'Text', hash: '#About'} : {hash: '#About'}">
            <q-item-section>About</q-item-section>
          </q-item>
          <q-item clickable :to="($route.meta.header == null) ? {name: 'Text', hash: '#FAQ'} : {hash: '#FAQ'}">
            <q-item-section>FAQ</q-item-section>
          </q-item>
          <q-item clickable :to="{name: 'PrivacyPolicy'}">
            <q-item-section>Privacy Policy</q-item-section>
          </q-item>
          <q-item clickable :to="{name: 'Contact'}">
            <q-item-section>Contact Us</q-item-section>
          </q-item>
        </q-menu>
      </q-btn>

    </div>
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
        } else if (screenWidth >= 707) {
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
  .remove-x-margin {
    margin: auto 0 !important;
  }

  #AppHeader .q-carousel__prev-arrow--horizontal {
    top: 11px;
  }

  #AppHeader .q-carousel__next-arrow--horizontal {
    top: 11px;
  }
</style>

<style scoped>

  #AppTitle {
    position: relative;
  }

  #AppTitle h1{
    text-align: center;
    line-height: 1;
  }

  #IconMenu {
    position: absolute;
    top: 50%;
    right: 7%;
    transform: translate(-50%, -50%);
  }

  @media only screen and (max-width: 1023px) {
    #IconMenu {
      right: 3.75%;
    }
  }

  @media only screen and (max-width:707px) {
    #AppTitle h1{
      font-size: 3rem;
    }
    #IconMenu {
      right: 0px;
    }
  }

  @media only screen and (max-width:555px) {
    #AppTitle h1 {
      padding-left: 2.5%;
      text-align: left;
    }
  }

  @media only screen and (max-width:499px) {
    #AppTitle h1 {
      font-size: 2.125rem !important;
    }
  }
</style>

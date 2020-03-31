<template>
  <div>
    <h1 id="AppTitle" class="q-py-md-md">
      <template v-if="screenSize >= 2">
        QR
        <span class="text-weight-bold">&lt;CODE/&gt;</span> Generator
      </template>
      <template v-else>
        <h1 class="text-center no-margin text-h5" style="display: inline-block;vertical-align:middle;">QR<br /><span class="text-weight-bold">&lt;CODE/&gt;</span></h1>
        <h1 class="q-ml-sm q-my-none" style="display: inline-block;vertical-align: middle;font-size:2.75rem">Generator</h1>
      </template>
    </h1>
    <div id="TabsDiv" style="background: rgba(0,0,0,0.125);" v-bind:class="{'mobile': $q.platform.is.mobile && screenSize <= 2}">
      <q-tabs class="text-white" dense narrow-indicator>
        <q-route-tab v-for="(menuItem, index) in menuList" :key="index" :to="menuItem.path" :icon="menuItem.icon" :label="menuItem.label" exact />
      </q-tabs>
      <div id="SwipeDiv" class="text-center hidden">
        <q-icon name="chevron_right" color="white" size="25px" style="position:absolute;right:-5px;top:15px;" />
      </div>
    </div>
  </div>
</template>
<script>
  const menuLinks = [
    { name: 'Text', icon: 'description' }
    , { name: 'Url', icon: 'link' }
    , { name: 'WiFi', icon: 'wifi' }
    , { name: 'Phone', icon: 'local_phone' }
    , { name: 'SMS', icon: 'sms' }
    , { name: 'Email', icon: 'alternate_email' }
    , { name: 'VCard', icon: 'contacts' }
    , { name: 'Location', icon: 'location_on' }
    , { name: 'Event', icon: 'event' }
    , { name: 'AppStore', icon: 'apps' }
  ]
  let module = null;
  export default {
    props: ['screenSize']
    , data() {
      return {
        menuList: []
      }
    }
    , created() {
      module = this;
      menuLinks.forEach((item) => {
        let route = module.$router.resolve({
          name: item.name
        }).route;
        module.menuList.push({ label: route.meta.header, path: route.path, icon: item.icon });
      })
    }
  }
</script>

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

  #TabsDiv {
    position: relative;
  }

    #TabsDiv.mobile {
      padding-right: 15px;
    }

  @media only screen and (max-width: 1024px) {
    #AppTitle {
      font-size: 3rem;
      line-height: 2.25;
    }
  }
</style>

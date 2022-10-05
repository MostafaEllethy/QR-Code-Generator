<template>
  <div id="Main" style="overflow-x: hidden;">
    <app-header :screenSize="screenSize"></app-header>
    <div id="AppContent" v-bind:class="{ small: screenSize <= 2 }">
      <q-card>
        <router-view :screenSize="screenSize" />
      </q-card>
    </div>
    <footer class="text-center text-white q-pb-md">
      <span v-for="(item, index) in footerLinks" :key="index">
        {{ index !== 0 ? " - " : "" }}
        <router-link :to="{ name: item.name }">{{
        item.title
        }}</router-link>
      </span>
      <br /><small class="text-grey-4">"QR Code" is a registered trademark of DENSO WAVE INCORPORATED</small>
    </footer>
  </div>
</template>
<script>
import AppHeader from "../components/AppHeader";

let module = null;

export default {
  name: "MainLayout",
  components: { AppHeader },
  data() {
    return {
      footerLinks: [
        {
          name: "Contact",
          title: "Contact"
        },
        {
          name: "PrivacyPolicy",
          title: "Privacy Policy"
        }
      ]
    };
  },
  created() {
    module = this;
  },
  computed: {
    screenSize() {
      let size = 4;
      switch (this.$q.screen.name) {
        case "xs":
          size = 1;
          break;
        case "sm":
          size = 2;
          break;
        case "md":
          size = 3;
          break;
      }
      return size;
    }
  }
};
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

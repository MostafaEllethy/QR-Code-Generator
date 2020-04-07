<template>
  <div>
    <h1 class="text-h4 text-weight-bolder h-color no-margin">WiFi QR Code</h1>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-12">
          <div class="row items-center">
            <div class="col-xs-8">
              <q-input filled v-model="name" placeholder="Network Name (SSID)" />
            </div>
            <div class="col-xs-4 text-center">
              <q-toggle v-model="hidden" label="Hidden SSID" />
            </div>
          </div>
        </div>
        <div class="col-12">
          <div class="row items-center">
            <div class="col-xs-12  col-sm-3 text-subtitle2 text-weight-bold">
              Encryption <q-icon name="double_arrow" class="gt-xs" />
            </div>
            <div class="col-xs-12  col-sm-9">
              <q-btn-toggle spread v-model="encryption" push toggle-color="primary" :options="[
          {label: 'None', value: 'nopass'},
          {label: 'WPA/WPA2', value: 'WPA'},
          {label: 'WEB', value: 'WEP'} ]" />
            </div>
          </div>
        </div>
        <div class="col-12">
          <div class="row">
            <div class="col-xs-12">
              <q-input v-model="password" filled :type="showPwd ? 'text' : 'password'" placeholder="Password" hint="Your QR Code will be generated automatically.">
                <template v-slot:append>
                  <q-icon :name="showPwd ? 'visibility' : 'visibility_off'"
                          class="cursor-pointer"
                          @click="showPwd = !showPwd" />
                </template>
              </q-input>
            </div>
          </div>
        </div>
      </div>
    </q-form>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        showPwd: false
        , name: ''
        , hidden: false
        , encryption: 'nopass'
        , password: ''
      }
    }
    , computed: {
      qr() {
        return 'WIFI:T:' + this.encryption + ';S:' + this.name + ';P:' + this.password + ';' + (this.hidden ? ('H:true;') : '') + ';';
      }
    }
    , watch: {
      qr(val) {
        this.$emit('updateQR', val)
      }
    }
  }
</script>

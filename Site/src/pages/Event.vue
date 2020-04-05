<template>
    <div class="relative-position">
    <h1 class="text-h4 text-weight-bolder h-color no-margin">Event QR Code</h1>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-12">
          <q-input filled v-model="title" placeholder="Event Title" />
        </div>
        <div class="col-12">
          <q-input filled v-model="location" placeholder="Location" />
        </div>
        <div class="col-xs-12 col-sm-6">
          <q-input filled v-model="startTime" placeholder="Start Time" @click="showStartDate" readonly>
            <template v-slot:prepend>
              <q-icon name="event" class="cursor-pointer">
                <q-popup-proxy transition-show="scale" transition-hide="scale" ref="StartDatePopup">
                  <q-date v-model="startTime" mask="YYYY-MM-DD HH:mm" />
                </q-popup-proxy>
              </q-icon>
            </template>

            <template v-slot:append>
              <q-icon name="access_time" class="cursor-pointer">
                <q-popup-proxy transition-show="scale" transition-hide="scale">
                  <q-time v-model="startTime" mask="YYYY-MM-DD HH:mm" />
                </q-popup-proxy>
              </q-icon>
            </template>
          </q-input>
        </div>
        <div class="col-xs-12 col-sm-6">
          <q-input filled v-model="endTime" readonly placeholder="End Time"  @click="showEndDate">
            <template v-slot:prepend>
              <q-icon name="event" class="cursor-pointer">
                <q-popup-proxy transition-show="scale" transition-hide="scale" ref="EndDatePopup">
                  <q-date v-model="endTime" mask="YYYY-MM-DD HH:mm" />
                </q-popup-proxy>
              </q-icon>
            </template>

            <template v-slot:append>
              <q-icon name="access_time" class="cursor-pointer">
                <q-popup-proxy transition-show="scale" transition-hide="scale">
                  <q-time v-model="endTime" mask="YYYY-MM-DD HH:mm" />
                </q-popup-proxy>
              </q-icon>
            </template>
          </q-input>
        </div>
      </div>
    </q-form>
  </div>
</template>


<script>
  export default {
    data() {
      return {
        title: ''
        , location: ''
        , startTime: ''
        , endTime: ''
      }
    }
    , methods: {
      showStartDate() {
        this.$refs.StartDatePopup.show();
      }
      , showEndDate() {
        this.$refs.EndDatePopup.show();
      }
    }
    , computed: {
      qr() {
        function formatDatetime(datetime) {
          let temp = new Date(datetime);
          return temp.getFullYear().toString() + ((temp.getMonth() < 9) ? '0' + (temp.getMonth() + 1) : (temp.getMonth() + 1)) + ((temp.getDate() < 10) ? '0' + temp.getDate() : temp.getDate()) + 'T' + ((temp.getHours() < 10) ? '0' + temp.getHours() : temp.getHours()) + ((temp.getMinutes() < 10) ? '0' + temp.getMinutes() : temp.getMinutes()) + '00'
        }
        return 'BEGIN:VCALENDAR\nBEGIN:VEVENT\nLOCATION: ' + this.location + '\nDTSTART: ' + ((this.startTime === '') ? '' : formatDatetime(this.startTime)) + '\nDTEND: ' + ((this.endTime === '') ? '' : formatDatetime(this.endTime)) + '\nSUMMARY: ' + this.title + '\nEND:VEVENT\nEND:VCALENDAR';
      }
    }
    , watch: {
      qr(val) {
        this.$emit('updateQR', val)
      }
    }
  }
</script>

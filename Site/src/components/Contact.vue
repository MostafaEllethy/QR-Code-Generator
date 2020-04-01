<template>
  <div>
    <q-dialog v-model="contactUs" :full-width="$q.screen.name === 'xs'">
      <q-card style="width: 650px; max-width: 80vw;">
        <q-card-section>
          <iframe src="https://docs.google.com/forms/d/e/1FAIpQLSfpxafb4Un8wTqbCRCENkGC09nXVff6q1P_ZJjoUSB4n062XQ/viewform?embedded=true" height="750" frameborder="0" marginheight="0" marginwidth="0" style="width:100%;">
            Loading�
          </iframe>
        </q-card-section>
      </q-card>
    </q-dialog>
    <div class="text-center q-py-md">
      <a href="javascript:void(0);" class="text-grey-4" style="text-decoration: none;font-size: 1.25rem;font-weight: 500;" @click="showContactUs"><q-icon name="chat" /> Contact Us</a>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        contactUs: false
      }
    }
    , methods: {
      showContactUs() {
        this.contactUs = true;
      }
    }
  }
</script>

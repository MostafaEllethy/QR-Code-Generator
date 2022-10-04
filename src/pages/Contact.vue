<template>
  <div>
    <div class="row">
      <div class="col-xs-12 col-sm-5 text-center self-stretch bg-blue-grey-1 flex justify-center items-center">
        <div class="q-pa-lg">
          <img src="~assets/contact.png" width="175" />
          <p class="text-body1 q-pt-sm">
            If you have any questions or just want to get in touch, use the form below, We look forward to hearing from you!
          </p>
        </div>
      </div>
      <div class="col-xs-12 col-sm-7 q-pa-md">
        <form @submit.prevent="submitForm" class="full-height">
          <div class="row q-col-gutter-md justify-center full-height">
            <template v-if="sent">
              <div class="col-12 text-h4 text-blue-10 text-center">
                <div class="full-height flex justify-center items-center">
                  Thank You!
                </div>
              </div>
            </template>
            <template v-else>
              <h1 class="text-center text-weight-bolder text-h4 no-margin q-pb-xs">Get in touch</h1>
              <div class="col-12">
                <q-input filled v-model="contact.name" label="Name" required :readonly="sending" />
              </div>
              <div class="col-12">
                <q-input filled v-model="contact.email" label="Email" :readonly="sending" />
              </div>
              <div class="col-12">
                <q-input filled v-model="contact.message" label="Message" type="textarea" rows="7" required :readonly="sending" />
              </div>
              <div class="col-sm-5 col-md-3">
                <q-btn type="submit" color="positive" push label="Send" icon-right="send" class="full-width q-py-xs" :loading="sending" />
              </div>
            </template>
          </div>
        </form>
      </div>
    </div>
  </div>

</template>

<script>
  class Contact {
    name = ""
    email = ""
    message = ""
  }

  let module = null;

  export default {
    data() {
      return {
        contact: {}
        , sending: false
        , sent: false
      }
    }
    , created() {
      module = this;
      this.contact = new Contact()
    }
    , methods: {
      submitForm() {
        this.sending = true;
        module.$axios.post(window.apiUrl + '/api/Contacts', this.contact).then(() => {
          this.sending = false;
          this.sent = true;
        })
      }
    }
  }
</script>

<style scoped>
  h1 {
    color: #1A2980;
  }
</style>

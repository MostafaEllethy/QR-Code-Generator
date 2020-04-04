<template>
  <div>
    <q-dialog v-model="contactUs" :persistent="sending">
      <q-card>
        <form @submit.prevent="submitForm">
          <q-toolbar>
            <q-toolbar-title class="text-h5"><span class="text-weight-bold">Contact</span> Us</q-toolbar-title>
            <q-btn flat round icon="close" v-close-popup />
          </q-toolbar>
          <q-separator />
          <q-card-section style="max-height: 60vh;min-width:325px;min-height: 80px;" class="scroll">
            <div class="row q-col-gutter-sm">
              <template v-if="sent">
                <div class="col-12 text-h5 text-blue-10 text-center">
                  Thank You!
                </div>
              </template>
              <template v-else>
                <div class="col-12">
                  <q-input filled v-model="contact.name" label="Name" required :readonly="sending" />
                </div>
                <div class="col-12">
                  <q-input filled v-model="contact.email" label="Email" :readonly="sending" />
                </div>
                <div class="col-12">
                  <q-input filled v-model="contact.message" label="Message" type="textarea" rows="5" required :readonly="sending" />
                </div>
              </template>
            </div>
          </q-card-section>
          <template v-if="!sent">
            <q-separator />
            <q-card-actions align="right">
              <q-btn type="submit" color="positive" icon-right="send" flat label="Send" :loading="sending" />
            </q-card-actions>
          </template>
        </form>
      </q-card>
    </q-dialog>
    <div class="text-center q-py-md">
      <a href="javascript:void(0);" class="text-grey-1" style="text-decoration: none;font-size: 1.25rem;font-weight: 500;" @click="showContactUs"><q-icon name="chat" /> Contact Us</a>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  .gtMobile {
    width: 768px;
    max-width: 80vw;
  }
</style>

<script>
  class Contact {
    name = ""
    email = ""
    message = ""
  }

  let module = null;

  export default {
    props: ['screenSize'],
    data() {
      return {
        contact: {}
        , contactUs: false
        , sending: false
        , sent: false
      }
    }
    , created() {
      module = this;
      this.contact = new Contact()
    }
    , methods: {
      showContactUs() {
        this.contact = new Contact()
        this.sent = false;
        this.contactUs = true;
      }
      , submitForm() {
        this.sending = true;
        module.$axios.post(window.apiUrl + '/api/Contacts', this.contact).then(() => {
          this.sending = false;
          this.sent = true;
        })
      }
    }
  }
</script>

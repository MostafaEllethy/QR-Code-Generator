<template>
  <div>
    <q-card-section>
      <div class="row">
        <div class="col-xs-12 col-sm-7 col-md-8" v-bind:class="{'q-pr-md': screenSize >= 2, 'q-pb-md': screenSize === 1}">
          <router-view @update-qr="updateQR" :screenSize="screenSize" />
        </div>
        <div id="CanvasArea" class="col-xs-12 col-sm-5 col-md-4" v-bind:class="{'border q-pl-md': $q.screen.name !== 'xs'}">
          <QR ref="QR" :screenSize="screenSize"></QR>
        </div>
      </div>
    </q-card-section>
    <div class="row q-px-md bg-grey-2" id="About">
      <div class="col-12">
        <h3 class="text-center text-weight-bold text-grey-7 text-body1 q-pt-xl q-mb-xs no-margin">ABOUT</h3>
        <h2 class="text-center no-margin text-h4 text-weight-bolder text-indigo-10">QR-Code-Generator.info</h2>
        <p class="text-body1 text-center q-pt-md q-px-xl q-pb-xl no-margin">
          QR-Code-Generator.info is a 100% Free Online High Quality QR Codes Generator Which Offers Downloading High Resolution QR Codes for Print and Vector Formats. All Generated QR Codes are Free for Commercial Usage.
        </p>
      </div>
    </div>
    <div class="row q-py-xl" id="FAQ">
      <div class="col-12">
        <h2 style="color: #5c5e70;" class="text-h5 text-center text-weight-bolder q-pb-xl no-margin"><img src="~assets/faq.png" width="65" style="vertical-align:middle;" v-if="$q.screen.name !== 'xs'" /> Frequently Asked Questions</h2>
        <div class="row q-col-gutter-sm q-px-md">
          <div class="col-xs-12 col-sm-6">
            <q-list>
              <q-expansion-item label="What is a QR Code?" header-class="text-weight-bold text-subtitle1" popup>
                <q-separator />
                <q-card>
                  <q-card-section class="text-justify text-subtitle1">
                    A <a href="https://en.wikipedia.org/wiki/QR_code" target="_blank">QR Code</a> is a two-dimensional barcode that consists of a black and white pixel pattern which allows storing data including url links, geo coordinates and text that can be recognized by smartphones and tablets.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="How can QR Codes be scanned?" header-class="text-weight-bold text-subtitle1" popup>
                <q-separator />
                <q-card>
                  <q-card-section class="text-justify text-subtitle1">
                    Scanning QR Codes need nothing more than a mobile phone or tablet and a QR Code reader app that is installed on that device. These QR Code readers are freely available to download from all App Stores.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="Can I use the generated QR Codes for commercial purposes?" header-class="text-weight-bold text-subtitle1" popup>
                <q-separator />
                <q-card>
                  <q-card-section class="text-justify text-subtitle1">
                    Yes, all QR codes you created with this QR generator are free and can be used for whatever you want.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
            </q-list>
          </div>
          <div class="col-xs-12 col-sm-6">
            <q-list v-bind:class="{'q-mt-md': $q.screen.name === 'xs'}">
              <q-expansion-item label="Is QR-Code-Generator.info saving my data?" header-class="text-weight-bold text-subtitle1" popup>
                <q-separator />
                <q-card>
                  <q-card-section class="text-justify text-subtitle1">
                    We do not save, collect or share your data in any form.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="Are the generated QR Codes expiring?" header-class="text-weight-bold text-subtitle1" popup>
                <q-separator />
                <q-card>
                  <q-card-section class="text-justify text-subtitle1">
                    QR Codes do not expire and will work forever! You will not be able to edit the content of the QR Code again.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="My QR code is not working, what can I do?" header-class="text-weight-bold text-subtitle1" popup>
                <q-separator />
                <q-card>
                  <q-card-section class="text-justify text-subtitle1">
                    At first check your entered data. Sometimes there are little typos in your URL that break your QR code. Some QR codes (like vCard) contain a lot of data. Try reducing the data you entered for your QR code if possible. This can make it easier for QR code scanner apps to read your code.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
            </q-list>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import QR from '../components/QR'

  let module = null;

  export default {
    props: ['screenSize']
    , components: { QR }
    , methods: {
      updateQR(val) {
        if (val !== '') {
          this.$refs.QR.updateQR(val);
        }
      }
    }

  }
</script>

<style>
  #FAQ .q-expansion-item {
    padding: 0;
  }
</style>

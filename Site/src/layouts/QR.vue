<template>
  <div>
    <q-card-section>
      <div class="row">
        <div class="col-xs-12 col-sm-7 col-md-8" v-bind:class="{'q-pr-md': screenSize >= 2, 'q-pb-md': screenSize === 1}">
          <router-view @updateQR="updateQR" :screenSize="screenSize" />
        </div>
        <div id="CanvasArea" class="col-xs-12 col-sm-5 col-md-4" v-bind:class="{'border q-pl-md': $q.screen.name !== 'xs'}">
          <QR ref="QR" :screenSize="screenSize"></QR>
        </div>
      </div>
    </q-card-section>
    <div class="row q-px-md q-pb-lg bg-grey-2" id="FAQ">
      <div class="col-12">
        <h2 style="color: #5c5e70;" class="text-h5 text-center text-weight-bolder"><img src="~assets/faq.png" width="65" style="vertical-align:middle;" v-if="$q.screen.name !== 'xs'" /> Frequently Asked Questions</h2>
        <div class="row q-col-gutter-sm">
          <div class="col-xs-12 col-sm-6">
            <q-list>
              <q-expansion-item label="What is QR Code?" popup>
                <q-separator />
                <q-card>
                  <q-card-section>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quidem, eius reprehenderit eos corrupti
                    commodi magni quaerat ex numquam, dolorum officiis modi facere maiores architecto suscipit iste
                    eveniet doloribus ullam aliquid.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="How QR Code Generator works?" popup>
                <q-separator />
                <q-card>
                  <q-card-section>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quidem, eius reprehenderit eos corrupti
                    commodi magni quaerat ex numquam, dolorum officiis modi facere maiores architecto suscipit iste
                    eveniet doloribus ullam aliquid.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="My QR code is not working, what can I do?" popup>
                <q-separator />
                <q-card>
                  <q-card-section>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quidem, eius reprehenderit eos corrupti
                    commodi magni quaerat ex numquam, dolorum officiis modi facere maiores architecto suscipit iste
                    eveniet doloribus ullam aliquid.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
            </q-list>
          </div>
          <div class="col-xs-12 col-sm-6">
            <q-list v-bind:class="{'q-mt-md': $q.screen.name === 'xs'}">
              <q-expansion-item label="What is QR Code?" popup>
                <q-separator />
                <q-card>
                  <q-card-section>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quidem, eius reprehenderit eos corrupti
                    commodi magni quaerat ex numquam, dolorum officiis modi facere maiores architecto suscipit iste
                    eveniet doloribus ullam aliquid.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="How QR Code Generator works?" popup>
                <q-separator />
                <q-card>
                  <q-card-section>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quidem, eius reprehenderit eos corrupti
                    commodi magni quaerat ex numquam, dolorum officiis modi facere maiores architecto suscipit iste
                    eveniet doloribus ullam aliquid.
                  </q-card-section>
                </q-card>
              </q-expansion-item>
              <q-expansion-item label="My QR code is not working, what can I do?" popup>
                <q-separator />
                <q-card>
                  <q-card-section>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quidem, eius reprehenderit eos corrupti
                    commodi magni quaerat ex numquam, dolorum officiis modi facere maiores architecto suscipit iste
                    eveniet doloribus ullam aliquid.
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
          module.$refs.QR.updateQR(val);
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

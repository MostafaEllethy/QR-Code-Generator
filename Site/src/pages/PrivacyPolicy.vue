<template>
  <div>
    <q-card-section>
      <h1 class="text-h4 text-center text-weight-bolder text-indigo-10 no-margin q-pb-xs"><img src="~assets/privacy.png" width="75" style="vertical-align:middle;" /> Privacy Policy</h1>
      <q-separator spaced />
      <h5 class="text-weight-bold text-center" style="line-height: 1;">Thank you for using QR-Code-Generator.info!</h5>
      <div class="q-pb-lg text-justify" v-bind:class="{'q-px-xl': !($q.screen.name === 'xs' ||  $q.screen.name === 'sm')}">
        <div class="text-body1 q-pb-sm">
          <strong>QR-Code-Generator.info</strong> respects the privacy of our users. This page informs you of our policies regarding the collection, use and disclosure of Personal Information we receive from users of the Site.
        </div>
        <div class="text-body1 q-pb-sm">
          We don't collect, use, store, transfer any personal data. We may employ third party companies and individuals to facilitate our Service, to provide the Service on our behalf, to perform Service-related services or to assist us in analyzing how our Service is used.
        </div>
        <div class="text-body1 q-pb-sm">
          <em>Google Analytics.</em> We measure visitors to our website using Google Analytics. This records what pages you view within our site, how you arrived at our site and some basic information about your computer. All of that information is anonymous. So we don’t know who you are, just that somebody visited our site. The information we collect from analytics helps us understand what parts of our site are doing well, how people arrive at our site and so on. Like most websites, we use this information to make our website better. Please <a href="https://www.google.com/policies/privacy/partners/" target="_blank">see here</a> how Google uses data. You can also <a href="https://tools.google.com/dlpage/gaoptout" target="_blank">opt out</a> if you wish.
        </div>
        <div class="text-body1">
          <em>Advertisement</em> on our site. We do not share any data with Advertisers. Third party vendors, including Google, use cookies to serve ads based on prior visits to our site. Google uses a DoubleClick cookie that enables it and its partners to serve ads based on your visit to our site and/or other site on the Internet. You can opt out of the use of the DoubleClick cookie for interest-based advertising by visiting <a href="http://www.google.com/ads/preferences/" target="_blank">Ads Settings</a>. Please see <a href="https://www.google.com/policies/privacy/partners/" target="_blank">here</a> how Google uses data. The cookies of other third-party vendors or ad networks may also be used to serve ads on our site. You can opt out of many third-party vendor's use of cookies for interest-based advertising by visiting <a href="http://www.aboutads.info/choices/" target="_blank">aboutads.info</a>.
        </div>
        <h6 class="q-my-md">Children’s Privacy</h6>
        <div class="text-body1 q-pb-sm">
          Our Service is not intended for and may not be used by children under the age of 13. We do not knowingly collect information from children under the age of 13 and we do not target our Service to children under the age of 13
        </div>
        <div class="text-body1 q-pb-sm">
          Educators that have the authority to act on parent’s behalf, may allow students under 13 to use our Service, if such use is for educational purposes, and if this use ensures that students will not provide any personal information.
        </div>
        <div class="text-body1 q-pb-sm">
          If you have questions about our Service, please contact us at <a href="mailto:admin@qr-code-generator.com">admin@qr-code-generator.com</a> or <router-link :to="{ name: 'Contact'}">here</router-link>;
        </div>
      </div>
    </q-card-section>
  </div>
</template>

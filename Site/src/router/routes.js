
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        path: '', component: () => import('layouts/QR.vue'), children: [
          { name: 'Text', meta: { header: "Text" }, path: '', component: () => import('pages/Text.vue') }
          , { name: 'URL', meta: { header: "URL" }, path: '/url', component: () => import('src/pages/URL.vue') }
          , { name: 'WiFi', meta: { header: "WiFi" }, path: '/wifi', component: () => import('src/pages/WiFi.vue') }
          , { name: 'Phone', meta: { header: "Phone" }, path: '/phone', component: () => import('src/pages/Phone.vue') }
          , { name: 'SMS', meta: { header: "SMS" }, path: '/sms', component: () => import('src/pages/SMS.vue') }
          , { name: 'Email', meta: { header: "Email" }, path: '/email', component: () => import('src/pages/Email.vue') }
          , { name: 'VCard', meta: { header: "VCard" }, path: '/v-card', component: () => import('src/pages/VCard.vue') }
          , { name: 'Location', meta: { header: "Location" }, path: '/location', component: () => import('src/pages/Location.vue') }
          , { name: 'Event', meta: { header: "Event" }, path: '/event', component: () => import('src/pages/Event.vue') }
        ]
      }
      , {
        path: '', component: () => import('layouts/Plain.vue'), children: [
          , { name: 'Contact', path: '/contact-us', component: () => import('pages/Contact.vue') }
          , { name: 'FAQ', path: '/faq', component: () => import('pages/FAQ.vue') }
          , { name: 'PrivacyPolicy', path: '/privacy-policy', component: () => import('pages/PrivacyPolicy.vue') }
        ]
      }
    ]
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}

export default routes

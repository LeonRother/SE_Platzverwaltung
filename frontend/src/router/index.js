import { createRouter, createWebHistory } from 'vue-router'
// import App from '@/App.vue'
import SelectionView from '@/views/SelectionView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: SelectionView, // App
    }
  ]
})

export default router

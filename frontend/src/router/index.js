import { createRouter, createWebHistory } from 'vue-router'
import SelectionView from '@/views/SelectionView.vue'
import LoginView from '@/views/LoginView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: SelectionView, // App
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    }
  ]
})

export default router

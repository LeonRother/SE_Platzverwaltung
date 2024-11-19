import { createRouter, createWebHistory } from 'vue-router'
import SelectionView from '@/views/SelectionView.vue'
import LoginView from '@/views/LoginView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: 'HomeView'
    },
    {
      path: '/selection',
      name: 'Selection',
      component: SelectionView
    },
    {
      path: '/login',
      name: 'Login',
      component: LoginView
    }
  ]
})

export default router

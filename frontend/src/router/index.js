import { createRouter, createWebHistory } from 'vue-router'
import SelectionView from '@/views/SelectionView.vue'
import LoginView from '@/views/LoginView.vue'
import HomeView from '@/views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: HomeView
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

router.beforeEach((to) => {
  if (!isAuthenticated() && to.name !== 'Login') {
    sessionStorage.removeItem('token');
    return { name: 'Login' }
  }
})

function isAuthenticated() {
  let token = sessionStorage.getItem('token');
  if (token === null) return false;

  let base64Url = token.split('.')[1];
  let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  let jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
  }).join(''));
  jsonPayload = JSON.parse(jsonPayload);

  if (Date.now() / 1000 < jsonPayload['exp']) return true;
  else return false;
}

export default router

<template>
  <div class="h-dvh grid place-items-center">
    <div class="w-96 p-4 border bg-gray-50 border-gray-200 shadow-lg shadow-gray-100">
      <h1 class="pb-2 text-xl text-center font-semibold">Sign in to DESKFLEX</h1>
      <form @submit.prevent="submit" class="flex flex-col">
        <input type="email" placeholder="E-Mail" v-model="email" required
               class="mb-2 px-2 outline-none border border-gray-200 focus:border-gray-400">
        <input type="password" placeholder="Password" v-model="password" required
               class="px-2 outline-none border border-gray-200 focus:border-gray-400">
        <p class="mt-2 text-sm text-red-600" v-if="loginFailed">E-Mail or password was incorrect.</p>
        <button type="submit"
                class="my-2 bg-blue-700 hover:bg-blue-900 active:bg-blue-950 text-white">
          Sign in
        </button>
        <a href="#" class="text-sm underline">Reset password</a>
      </form>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'LoginView',
  data() {
    return {
      email: 'zagola.hagen@trumpf.com',
      password: 'password',
      loginFailed: null
    }
  },
  methods: {
    submit() {
      this.loginFailed = false;
      const vue = this; // keep `this` reference when inside axios block

      axios.post('https://localhost:7000/login', {
        email: this.email,
        password: this.password
      })
      .then(function (response) {
        sessionStorage.setItem('token', response.data.token);
        vue.$router.push({ name: 'Home' });
      })
      .catch(() => {
        vue.loginFailed = true;
      });
    }
  }
}
</script>

<template>
  <div class="h-dvh grid place-items-center">
    <div class="w-96 p-4 border bg-gray-50 border-gray-200 shadow-lg shadow-gray-100">
      <h1 class="pb-2 text-xl text-center font-semibold">Sign in to DESKFLEX</h1>
      <form @submit.prevent="handleLogin" class="flex flex-col">
        <input
          type="email"
          v-model="email"
          placeholder="E-Mail"
          required
          class="mb-2 px-2 py-1 border border-gray-200 outline-none focus:border-gray-400"
        />
        <input
          type="password"
          v-model="password"
          placeholder="Password"
          required
          class="px-2 py-1 border border-gray-200 outline-none focus:border-gray-400"
        />
        <p v-if="loginFailed" class="mt-2 text-sm text-red-600">
          E-Mail or password was incorrect.
        </p>
        <button
          type="submit"
          class="my-2 py-1 bg-blue-700 hover:bg-blue-900 active:bg-blue-950 text-white"
        >
          Sign in
        </button>
        <a href="#" class="text-sm underline text-center">Reset password</a>
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
      email: '',
      password: '',
      loginFailed: false
    };
  },
  methods: {
    async handleLogin() {
      this.loginFailed = false;

      try {
        const response = await axios.post('https://localhost:7000/login', {
          email: this.email,
          password: this.password
        });

        sessionStorage.setItem('token', response.data.token);
        this.$router.push({ name: 'Home' });
      } catch(error) {
        console.log(error)
        this.loginFailed = true;
      }
    }
  }
};
</script>

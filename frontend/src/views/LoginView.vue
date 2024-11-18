<template>
  <div class="h-dvh grid place-items-center">
    <div class="w-96 p-4 border bg-gray-50 border-gray-200">
      <h1 class="pb-2 text-xl text-center font-semibold">Sign in to DESKFLEX</h1>
      <form @submit.prevent="submit" class="flex flex-col">
        <input type="email" placeholder="E-Mail" v-model="email"
               class="mb-2 px-2 outline-none border border-gray-200 focus:border-gray-400">
        <input type="password" placeholder="Password" v-model="password"
               class="px-2 outline-none border border-gray-200 focus:border-gray-400">
        <button type="submit"
                class="my-2 bg-blue-700 hover:bg-blue-900 active:bg-blue-950 text-white">
          Sign in
        </button>
        <a href="#" class="text-sm underline">Reset password</a>
      </form>
    </div>
  </div>

  <!-- <div class="h-dvh grid place-items-center bg-black">
    <div class="w-96 p-4 border border-neutral-800 text-white">
      <h1 class="pb-2 text-xl text-center font-semibold">Sign in to DESKFLEX</h1>
      <form class="flex flex-col">
        <input type="email" placeholder="E-Mail" v-model="email"
          class="mb-2 px-2 outline-none font-mono text-sm bg-[orange] text-black placeholder:text-black">
        <input type="password" placeholder="Password" v-model="password"
          class="px-2 outline-none font-mono text-sm bg-[orange] text-black placeholder:text-black">
        <button type="submit"
                class="my-2 text-white bg-neutral-900 hover:bg-neutral-800">
          Sign in
        </button>
        <a href="#" class="text-sm underline">Reset password</a>
      </form>
    </div>
  </div> -->
</template>

<script>
export default {
  name: 'LoginView',
  data() {
    return {
      email: null,
      password: null
    }
  },
  methods: {
    submit() {
      let loginData = {
        "email": this.email,
        "password": this.password
      };
      console.log(loginData);
    }
  }
}
</script>

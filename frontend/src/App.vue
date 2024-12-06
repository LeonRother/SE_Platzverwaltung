<script setup>
import { RouterView } from 'vue-router'
import MenuBar from './components/MenuBar.vue';
</script>

<template>
  <MenuBar v-if="$route.name != 'Login'" />
  <RouterView :class="{ 'my-4 mx-8 md:mx-32 lg:mx-64' : $route.name != 'Login' }" />
</template>

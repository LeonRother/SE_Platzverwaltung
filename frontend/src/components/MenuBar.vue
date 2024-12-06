<template>
  <header class="py-2 bg-gray-50 border-b border-gray-300 shadow-md shadow-gray-100">
    <ul class="flex flex-row flex-wrap gap-4 px-8">
      <button class="px-4 h-8 text-violet-900 bg-violet-200 hover:bg-violet-300 active:bg-violet-400 rounded underline" @click="this.$router.push({ name: 'Home' })">
      Home
      </button>
      <button class="px-4 h-8 bg-gray-200 hover:bg-gray-300 active:bg-gray-400 rounded" @click="this.$router.push({ name: 'Selection' })">
        Show workplaces
      </button>
      <button disabled class="px-4 h-8 bg-gray-200 hover:bg-gray-300 active:bg-gray-400 rounded disabled:bg-gray-100 disabled:text-gray-400" @click="this.$router.push({ name: 'Booking' })">
        My bookings
      </button>
      <button disabled class="px-4 h-8 bg-gray-200 hover:bg-gray-300 active:bg-gray-400 rounded disabled:bg-gray-100 disabled:text-gray-400" @click="this.$router.push({ name: 'Defect' })">
        Report defect
      </button>

      <button class="ml-auto px-4 h-8 bg-gray-200 hover:bg-gray-300 active:bg-gray-400 rounded">
        Log out
      </button>
    </ul>
  </header>
</template>

<script>
export default {
  name: 'MenuBar'
}
</script>

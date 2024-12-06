<template>
  <div>
    <h1 class="text-2xl font-bold">Hello {{ firstname }}!</h1>
    <p>Your seat for today is [_____] at [_____].</p>
  </div>
</template>

<script>
export default {
  name: 'HomeView',
  data() {
    return {
      firstname: null
    }
  },
  methods: {
    parseJwt (token) { // from https://stackoverflow.com/a/38552302
      let base64Url = token.split('.')[1];
      let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      let jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
          return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
      }).join(''));

      return JSON.parse(jsonPayload);
    }
  },
  mounted() {
    this.firstname = this.parseJwt(sessionStorage.getItem('token'))['firstname'];
  }
}
</script>

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
      firstname: ''
    };
  },
  methods: {
    decodeToken(token) {
      if (!token) return {};

      try {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(
          atob(base64)
            .split('')
            .map((char) => `%${('00' + char.charCodeAt(0).toString(16)).slice(-2)}`)
            .join('')
        );
        return JSON.parse(jsonPayload);
      } catch (error) {
        console.warn('Invalid JWT:', error);
        return {};
      }
    }
  },
  mounted() {
    const token = sessionStorage.getItem('token');
    const payload = this.decodeToken(token);
    this.firstname = payload.firstname ?? 'Guest';
  }
};
</script>

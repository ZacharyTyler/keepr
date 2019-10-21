<template>
  <div class="dashboard">
    <h1>Test</h1>
  </div>
</template>

<script>
export default {
  name: "dashboard",
  mounted() {},
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
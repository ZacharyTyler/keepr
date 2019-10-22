<template>
  <div class="dashboard">
    <div class="row">
      <div class="col">
        <h1>DashBoard</h1>
      </div>
    </div>
    <div class="row">
      <div class="col"></div>
      <button class="btn-primary vault-button" data-toggle="modal" data-target="#viewModal">
        <h4>Go to Vault</h4>
      </button>
    </div>
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
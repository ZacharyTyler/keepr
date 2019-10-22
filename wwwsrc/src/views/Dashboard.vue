<template>
  <div class="dashboard">
    <div class="row">
      <div class="col-12">
        <h1>DashBoard</h1>
      </div>
    </div>

    <div class="row justify-content-center">
      <div class="col-12">
        <h2>Vaults</h2>
      </div>
      <div class="col-3 m-3 border p-2" v-for="vault in vaults" :key="vault.id">
        <h3>{{vault.name}}</h3>
        <h3>{{vault.description}}</h3>
        <button
          class="btn-primary vault-button"
          data-toggle="modal"
          data-target="#vaultModal"
          @click="getKeepsByVaultId(vault.id)"
        >Open Vault</button>
        <vaultModal />
      </div>
    </div>
  </div>
</template>

<script>
import vaultModal from "../Components/VaultModal";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getVaultsByUser");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    getKeepsByVaultId(vaultId) {
      this.$store.dispatch("getKeepsByVaultId", vaultId);
    }
  },
  components: {
    vaultModal
  }
};
</script>
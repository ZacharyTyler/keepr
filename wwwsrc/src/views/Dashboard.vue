<template>
  <div class="dashboard">
    <div class="row">
      <div class="col-12">
        <h1>DashBoard</h1>
        <router-link :to="{name: 'home'}">Home</router-link>
      </div>
    </div>
    <hr />
    <br />
    <div class="row justify-content-center">
      <div class="col-12">
        <h2>Vaults</h2>
      </div>
      <div class="col-3 m-3 border p-2" v-for="vault in vaults" :key="vault.id">
        <h3>{{vault.name}}</h3>
        <h3>{{vault.description}}</h3>
        <button class="btn-danger" @click="deleteVault(vault.id)">X</button>

        <button
          class="btn-primary vault-button"
          data-toggle="modal"
          data-target="#vaultModal"
          @click="getKeepsByVaultId(vault.id), getVault(vault.id)"
        >Open Vault</button>
        <vaultModal :vaultIdProp="vault.id" />
      </div>

      <div class="col-12">
        <button class="btn-success" data-toggle="modal" data-target="#createVaultModal">Create Vault</button>
        <createVaultModal />
      </div>
    </div>

    <br />
    <div class="row justify-content-center">
      <div class="col-12">
        <h2>Keeps</h2>
      </div>
      <div class="col-3 m-3 border p-2" v-for="keep in userKeeps" :key="keep.id">
        <h3>{{keep.name}}</h3>
        <h3>{{keep.description}}</h3>
        <img :src="keep.img" />
        <br />
        <br />
        <button class="btn-danger" @click="deleteKeep(keep.id)">X</button>
      </div>
    </div>

    <div class="col-12">
      <button class="btn-success" data-toggle="modal" data-target="#createKeepModal">Create Keep</button>
      <createKeepModal />
    </div>
  </div>
</template>

<script>
import vaultModal from "../Components/VaultModal";
import createVaultModal from "../Components/CreateVaultModal";
import createKeepModal from "../Components/CreateKeepModal";

export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getVaultsByUser");
    this.$store.dispatch("getUserKeeps");
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
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    getKeepsByVaultId(vaultId) {
      this.$store.dispatch("getKeepsByVaultId", vaultId);
    },
    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    },
    getVault(vaultId) {
      this.$store.dispatch("getVault", vaultId);
    },
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    }
  },
  components: {
    vaultModal,
    createVaultModal,
    createKeepModal
  }
};
</script>
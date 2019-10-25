<template>
  <div class="dashboard">
    <h1>Dashboard</h1>
    <div class="row float justify-content-center align-items-top">
      <button class="btn btn-link" @click="logout">Logout</button>
      <p v-if="user.id" class="pl-1 pr-2 float justify-content-center mt-3">|</p>
      <router-link class="mt-3 ml-2" v-if="user.id" :to="{name: 'home'}">Home</router-link>
    </div>
    <hr />
    <br />
    <div class="row justify-content-center">
      <div class="col-12">
        <h2>
          <u>Vaults</u>
        </h2>
      </div>
      <div class="col-3 m-3 border border-dark p-2" v-for="vault in vaults" :key="vault.id">
        <h3>{{vault.name}}</h3>
        <h3>{{vault.description}}</h3>

        <button
          class="btn-primary vault-button mr-2"
          data-toggle="modal"
          data-target="#vaultModal"
          @click="getKeepsByVaultId(vault.id), getVault(vault.id)"
        >Open Vault</button>
        <button class="btn-danger" @click="deleteVault(vault.id)">X</button>
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
        <h2>
          <u>Keeps</u>
        </h2>
      </div>
      <div class="col-3 m-3 border border-dark p-2" v-for="keep in userKeeps" :key="keep.id">
        <h3>{{keep.name}}</h3>
        <h3>{{keep.description}}</h3>
        <img :src="keep.img" />
        <br />
        <br />
        <h3>Views: {{keep.views}}</h3>
        <h3>Keeps: {{keep.keeps}}</h3>
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
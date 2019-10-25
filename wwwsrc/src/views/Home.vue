<template>
  <div class="home">
    <h1>Welcome to Keepr, {{user.username}}</h1>
    <div class="row float justify-content-center align-items-top">
      <button class="btn btn-link" v-if="user.id" @click="logout">Logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
      <p v-if="user.id" class="pl-1 pr-2 float justify-content-center mt-3">|</p>
      <router-link class="mt-3 ml-2" v-if="user.id" :to="{name: 'dashboard'}">My Dashboard</router-link>
    </div>
    <div class="row d-flex align-items-center">
      <div class="col-3 pt-4 border m-5 pb-2" v-for="keep in keeps" :key="keep.id">
        <img :src="`${keep.img}`" />
        <h3>{{keep.description}}</h3>
        <div class="row">
          <div class="col">
            <button
              class="btn-primary views-button"
              data-toggle="modal"
              data-target="#viewModal"
              @click="getKeepById(keep)"
            >
              <h4>View: {{keep.views}}</h4>
            </button>
            <viewModal />
            <br />
            <br />
            <div class="dropdown" v-if="user.id">
              <button
                class="btn btn-secondary"
                type="button"
                id="dropdownMenuButton"
                data-toggle="dropdown"
              >
                <h4>Keeps: {{keep.keeps}}</h4>
              </button>
              <div class="dropdown-menu">
                <div
                  class="dropdown-item"
                  v-for="vault in vaults"
                  :key="vault.id"
                  @click="addKeep(keep, vault.id)"
                >{{vault.name}}</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import viewModal from "../Components/ViewModal";
export default {
  name: "home",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaultsByUser");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      let data = this.$store.state.keeps;
      let out = {};
      let x = 0;
      for (let i = 0; i < data.length; i++) {
        if (data[i].isPrivate == false) {
          out[x] = data[i];
          x++;
        }
      }
      return out;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    getKeepById(keep) {
      this.$store.dispatch("getKeepById", keep.id);
      keep.views = keep.views + 1;
      this.$store.dispatch("plusOne", keep);
    },
    addKeep(keep, vaultId) {
      let payload = {
        keepId: keep.id,
        vaultId: vaultId
      };
      this.$store.dispatch("addKeep", payload);
      keep.keeps = keep.keeps + 1;
      this.$store.dispatch("plusOne", keep);
    }
  },
  components: {
    viewModal
  }
};
</script>
<style>
img {
  max-width: 300px;
}
</style>
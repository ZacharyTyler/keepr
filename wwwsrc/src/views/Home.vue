<template>
  <div class="home">
    <h1>Welcome to Keepr, {{user.username}}</h1>
    <div class="row float justify-content-center">
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
      <span v-if="user.id">
        <p class="pl-2 pr-2 float justify-content-center">|</p>
      </span>
      <span v-if="user.id">
        <router-link :to="{name: 'dashboard'}">My DashBoard</router-link>
      </span>
    </div>
    <div class="row">
      <div class="col-3 pt-4 border m-5 pb-2" v-for="keep in keeps" :key="keep.id">
        <img :src="`${keep.img}`" />
        <h3>{{keep.description}}</h3>
        <button
          class="btn-primary views-button"
          data-toggle="modal"
          data-target="#viewModal"
          @click="plusOne(keep)"
        >
          <h4>View: {{keep.views}}</h4>
        </button>
        <viewModal :keepProp="keep" />

        <div class="dropdown">
          <button
            class="btn btn-secondary dropdown-toggle"
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
    plusOne(keep) {
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
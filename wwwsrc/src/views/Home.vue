<template>
  <div class="home">
    <h1>Welcome to Keepr, {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <router-link :to="{name: 'dashboard'}">My DashBoard</router-link>
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
        <button class="btn-primary">
          <h4>Keeps: {{keep.keeps}}</h4>
        </button>
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
  },
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
    },
    plusOne(keep) {
      keep.views = keep.views + 1;
      this.$store.dispatch("plusOne", keep);
    }
  },
  components: {
    viewModal
  }
};
</script>
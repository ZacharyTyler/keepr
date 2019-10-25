<template>
  <div id="vaultModal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="row justify-content-center">
          <div class="col-3 m-2" v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id">
            <div class="modal-body">
              <h5>{{vaultKeep.name}}</h5>
              <img class="imgSmall" :src="vaultKeep.img" />
              <p>{{vaultKeep.description}}</p>
              <button class="btn-danger" @click="deleteVaultKeep(vaultKeep.id)">X</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "vaultModal",
  props: ["vaultIdProp"],
  mounted() {},
  methods: {
    deleteVaultKeep(vaultKeepId) {
      let payload = {
        vaultId: this.vault.id,
        keepId: vaultKeepId
      };
      this.$store.dispatch("deleteVaultKeepById", payload);
    }
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    },
    vault() {
      return this.$store.state.vault;
    }
  }
};
</script>
<style>
.imgSmall {
  max-width: 140px;
}
</style>
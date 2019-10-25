<template>
  <div id="vaultModal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-4" v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id">
                <h3>{{vaultKeep.name}}</h3>
                <img :src="vaultKeep.img" />
                <h3>{{vaultKeep.description}}</h3>
                <button class="btn-danger" @click="deleteVaultKeep(vaultKeep.id)">X</button>
              </div>
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
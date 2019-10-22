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
  mounted() {
    // this.$store.dispatch("getKeepsByVaultId", this.vaultIdProp);
  },
  methods: {},
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  }
};
</script>
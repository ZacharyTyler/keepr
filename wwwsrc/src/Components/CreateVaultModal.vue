<template>
  <div id="createVaultModal" class="modal fade text-center" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row justify-content-center">
              <form @submit.prevent="createNewVault()">
                <div class="row justify-content-center">
                  <div class="col">
                    <label for="name">Vault Name:</label>
                    <input
                      type="text"
                      class="form-control text-center"
                      v-model="newVault.name"
                      placeholder="Vault Name"
                      id="vaultName"
                      required
                    />
                  </div>
                </div>
                <div class="row justify-content-center">
                  <div class="col">
                    <label for="description">Vault Description:</label>
                    <input
                      type="text"
                      class="form-control text-center"
                      v-model="newVault.description"
                      placeholder="Vault Description"
                      id="vaultDescription"
                      required
                    />
                  </div>
                </div>
                <button
                  class="register-button"
                  data-dismiss="modal"
                  @click="createNewVault()"
                >submit</button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "createVaultModal",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    createNewVault() {
      this.$store.dispatch("createNewVault", this.newVault);
    }
  },
  components: {}
};
</script>


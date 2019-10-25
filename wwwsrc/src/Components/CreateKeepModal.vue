<template>
  <div id="createKeepModal" class="modal fade text-center" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row justify-content-center">
              <form @submit.prevent="createNewKeep()">
                <div class="row justify-content-center">
                  <div class="col">
                    <label for="name">Keep Name:</label>
                    <input
                      type="text"
                      class="form-control text-center"
                      v-model="newKeep.name"
                      placeholder="Keep Name"
                      id="vaultName"
                      required
                    />
                  </div>
                </div>
                <div class="row justify-content-center">
                  <div class="col">
                    <label for="description">Keep Description:</label>
                    <input
                      type="text"
                      class="form-control text-center"
                      v-model="newKeep.description"
                      placeholder="Keep Description"
                      id="vaultDescription"
                      required
                    />
                  </div>
                </div>
                <div class="row justify-content-center">
                  <div class="col">
                    <label for="img">Keep Image URL:</label>
                    <input
                      type="text"
                      class="form-control text-center"
                      v-model="newKeep.img"
                      placeholder="Image URL"
                      id="vaultImg"
                      required
                    />
                  </div>
                </div>

                <div class="row justify-content-center">
                  <h3>Private Status:</h3>
                  <div class="custom-control custom-radio">
                    <input
                      type="radio"
                      id="true"
                      name="privateStatus"
                      v-model="newKeep.isPrivate"
                      v-bind:value="true"
                      class="custom-control-input"
                    />
                    <label class="custom-control-label" for="true">Private:</label>
                  </div>
                  <div class="custom-control custom-radio">
                    <input
                      type="radio"
                      id="false"
                      name="privateStatus"
                      v-model="newKeep.isPrivate"
                      v-bind:value="false"
                      class="custom-control-input"
                      checked
                    />
                    <label class="custom-control-label" for="false">Public:</label>
                  </div>
                </div>

                <button class="register-button" data-dismiss="modal" @click="createNewKeep()">submit</button>
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
  name: "createKeepModal",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {},
  methods: {
    createNewKeep() {
      this.newKeep.views = 0;
      this.newKeep.keeps = 0;
      this.newKeep.shares = 0;
      this.$store.dispatch("createNewKeep", this.newKeep);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>
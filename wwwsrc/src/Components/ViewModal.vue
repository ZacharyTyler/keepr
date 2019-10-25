<template>
  <div id="viewModal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <img class="imgSize" :src="`${keep.img}`" />
          <h3>{{keep.description}}</h3>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "viewModal",
  methods: {},
  computed: {
    keep() {
      return this.$store.state.keep;
    }
  }
};
</script>
<style>
.imgSize {
  max-width: 700px;
  min-width: 600px;
}
</style>
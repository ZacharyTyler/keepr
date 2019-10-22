<template>
  <div id="viewModal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <img :src="`${keepProp.img}`" />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "viewModal",
  props: ["keepProp"],
  methods: {},
  computed: {}
};
</script>
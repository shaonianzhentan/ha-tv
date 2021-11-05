<template>
  <div
    :class="['ha-camera']"
    v-focusable
    @click="visible = !visible"
    @onBlur="visible = false"
  >
    <b>{{ data.friendly_name }}</b>
    <img :src="hass.hassUrl + data.entity_picture" style="width: 100%" />
  </div>
</template>
<script>
export default {
  props: {
    data: {},
  },
  data() {
    return {
      visible: false,
    };
  },
};
</script>
<style lang="less">
.ha-camera {
  width: 450px !important;
  height: 300px !important;
  b {
    margin-bottom: 10px;
    display: block;
  }
  &.focus {
    transform: scale(1) !important;
    background-color: black !important;
    border: 1px solid white !important;
  }
}
</style>
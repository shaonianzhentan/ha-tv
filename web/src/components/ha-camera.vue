<template>
  <div :class="['ha-camera', { 'state-on': data.state == 'on' }]" v-focusable>
    <img :src="hass.hassUrl + data.entity_picture" style="width: 100%" />
    <b>{{ data.friendly_name }}</b>
  </div>
</template>
<script>
export default {
  props: {
    data: {},
  },
  data() {
    return {};
  },
};
</script>
<style lang="less">
.ha-camera {
  width: 620px !important;
  height: 400px !important;
  &.focus {
    transform: scale(1) !important;
    background-color: black !important;
    border: 1px solid white !important;
  }
}
</style>
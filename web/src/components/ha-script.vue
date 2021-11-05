<template>
  <div
    :class="['ha-script', { 'state-on': data.state == 'on' }]"
    v-focusable
    @click="hass.trigger(data)"
  >
    <ha-icon :name="data.icon" />
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
</style>
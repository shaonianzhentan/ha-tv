<template>
  <div
    :class="['ha-switch', { 'state-on': data.state == 'on' }]"
    v-focusable
    @click="hass.toggle(data)"
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
  methods: {},
};
</script>
<style lang="less">
.ha-switch {
}
</style>
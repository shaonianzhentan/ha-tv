<template>
  <div :class="['ha-sensor', { active: data.state == 'on' }]" v-focusable>
    <i v-if="data.domain == 'sensor'">{{ data.state }}</i>
    <ha-icon v-else :name="data.icon" />
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
.ha-sensor {
  i {
    font-size: 40px;
    font-weight: 100;
    font-style: normal;
    margin-top: 30px;
  }
  &.active {
    i {
      color: yellow;
    }
  }
}
</style>
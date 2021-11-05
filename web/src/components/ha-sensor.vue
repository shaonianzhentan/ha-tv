<template>
  <div
    :class="[
      'ha-sensor',
      {
        'state-on': data.state == 'on',
        'state-unavailable': ['unknown', 'unavailable'].includes(data.state),
      },
      data.domain,
    ]"
    v-focusable
  >
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
  &.sensor {
    i {
      font-size: 30px !important;
      font-style: normal;
      margin-top: 30px;
    }
  }
}
</style>
<template>
  <div>
    <i :class="['mdi', data.icon.replace('mdi:', 'mdi-')]"></i>
    <b>{{ data.friendly_name }}</b>
  </div>
</template>
<script>
export default {
  props: {
    data: Object,
  },
  data() {
    return {};
  },
  created() {},
};
</script>
<style lang="less" scoped>
</style>
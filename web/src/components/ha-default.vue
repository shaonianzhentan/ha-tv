<template>
  <div class="ha-default" v-focusable>
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
.ha-default {
}
</style>
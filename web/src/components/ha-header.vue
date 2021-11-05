<template>
  <div class="ha-header">
    <h1 class="today">
      <span>{{ todayTime }}</span>
      <br />
      {{ todayDate }}
    </h1>
  </div>
</template>
<script>
export default {
  data() {
    return {
      todayTime: "",
      todayDate: "",
    };
  },
  created() {
    const week = ["日", "一", "二", "三", "四", "五", "六"];
    setInterval(() => {
      const today = new Date();
      this.todayTime = `${today.toLocaleTimeString()}`;
      this.todayDate = `${today.getMonth() + 1} 月 ${today.getDate()} 日，周${
        week[today.getDay()]
      }`;
    }, 1000);
  },
};
</script>
<style lang="less" scoped>
.ha-header {
  padding: 0 0 50px 20px;
  .today {
    display: inline-block;
  }
}
</style>
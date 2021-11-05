<template>
  <div class="ha-header">
    <h1 class="today">
      <span>{{ todayTime }}</span>
      <br />
      {{ todayDate }}
    </h1>
    <div class="weather">
      <ha-icon
        name="mdi-weather-cloudy"
        style="font-size: 90px; margin-top: -30px; position: absolute"
      />
      <div style="margin-left: 130px; font-size: 23px">
        温度：{{ data.temperature }} ℃
        <br />
        湿度：{{ data.humidity }} %
      </div>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    data: {},
  },
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
  .weather {
    display: inline-block;
    float: right;
  }
}
</style>
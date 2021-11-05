<template>
  <div class="views-index">
    <ha-header />
    <div class="area-list">
      <span
        class="focus-item"
        v-focusable
        v-for="(area, index) in areaList"
        :key="index"
        @onFocus="areaClick(area)"
        >{{ area.name }}</span
      >
    </div>
    <div class="device-list">
      <component
        class="ha-entity"
        v-for="(entity, index) in entityList"
        :is="componentName(entity.domain)"
        :data="entity"
        :key="index"
      ></component>
    </div>
  </div>
</template>
<script>
export default {
  components: {
    "ha-header": () => import("@/components/ha-header"),
    "ha-default": () => import("@/components/ha-default"),
    "ha-media_player": () => import("@/components/ha-media_player"),
    "ha-sensor": () => import("@/components/ha-sensor"),
    "ha-switch": () => import("@/components/ha-switch"),
  },
  data() {
    return {
      today: "",
      todayTime: "",
      todayDate: "",
      areaList: [
        { name: "全部", value: "" },
        { name: "灯", value: "light" },
        { name: "开关", value: ["switch", "input_boolean"] },
        { name: "风扇", value: "fan" },
        { name: "传感器", value: ["sensor", "binary_sensor"] },
        { name: "脚本", value: "script" },
        { name: "自动化", value: "automation" },
      ],
      list: [],
      entityList: [],
    };
  },
  mounted() {
    this.$tv.requestFocus(
      document.querySelector(".area-list .focus-item"),
      false
    );
  },
  methods: {
    componentName(domain) {
      if (["switch", "input_boolean"].includes(domain)) return "ha-switch";
      if (["sensor", "binary_sensor"].includes(domain)) return "ha-sensor";
      if (["media_player"].includes(domain)) return "ha-media_player";
      return "ha-default";
    },
    areaClick({ value }) {
      const { entities } = this.hass;
      if (value) {
        let arr = Array.isArray(value) ? value : [value];
        this.entityList = entities.filter((ele) => arr.includes(ele.domain));
      } else {
        this.entityList = entities;
      }
    },
  },
};
</script>
<style lang="less">
.views-index {
  padding: 50px;
  color: white;
  .area-list {
    padding: 10px;
    .focus-item {
      padding: 10px;
      font-size: 30px;
    }
    .focus {
      color: #03a9f4;
    }
  }
  .device-list {
    .ha-entity {
      width: 150px;
      height: 200px;
      margin: 10px;
      display: inline-block;
      background-color: rgba(0, 0, 0, 0.5);
      color: white;
      box-sizing: border-box;
      border-radius: 10px;
      padding: 10px;
      vertical-align: top;
      text-align: center;
      overflow: hidden;
      text-overflow: ellipsis;
      i {
        font-size: 70px;
        display: block;
        padding: 10px 0;
      }
      b {
        font-size: 20px;
      }
    }
    .focus {
      transform: scale(1.1);
      border: 2px solid white;
      background-color: #03a9f4;
    }
  }
}
</style>

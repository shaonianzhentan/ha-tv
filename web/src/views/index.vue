<template>
  <div class="views-index">
    <ha-header :data="weather" />
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
        v-for="(entity, index) in list"
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
    "ha-script": () => import("@/components/ha-script"),
    "ha-camera": () => import("@/components/ha-camera"),
  },
  data() {
    return {
      weather: {},
      area: "",
      areaList: [
        { name: "全部", value: "" },
        { name: "灯", value: "light" },
        { name: "开关", value: ["switch", "input_boolean"] },
        { name: "风扇", value: "fan" },
        { name: "传感器", value: ["sensor", "binary_sensor"] },
        { name: "脚本", value: "script" },
        { name: "自动化", value: "automation" },
        { name: "播放器", value: "media_player" },
        { name: "摄像机", value: "camera" },
      ],
      list: [],
    };
  },
  mounted() {
    this.$tv.requestFocus(
      document.querySelector(".area-list .focus-item"),
      false
    );
    this.areaClick({ value: "" });
    this.hass.on("update", () => {
      this.areaClick({ value: this.area });
    });
  },
  methods: {
    componentName(domain) {
      if (["switch", "input_boolean", "light", "fan"].includes(domain))
        return "ha-switch";
      if (["sensor", "binary_sensor"].includes(domain)) return "ha-sensor";
      if (["script", "automation"].includes(domain)) return "ha-script";
      if (["media_player"].includes(domain)) return "ha-media_player";
      if (["camera"].includes(domain)) return "ha-camera";
      return "ha-default";
    },
    areaClick({ value }) {
      this.area = value;
      const { entities } = this.hass;
      if (value) {
        let arr = Array.isArray(value) ? value : [value];
        this.list = entities.filter((ele) => arr.includes(ele.domain));
      } else {
        this.list = entities;
      }
      const weathers = entities.filter((ele) => ele.domain == "weather");
      if (weathers.length > 0) {
        const { temperature, humidity } = weathers[0];
        this.weather = {
          temperature,
          humidity,
        };
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
    &.state-on {
      i {
        color: yellow;
      }
    }
    &.state-unavailable {
      color: gray;
    }
    &.focus {
      transform: scale(1.1);
      border: 2px solid white;
      background-color: #03a9f4;
    }
  }
}
</style>

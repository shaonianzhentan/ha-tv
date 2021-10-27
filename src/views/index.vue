<template>
  <div class="views-index">
    <div class="area-list">
      <span class="focus-item" v-focusable>全部</span>
      <span class="focus-item" v-focusable>卧室</span>
      <span class="focus-item" v-focusable>卫生间</span>
      <span class="focus-item" v-focusable>次卧</span>
      <span class="focus-item" v-focusable>餐厅</span>
      <span class="focus-item" v-focusable>阳台</span>
    </div>
    <div class="device-list">
      <component
        v-focusable
        :is="'ha-' + entity.domain"
        class="ha-entity"
        v-for="(entity, index) in entityList"
        :data="entity"
        :key="index"
      ></component>
    </div>
  </div>
</template>
<script>
export default {
  components: {
    "ha-light": () => import("@/components/entitys/ha-light"),
  },
  data() {
    return {
      areaList: [],
      entityList: [
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
      ],
    };
  },
};
</script>
<style lang="less" scoped>
.views-index {
  .area-list {
    .focus-item {
    }
    .focus {
      color: red;
    }
  }
  .device-list {
    .ha-entity {
      width: 100px;
      height: 100px;
      margin: 10px;
      display: inline-block;
      background-color: pink;
      box-sizing: border-box;
      vertical-align: top;
      i {
        font-size: 40px;
      }
    }
    .focus {
      transform: scale(1.1);
      border: 2px solid red;
      box-shadow: 0 0 20px red;
    }
  }
}
</style>

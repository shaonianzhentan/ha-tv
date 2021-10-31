<template>
  <div class="views-index">
    <div class="header">
      <h1>
        上午 12:18
        <br />
        周日，十月 31
      </h1>
    </div>
    <div class="area-list">
      <span class="focus-item" v-focusable>全部</span>
      <span class="focus-item" v-focusable>未分配</span>
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
        @click.native="showDialogClick(entity)"
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
          icon: "mdi-lightbulb-on-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi-toggle-switch-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
        {
          icon: "mdi:led-outline",
          friendly_name: "设备名称",
          domain: "light",
        },
      ],
    };
  },
  mounted() {
      document.dispatchEvent(new KeyboardEvent('keydown', { keyCode: 40 }));
  },
  methods: {
    showDialogClick(entity) {
      console.log(entity);
    },
  },
};
</script>
<style lang="less">
.views-index {
  padding: 50px;
  color: white;
  .header {
    padding: 0 0 50px 20px;
  }
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

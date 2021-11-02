<template>
  <div class="views-index">
    <div class="header">
      <h1 class="today">
        <span>{{ todayTime }}</span>
        <br />
        {{ todayDate }}
        <br />
        {{ today }}
      </h1>
    </div>
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
      <div
        v-focusable
        v-for="(entity, index) in entityList"
        :class="['ha-entity', { active: entity.state == 'on' }, entity.domain]"
        :data="entity"
        :key="index"
        @click="showDialogClick($event, entity)"
      >
        <i v-if="entity.domain == 'sensor'">{{ entity.state }}</i>
        <i v-else :class="['mdi', entity.icon]"></i>
        <b>{{ entity.friendly_name }}</b>
      </div>
    </div>
  </div>
</template>
<script>
import {
  getAuth,
  createConnection,
  subscribeEntities,
  getUser,
  ERR_HASS_HOST_REQUIRED,
} from "home-assistant-js-websocket";

export default {
  components: {},
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
  computed: {},
  mounted() {
    this.connect();
    const week = ["日", "一", "二", "三", "四", "五", "六"];
    setInterval(() => {
      const today = new Date();
      this.todayTime = `${today.toLocaleTimeString()}`;
      this.todayDate = `${today.getMonth() + 1} 月 ${today.getDate()} 日，周${
        week[today.getDay()]
      }`;
    }, 1000);
    this.$tv.requestFocus(
      document.querySelector(".area-list .focus-item"),
      false
    );
  },
  methods: {
    async connect() {
      let auth;
      try {
        // Try to pick up authentication after user logs in
        auth = await getAuth({
          loadTokens() {
            try {
              return JSON.parse(localStorage["hassTokens"]);
            } catch {}
          },
          saveTokens: (data) => {
            localStorage["hassTokens"] = JSON.stringify(data);
          },
        });
      } catch (err) {
        if (err === ERR_HASS_HOST_REQUIRED) {
          const hassUrl = "http://192.168.1.118";
          // Redirect user to log in on their instance
          auth = await getAuth({ hassUrl });
        } else {
          alert(`Unknown error: ${err}`);
          return;
        }
      }
      const connection = await createConnection({ auth });
      subscribeEntities(connection, (ent) => {
        this.updateList(ent);
        // console.log(ent);
      });
      this.hass = connection;
      // 初始化登录信息
      getUser(connection).then((user) => {
        console.log("Logged in as", user);
      });
    },
    async callService(serviceName, service_data = {}) {
      let arr = serviceName.split(".");
      const result = await this.hass.sendMessagePromise({
        type: "call_service",
        domain: arr[0],
        service: arr[1],
        service_data,
      });
      return result;
    },
    updateList(ent) {
      const list = Object.keys(ent).map((entity_id) => {
        const { attributes, state } = ent[entity_id];
        // console.log(ent[entity_id]);
        const domain = entity_id.split(".")[0];
        if (!attributes["icon"]) {
          const icon = {
            light: {
              on: "mdi-lightbulb-on-outline",
              off: "mdi-lightbulb-outline",
            },
            switch: {
              on: "mdi-toggle-switch-outline",
              off: "mdi-toggle-switch-off-outline",
            },
            input_boolean: {
              on: "mdi-electric-switch",
              off: "mdi-electric-switch",
            },
            fan: {
              on: "mdi-fan",
              off: "mdi-fan-off",
            },
            script: {
              on: "mdi-script",
              off: "mdi-script-outline",
            },
            binary_sensor: {
              on: "mdi-checkbox-blank-circle",
              off: "mdi-checkbox-blank-circle-outline",
            },
            automation: {
              on: "mdi-robot",
              off: "mdi-robot-outline",
            },
          };
          let obj = icon[domain];
          let state_icon = null;
          if (obj) {
            state_icon = obj[state];
          }
          if (state_icon) {
            attributes["icon"] = state_icon.replace("mdi:", "mdi-");
          }
        } else {
          attributes["icon"] = attributes["icon"].replace("mdi:", "mdi-");
        }
        return {
          ...attributes,
          state,
          entity_id,
          domain,
        };
      });
      if (this.list.length === 0 && this.entityList.length === 0) {
        this.entityList = list;
      } else {
        // console.log(list);
        this.entityList.forEach((ele, index) => {
          const obj = list.find(({ entity_id }) => entity_id == ele.entity_id);
          if (obj && obj.state !== ele.state) {
            this.$set(this.entityList, index, obj);
          }
        });
      }
      this.list = list;
    },
    areaClick({ value }) {
      if (value) {
        if (Array.isArray(value)) {
          this.entityList = this.list.filter((ele) =>
            value.includes(ele.domain)
          );
        } else {
          this.entityList = this.list.filter((ele) => ele.domain == value);
        }
      } else {
        this.entityList = JSON.parse(JSON.stringify(this.list));
      }
    },
    showDialogClick(event, entity) {
      const state = entity.state == "on" ? "off" : "on";
      this.callService(`${entity.domain}.turn_${state}`, {
        entity_id: entity.entity_id,
      });
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
    .today {
      display: inline-block;
    }
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
      &.active {
        i {
          color: yellow;
        }
      }
      &.sensor {
        i {
          font-size: 40px;
          font-weight: 100;
          font-style: normal;
          margin-top: 30px;
        }
      }
    }
    .focus {
      transform: scale(1.1);
      border: 2px solid white;
      background-color: #03a9f4;
    }
  }
  .dialog {
    width: 100%;
    height: 100vh;
    background: rgba(0, 0, 0, 0.7);
    position: fixed;
    top: 0;
    left: 0;
    .ha-dialog {
      width: 300px;
      text-align: center;
      background: rgba(255, 255, 255, 0.8);
      margin: 0 auto;
      border-radius: 20px;
      position: absolute;
      left: 50%;
      top: 50%;
      transform: translate(-50%, -50%);
      padding: 50px;
      .el-switch {
        transform: scale(2.5);
      }
    }
  }
}
</style>

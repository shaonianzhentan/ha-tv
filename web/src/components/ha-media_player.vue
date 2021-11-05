<template>
  <div class="ha-media_player">
    <el-row :gutter="20">
      <el-col :span="8">
        <ha-icon
          name="mdi-skip-previous-outline"
          v-focusable
          @click="hass.media_previous_track(data)"
        />
      </el-col>
      <el-col :span="8">
        <ha-icon
          name="mdi-play-pause"
          v-focusable
          @click="hass.media_play_pause(data)"
        />
      </el-col>
      <el-col :span="8">
        <ha-icon
          name="mdi-skip-next-outline"
          v-focusable
          @click="hass.media_next_track(data)"
        />
      </el-col>
    </el-row>
    <h2>{{ data.media_title }}</h2>
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
  methods: {},
};
</script>
<style lang="less">
.ha-media_player {
  width: 320px !important;
}
</style>
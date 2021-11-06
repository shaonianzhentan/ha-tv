<template>
  <div class="ha-media_player">
    <h4 style="padding: 10px 0 10px 0">{{ data.friendly_name }}</h4>
    <el-row :gutter="20">
      <el-col :span="8">
        <ha-icon
          name="mdi-skip-previous-outline"
          v-focusable
          @on-blur.native="$emit('blur')"
          @click.native="hass.media_previous_track(data)"
        />
      </el-col>
      <el-col :span="8">
        <ha-icon
          name="mdi-play-pause"
          v-focusable
          @on-blur.native="$emit('blur')"
          @click.native="hass.media_play_pause(data)"
        />
      </el-col>
      <el-col :span="8">
        <ha-icon
          name="mdi-skip-next-outline"
          v-focusable
          @on-blur.native="$emit('blur')"
          @click.native="hass.media_next_track(data)"
        />
      </el-col>
    </el-row>
    <h3>{{ data.media_title }}</h3>
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
  width: 250px !important;
  i {
    font-size: 40px !important;
  }
  .focus {
    background-color: #03a9f4;
  }
}
</style>
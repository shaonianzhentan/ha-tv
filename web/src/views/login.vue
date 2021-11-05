<template>
  <div class="views-login">
    <el-form ref="form" :model="form" label-width="80px">
      <el-form-item label="电视IP">
        <el-input v-model="form.host" style="width: 200px"></el-input
        ><el-button type="primary" @click="setTVClick">设置</el-button>
      </el-form-item>
      <el-form-item label="凭据">
        ><el-button type="primary" @click="setTokenClick">设置凭据</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>
<script>
export default {
  data() {
    return {
      form: {
        host: "",
        user: "",
        password: "",
      },
    };
  },
  methods: {
    setTVClick() {
      const url = encodeURIComponent(`${location.origin}/ha-tv/ha.html`);
      fetch(`http://${this.form.host}?url=${url}`)
        .then((res) => res.json())
        .then(console.log);
    },
    post(body) {
      fetch(`http://${this.form.host}`, {
        method: "POST",
        body: JSON.stringify(body),
        headers: { "Content-Type": "application/json; charset=utf-8" },
      })
        .then((res) => res.json())
        .then(console.log);
    },
    setTokenClick() {
      this.post({
        js: `
            localStorage["hassTokens"] = ${JSON.stringify(
              localStorage["hassTokens"]
            )}

            location.href = 'index.html'
          `,
      });
    },
  },
};
</script>
<style lang="less" scoped>
.views-login {
  background: white;
  height: 80vh;
  padding-top: 20vh;
  .el-button {
    margin-left: 10px;
  }
}
</style>
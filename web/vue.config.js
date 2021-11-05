
module.exports = {
  outputDir: '../custom_components/ha_tv/local',
  chainWebpack: config => {
    config.plugin('html')
      .tap(args => {
        args[0].title = "家庭助理";
        return args;
      })
  },
  configureWebpack: {
    externals: {
      'vue': 'Vue',
      // 'element-ui': 'ELEMENT',
      // 'ant-design-vue':'antd',
      'moment': 'moment'
    }
  },
}
<template>
  <div>
    <div id="nav">
      <router-link to="/">是否可聚焦</router-link> |
      <router-link to="/Example1"
        >按键事件（left|up|right|down|enter）</router-link
      >
      | <router-link to="/Example2">自定义配置</router-link> |
      <router-link to="/Example3">滚动div</router-link> |
      <router-link to="/Example4">requestFocus/getElementByPath</router-link> |
      <router-link to="/Example5">混着使用</router-link> |
      <router-link to="/Example6">综合案例</router-link> |
      <router-link to="/Example8">tv画廊</router-link> |
      <router-link to="/Example9">弹出层滑动</router-link> |
      <router-link to="/Example10">表单</router-link> |
      <router-link to="/Example11">elementui表单</router-link> |
      <router-link to="/Example12">antd表单</router-link>
    </div>
    <div class="demo" style="margin-top: 50px; width: 600px">
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>
        <svg
          viewBox="64 64 896 896"
          data-icon="up"
          width="100px"
          height="100px"
          fill="currentColor"
          aria-hidden="true"
        >
          <path
            d="M890.5 755.3L537.9 269.2c-12.8-17.6-39-17.6-51.7 0L133.5 755.3A8 8 0 00140 768h75c5.1 0 9.9-2.5 12.9-6.6L512 369.8l284.1 391.6c3 4.1 7.8 6.6 12.9 6.6h75c6.5 0 10.3-7.4 6.5-12.7z"
          ></path>
        </svg>
      </div>
      <span class="focus-item" v-focusable> 可获取焦点的元素 </span>
      <svg
        v-focusable
        viewBox="64 64 896 896"
        data-icon="up"
        width="100px"
        height="100px"
        fill="currentColor"
        aria-hidden="true"
      >
        <path
          d="M890.5 755.3L537.9 269.2c-12.8-17.6-39-17.6-51.7 0L133.5 755.3A8 8 0 00140 768h75c5.1 0 9.9-2.5 12.9-6.6L512 369.8l284.1 391.6c3 4.1 7.8 6.6 12.9 6.6h75c6.5 0 10.3-7.4 6.5-12.7z"
        ></path>
      </svg>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item gray">no-focusable</div>
      <div class="focus-item gray">no-focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
      <div class="focus-item" v-focusable>focusable</div>
    </div>
  </div>
</template>

<style lang="less" scoped>
#nav {
  text-align: center;
  a {
    padding: 10px;
    margin: 10px 0;
    display: inline-block;
  }
  .router-link-exact-active {
    color: #ff6600;
  }
}
.focus-item {
  width: 100px;
  height: 100px;
  margin: 10px;
  font-size: 12px;
  display: inline-block;
  background-color: pink;
  box-sizing: border-box;
  vertical-align: top;
  &.gray {
    background: gray;
  }
}
.focus {
  transform: scale(1.1);
  border: 2px solid red;
  box-shadow: 0 0 20px red;
}
</style>

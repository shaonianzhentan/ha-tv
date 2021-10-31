<template>
  <div id="app">
    <div class="content-app">
      <keep-alive>
        <router-view />
      </keep-alive>
    </div>
  </div>
</template>

<style lang="less">
* {
  margin: 0;
  padding: 0;
  list-style: none;
}
#app {
  min-height: 100vh;
  width: 100%;
  background-image: url("../public/img/bg1.jpeg");
  background-size: cover;
}
</style>

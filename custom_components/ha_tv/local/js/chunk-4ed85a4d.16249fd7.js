(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-4ed85a4d"],{"33f7":function(t,a,e){"use strict";e.r(a);var n=function(){var t=this,a=t.$createElement,e=t._self._c||a;return e("div",{staticClass:"ha-header"},[e("h1",{staticClass:"today"},[e("span",[t._v(t._s(t.todayTime))]),e("br"),t._v(" "+t._s(t.todayDate)+" ")]),e("div",{staticClass:"weather"},[e("ha-icon",{staticStyle:{"font-size":"100px","margin-top":"-30px",position:"absolute"},attrs:{name:"mdi-weather-cloudy"}}),e("div",{staticStyle:{"margin-left":"140px","font-size":"30px"}},[t._v(" 温度："+t._s(t.data.temperature)+" ℃ "),e("br"),t._v(" 湿度："+t._s(t.data.humidity)+" % ")])],1)])},i=[],c=(e("99af"),{props:{data:{}},data:function(){return{todayTime:"",todayDate:""}},created:function(){var t=this,a=["日","一","二","三","四","五","六"];setInterval((function(){var e=new Date;t.todayTime="".concat(e.toLocaleTimeString()),t.todayDate="".concat(e.getMonth()+1," 月 ").concat(e.getDate()," 日，周").concat(a[e.getDay()])}),1e3)}}),o=c,s=(e("bf5b"),e("0c7c")),d=Object(s["a"])(o,n,i,!1,null,"565a5cba",null);a["default"]=d.exports},bf5b:function(t,a,e){"use strict";e("dd40")},dd40:function(t,a,e){}}]);
//# sourceMappingURL=chunk-4ed85a4d.16249fd7.js.map
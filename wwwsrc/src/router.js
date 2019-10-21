import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: function () {
        // @ts-ignore
        return import(/* webpackChunkName: "edit" */ './views/Dashboard.vue')
      }
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }

  ]
})

import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Profile from './views/Profile.vue'
// @ts-ignore
import VaultKeep from './views/VaultKeep.vue'
// @ts-ignore
import Keep from './views/Keep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/profile',
      name: 'profile',
      component: Profile
    },
    {
      path: '/vault',
      name: 'vaultKeep',
      component: VaultKeep
    },
    {
      path: '/keep',
      name: 'keep',
      component: Keep
    }
  ]
})

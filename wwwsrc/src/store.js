import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    profile: {},
    vaultKeep: [],
    activeKeep: {},
    ActiveVaultId: 0
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      // debugger
      state.keeps = keeps
      console.log("keeps: ", state.keeps)
    },
    setVaults(state, vaults) {
      // debugger
      state.vaults = vaults
      console.log("vaults: ", state.vaults)
    },
    setVaultKeep(state, vaultKeep) {
      // debugger
      state.vaultKeep = vaultKeep
      console.log("vaultKeep: ", state.vaultKeep)
    },
    setActiveKeep(state, keep) {
      // debugger
      state.activeKeep = keep
      console.log("activeKeep: ", state.activeKeep)
    },
    setActiveVault(state, vaultId) {
      state.ActiveVaultId = vaultId
      console.log("Active vault: ", state.ActiveVaultId)
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch("getKeeps")
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      // debugger
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch("getKeeps")
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch("getKeeps")
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('Logout')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'login' })
          dispatch("getKeeps")
        })
        .catch(e => {
          console.log('Logout Failed')
        })
    },
    //getting public keeps
    getKeeps({ commit, dispatch }) {
      // debugger
      api.get("Keep")
        .then(res => {
          commit("setKeeps", res.data)
        })
        .catch(e => {
          console.log("couldn't get keeps")
        })
    },
    //get all vaults by userid
    getVaults({ commit, dispatch }, uid) {
      // debugger
      api.get("Vault/user/" + uid)
        .then(res => {
          commit("setVaults", res.data)
        })
        .catch(e => {
          // debugger
          console.log("couldn't get vaults")
        })
    },
    //get vaultkeep by vault id and userid
    getVaultKeep({ commit, dispatch }, payload) {
      // debugger
      api.get("VaultKeep/" + payload.vaultId)
        .then(res => {
          commit("setVaultKeep", res.data)
          commit("setActiveVault", payload.vaultId)
          router.push("/vault")
        })
        .catch(e => {
          // debugger
          console.log("couldn't get vaultKeep")
        })
    },
    //get vaultkeep by vault id and userid (same as above one but without router push)
    getVaultKeep2({ commit, dispatch }, vaultId) {
      // debugger
      api.get("VaultKeep/" + vaultId)
        .then(res => {
          commit("setVaultKeep", res.data)
        })
        .catch(e => {
          // debugger
          console.log("couldn't get vaultKeep")
        })
    },
    //get keep by keep id
    activeKeep({ commit, dispatch }, keepId) {
      // debugger
      api.get("Keep/" + keepId)
        .then(res => {
          commit("setActiveKeep", res.data)
          router.push("/keep")
        })
        .catch(e => {
          // debugger
          console.log("couldn't get Keep")
        })
    },
    //save a keep to a vault (post in vaultKeep)
    saveKeep({ commit, dispatch }, payload) {
      // debugger
      api.post("VaultKeep", payload)
        .then(res => {
          // debugger
          dispatch("getVaultKeep2", payload.vaultId)
        })
        .catch(e => {
          // debugger
          console.log("couldn't save Keep")
        })
    },

    //delete a keep from vault, pass it vault id in url and requires a vault id and keep id in payload
    deleteKeepFromVault({ commit, dispatch }, payload) {
      // debugger
      api.delete("VaultKeep/", { data: payload })
        .then(res => {
          dispatch("getVaultKeep2", payload.vaultId)
        })
        .catch(e => {
          // debugger
          console.log("couldn't delete Keep")
        })
    },
  }
})
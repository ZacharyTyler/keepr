import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    vaultKeeps: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, payload) {
      state.keeps = payload
    },
    setVaults(state, payload) {
      state.vaults = payload
    },
    setVaultKeeps(state, payload) {
      state.vaultKeeps = payload
    }
  },
  actions: {
    //SECTION Login

    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //!SECTION 

    //SECTION Keeps
    async getKeeps({ commit }) {
      try {
        let keeps = await api.get("/keeps/")
        commit('setKeeps', keeps.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async plusOne({ commit, dispatch }, payload) {
      try {
        let keeps = await api.put("/keeps/" + payload.id, payload)
        dispatch("getKeeps")
      } catch (e) {
        console.warn(e.message)
      }

    },

    //!SECTION 

    //SECTION Vaults
    async getVaultsByUser({ commit }) {
      try {
        let vaults = await api.get("/vaults/")
        commit("setVaults", vaults.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async getKeepsByVaultId({ commit }, payload) {
      try {

        let keeps = await api.get("/vaultkeeps/" + payload)
        commit("setVaultKeeps", keeps.data)
      } catch (e) {
        console.warn(e.message)
      }

    }
    //!SECTION 

  }
})

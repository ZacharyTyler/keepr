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
    keep: {},
    keeps: [],
    vault: [],
    vaults: [],
    vaultKeeps: [],
    userKeeps: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeep(state, payload) {
      state.keep = payload
    },
    setKeeps(state, payload) {
      state.keeps = payload
    },
    setUserKeeps(state, payload) {
      state.userKeeps = payload
    },
    setVault(state, payload) {
      state.vault = payload
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


    async getKeepById({ commit }, keepId) {
      try {
        let keep = await api.get("/keeps/" + keepId)
        commit('setKeep', keep.data)
      } catch (e) {
        console.warn(e.message)
      }
    },


    async createNewKeep({ commit, dispatch }, payload) {
      try {
        let keeps = await api.post("/keeps/", payload)
        dispatch("getUserKeeps")
      } catch (e) {
        console.warn(e.message)
      }
    },

    async getUserKeeps({ commit }) {
      try {
        let keeps = await api.get("/keeps/user/")
        commit('setUserKeeps', keeps.data)
      } catch (e) {
        console.warn(e.message)
      }
    },

    async deleteKeep({ commit, dispatch }, keepId) {
      try {

        let keeps = await api.delete("/keeps/" + keepId)
        dispatch("getUserKeeps")
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

    async getVault({ commit }, vaultId) {
      try {
        let vault = await api.get("/vaults/" + vaultId)
        commit("setVault", vault.data)
      } catch (e) {
        console.warn(e.message)
      }
    },

    async deleteVault({ commit, dispatch }, vaultId) {
      try {

        let vaults = await api.delete("/vaults/" + vaultId)
        dispatch("getVaultsByUser")
      } catch (e) {
        console.warn(e.message)
      }
    },

    async createNewVault({ commit, dispatch }, payload) {
      try {

        let vaults = await api.post("/vaults/", payload)
        dispatch("getVaultsByUser")
      } catch (e) {
        console.warn(e.message)
      }
    },
    //!SECTION 
    async getKeepsByVaultId({ commit }, payload) {
      try {

        let keeps = await api.get("/vaultkeeps/" + payload)
        commit("setVaultKeeps", keeps.data)
      } catch (e) {
        console.warn(e.message)
      }

    },

    async deleteVaultKeepById({ dispatch }, payload) {
      try {

        await api.put("/vaultkeeps/", payload)
        dispatch("getKeepsByVaultId", payload.vaultId)
      } catch (e) {
        console.warn(e.message)
      }
    },

    async addKeep({ commit, dispatch }, payload) {
      try {
        let keeps = await api.post("/vaultKeeps/", payload)

      } catch (e) {
        console.warn(e.message)
      }
    },
  }
})

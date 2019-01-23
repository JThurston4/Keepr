<template>
  <div id="app">
    <nav class="navbar navbar-dark bg-primary container-fluid">
      <div class="row w-100">
        <div class="col-3 logo"><a class="navbar-brand" href="#"><i class="fas fa-lock navIcon"> Keepr</i></a>
        </div>
        <div class="col-9 menuItems">
          <div class="row" v-if="getUser.id">
            <!-- <div v-if="getUser"> -->
            <div class="col">
              <router-link class="home-font" :to="{name: 'home'}">Home</router-link>
            </div>
            <div class="col">
              <router-link class="home-font" to="/profile">Profile</router-link>
            </div>
            <div class="col">
              <router-link class="home-font" to="/about">About</router-link>
            </div>
            <div class="col">
              <router-link @click.native='logout()' class="home-font" to="/login">Logout</router-link>
            </div>
          </div>
          <!-- </div> -->
        </div>
      </div>
    </nav>
    <router-view />
  </div>
</template>

<script>
  export default {
    name: 'app',
    data() {
      return {

      }
    },
    computed: {
      getUser() {
        return this.$store.state.user
      }
    },
    methods: {
      logout() {
        // debugger
        this.$store.dispatch('logout')
      }
    },
    components: {},
    props: [],
  }
</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  .home-font {
    color: white;
  }

  .menuItems {
    display: flex;
    justify-content: flex-end;
    align-items: center;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .logo {
    display: flex;
    justify-content: flex-start;
  }

  .navIcon {
    font-size: 25px;
  }

  .navbar {
    position: fixed;
    top: 0px;
    z-index: 200;
  }
</style>
<template>
  <div id="app">
    <nav class="navbar navbar-dark bg-primary container-fluid">
      <div class="row w-100">
        <div class="col-3 logo"><a class="navbar-brand" href="#"><i class="fas fa-lock navIcon"> Keepr</i></a>
        </div>
        <div class="col-9 menuItems">
          <div class="row centered" v-if="getUser.id">
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
            <div>
              <button type="button" class="btn btn-info" data-toggle="modal" data-target="#addkeep">Add Keep</button>
            </div>
            <!-- modal start -->

            <!-- modal end -->
          </div>
          <!-- </div> -->
        </div>
      </div>
    </nav>
    <div class="modal" id="addkeep" tabindex="-1">
      <div class="modal-dialog" role="dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Create a keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createKeep()">
              <div><input type="text" placeholder="Name" v-model="postKeep.name"></div>
              <div><input type="text" placeholder="Description" v-model="postKeep.description"></div>
              <div><input type="text" placeholder="Image Url" v-model="postKeep.img"></div>
              <div><input type="checkbox" v-model="postKeep.secret">Private</div>
              <button type="submit" class="btn btn-primary">Create Keep</button>
            </form>
          </div>
        </div>
      </div>
    </div>
    <router-view />
  </div>
</template>

<script>
  export default {
    name: 'app',
    data() {
      return {
        postKeep: {
          name: "",
          description: "",
          img: "",
          secret: 0
        }
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
      },
      createKeep() {
        debugger
        this.$store.dispatch("createKeep", this.postKeep)
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
    overflow-x: hidden;
    overflow-y: hidden;
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
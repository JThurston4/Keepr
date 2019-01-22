<template>
  <nav class="navbar navbar-dark bg-primary container-fluid">
    <div class="row menuBar">
      <div class="col-3"><a class="navbar-brand" href="#"><i class="fas fa-lock"> Keepr</i></a>
      </div>
      <div class="col-9 menu1">
        <div class="row">
          <div class="col">
            <router-link class="home-font" data-toggle="collapse" data-target="#navbarToggleExternalContent" to="/home">Home</router-link>
          </div>
          <div class="col">
            <router-link class="home-font" data-toggle="collapse" data-target="#navbarToggleExternalContent" to="/profile">Profile</router-link>
          </div>
          <div class="col">
            <router-link class="home-font" data-toggle="collapse" data-target="#navbarToggleExternalContent" to="/about">About</router-link>
          </div>
          <div class="col">
            <router-link @click.native='logout()' class="home-font" data-toggle="collapse" data-target="#navbarToggleExternalContent"
              to="/login">Logout</router-link>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  .home-font {
    color: ivory;
    font-size: 20px;
  }

  .navbar-brand {
    font-size: 35px;
  }

  .menu1 {
    display: flex;
    justify-content: flex-end;
    align-items: center;
  }

  .menuBar {
    width: 100vw;
  }

  .menu {
    display: flex;
    justify-content: flex-end;
    align-items: center;
  }

  .home-font:hover {
    color: #b69bde;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>
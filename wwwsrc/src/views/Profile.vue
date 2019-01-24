<template>
  <div class="profile container-fluid bg2">
    <div class="row profileDisplay">
      <!-- jumbo start -->
      <div class="col-6 centered1" @click="activeView='vaults'">
        <h1>Your Vaults</h1>
      </div>
      <div class="col-6 centered2" @click="activeView = 'keeps'">
        <h1>Your Keeps</h1>
      </div>
      <!-- jumbo end -->
    </div>
    <div>
      <VaultsComponent v-if="activeView == 'vaults'"></VaultsComponent>
      <KeepsComponent v-if="activeView == 'keeps'"></KeepsComponent>
    </div>
  </div>
</template>

<script>
  import VaultsComponent from '@/components/VaultsComponent'
  import KeepsComponent from '@/components/KeepsComponent'
  export default {
    name: 'profile',
    data() {
      return {
        vaultKeep: {
          vaultId: 0,
        },
        activeView: ''
      }
    },
    computed: {
      getVaults() {
        return this.$store.state.vaults
      },
      getUser() {
        return this.$store.state.user
      }
    },
    methods: {
      getVaultKeep(vaultId) {
        // debugger
        this.$store.dispatch("getVaultKeep", { vaultId: vaultId })
      }
    },
    components: {
      VaultsComponent,
      KeepsComponent
    },
    props: [],
    mounted() {
      // debugger
      this.$store.dispatch("getKeepsByUser")
      this.$store.dispatch("getVaults")
    }
  }

</script>

<style>
  .vaultImg {
    max-width: 16rem;
    max-height: 15rem;
  }

  .vaultCards {
    margin-left: 10px;
    margin-right: 10px;
    /* display:flex; */
    /* justify-content:space-around; */
  }

  .profileDisplay {
    width: 100vw;
    background-color: #2c2c2c;
    color: #858c93;
    height: 15vh;
  }

  .bg2 {
    background-image: linear-gradient(to bottom left, #42b983, rgb(153, 168, 253));
    padding-top: 75px;
    min-height: 100vh;
  }

  .jumbotron {
    background-color: #2c2c2c;
  }

  .centered1 {
    display: flex;
    justify-content: center;
    align-items: center;
    border-right: 1px rgb(0, 0, 0) solid;
  }

  .centered2 {
    display: flex;
    justify-content: center;
    align-items: center;
    border-left: 1px rgb(0, 0, 0) solid;
  }
</style>
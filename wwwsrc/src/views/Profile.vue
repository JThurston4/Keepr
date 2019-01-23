<template>
  <div class="profile container-fluid">
    <div class="row">
      <div class="card border-primary mb-3 col-xl-3 col-lg-4 col-md-6 col-sm-12 vaultCards" v-for="vault in getVaults"
        style="max-width: 20rem;">
        <div class="card-body">
          <img @click="getVaultKeep(vault.id)" class="vaultImg" :src="vault.img">
          <h4 @click="getVaultKeep(vault.id)" class="card-title">{{vault.name}}</h4>
          <p class="card-text">{{vault.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'profile',
    data() {
      return {
        vaultKeep: {
          vaultId: 0,
          userId: this.getUser.id
        }
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
        this.$store.dispatch("getVaultKeep", { vaultId: vaultId, userId: this.getUser.id })
      }
    },
    components: {},
    props: [],
    mounted() {
      // debugger
      this.$store.dispatch("getVaults", this.getUser.id)
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
</style>
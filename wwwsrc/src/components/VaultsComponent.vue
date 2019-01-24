<template>
  <div class="VaultsComponent col-xl-3 col-lg-4 col-md-6 col-sm-12 componentsStyling">
    <div class="card h-100 m-3 border-primary">
      <div class="card-body">
        <img @click="getVaultKeep(vault.id)" class="vaultImg" :src="vault.img">
        <h4 @click="getVaultKeep(vault.id)" class="card-title">{{vault.name}}</h4>
        <p class="card-text cardFont">{{vault.description}}</p>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'VaultsComponent',
    data() {
      return {

      }
    },
    props: ["vault"],
    computed: {
      getVaults() {
        return this.$store.state.vaults
      },
    },
    methods: {
      getVaultKeep(vaultId) {
        // debugger
        this.$store.dispatch("getVaultKeep", { vaultId: vaultId })
      }
    },
    components: {},
  }

</script>

<style>
  .cardFont {
    font: 14px;
  }

  .addWidth {
    width: 100vw;
  }
</style>
<template>
  <div class="VaultsComponent">
    <div class="row addWidth">
      <div class="card border-primary mb-3 col-xl-3 col-lg-4 col-md-6 col-sm-12 vaultCards" v-for="vault in getVaults"
        style="max-width: 20rem;">
        <div class="card-body">
          <img @click="getVaultKeep(vault.id)" class="vaultImg" :src="vault.img">
          <h4 @click="getVaultKeep(vault.id)" class="card-title">{{vault.name}}</h4>
          <p class="card-text cardFont">{{vault.description}}</p>
        </div>
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
    computed: {
      getVaults() {
        return this.$store.state.vaults
      },
    },
    methods: {},
    components: {},
    props: [],
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
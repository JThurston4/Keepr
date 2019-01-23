<template>
  <div class="vaultKeep container-fluid bg">
    <div class="card-columns">
      <div v-for="keep in getVaultKeep">
        <div class="card keepCard">
          <deleteButton type="button" class="btn btn-primary deleteButton" @click="removeKeep(keep.id)">Remove from
            Vault</deleteButton>
          <img class="card-img-top" :src="keep.img" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaultKeep',
    data() {
      return {

      }
    },
    computed: {
      getVaultKeep() {
        return this.$store.state.vaultKeep || {}
      },
      getActiveVaultId() {
        return this.$store.state.ActiveVaultId
      }
    },
    methods: {
      removeKeep(keepId) {
        this.$store.dispatch("deleteKeepFromVault", { vaultId: this.getActiveVaultId, keepId: keepId })
      }
    },
    components: {},
    props: [],
  }

</script>

<style>
  .deleteButton {
    display: none;

  }

  .keepCard:hover deleteButton {
    display: block;

  }
</style>
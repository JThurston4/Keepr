<template>
  <div class="vaultKeep container-fluid">
    <div class="card-columns">
      <div v-for="keep in getVaultKeep">
        <div class="card">
          <img class="card-img-top" :src="keep.img" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
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
      }
    },
    methods: {},
    components: {},
    props: [],
  }

</script>

<style>


</style>
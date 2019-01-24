<template>
  <div class="KeepsComponent">
    <div class="row">
      <div class="card border-primary mb-3 col-xl-3 col-lg-4 col-md-6 col-sm-12 vaultCards" v-for="keep in getkeeps"
        style="max-width: 20rem;">
        <div class="card-body">
          {{keep}}
          <img @click="" class="keepImg" :src="keep.img">
          <h4 @click="" class="card-title">{{keep.name}}</h4>
          <p class="card-text">{{keep.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'KeepsComponent',
    data() {
      return {

      }
    },
    computed: {
      getKeeps() {
        console.log(this.$store.state.userKeeps)
        return this.$store.state.userKeeps
      }
    },
    methods: {},
    components: {},
    props: [],
  }

</script>

<style>


</style>
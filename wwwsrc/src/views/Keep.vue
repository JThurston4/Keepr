<template>
  <div class="keep bg">
    <div class="card border-primary mb-3" style="max-width: 80vw;">
      <div class="card-body">
        <img :src="activeKeep.img" class="activeImg">
        <h4 class="card-title">{{activeKeep.name}}</h4>
        <p class="card-text">{{activeKeep.description}}</p>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'keep',
    data() {
      return {

      }
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      }
    },
    methods: {},
    components: {},
    props: [],
    mounted() {
      //method to see if state is empty on active keep?
    }
  }

</script>

<style>
  .activeImg {
    max-width: 75vw;
  }
</style>
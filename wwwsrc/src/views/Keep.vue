<template>
  <div class="keep">
    hihi
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


</style>
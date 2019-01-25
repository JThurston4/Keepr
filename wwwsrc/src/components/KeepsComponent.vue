<template>
  <div class="KeepsComponent col-xl-3 col-lg-4 col-md-6 col-12 componentsStyling">
    <div class="card h-100 m-3 border-primary">
      <div class="card-body">
        <img @click="" class="vaultImg" :src="keep.img">
        <h4 @click="" class="card-title">{{keep.name}}</h4>
        <p class="card-text">{{keep.description}}</p>
        <i class="far fa-eye"></i> {{'\xa0'}} {{'\xa0'}} <i class="fas fa-trash-alt" @click="deleteKeep(keep.id)"></i>
        {{'\xa0'}} {{'\xa0'}} <i class="fas fa-user-secret" v-if="keep.secret==true"></i>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'KeepsComponent',
    props: ["keep"],
    data() {
      return {

      }
    },
    computed: {

    },
    methods: {
      deleteKeep(keepId) {
        this.$store.dispatch("deleteKeep", keepId)
      }
    },
    components: {},
  }

</script>

<style>
  .horiCenter {
    display: flex;
    justify-content: center;
  }

  .componentsStyling {
    margin-top: 1rem;
    margin-bottom: 2rem;
  }
</style>
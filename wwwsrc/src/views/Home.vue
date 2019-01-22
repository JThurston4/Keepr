<template>
  <div class="home container-fluid">
    <div class="row d-flex flex-wrap">
      <div v-for="keep in gotKeeps" class="allKeeps card border-primary mb-3 col-xl-3 col-lg-4 col-md-6 col-sm-12"
        style="max-width: 20rem;">
        <div class="card-body">
          <img class="keepImg" :src="keep.img">
          <h4 class="card-title">{{keep.name}}</h4>
          <p class="card-text">{{keep.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      // this.$store.dispatch("getKeeps");
    },
    data() {
      return {

      }
    },
    computed: {
      gotKeeps() {
        return this.$store.state.keeps || {}
      }
    },
    methods: {},
    components: {},
    props: [],
  };

</script>


<style>
  .keepImg {
    max-width: 16rem;
    max-height: 30vh
  }


  .allKeeps {
    display: flex;
    margin-right: 1.5rem;
    margin-left: 1.5rem;
  }
</style>
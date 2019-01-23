<template>
  <div class="home container-fluid">
    <div class="card-columns">
      <div v-for="keep in gotKeeps">
        <div class="card">
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

  .card {
    display: inline-block;
  }

  @media (min-width: 34em) {
    .card-columns {
      -webkit-column-count: 2;
      -moz-column-count: 2;
      column-count: 2;
    }
  }

  @media (min-width: 48em) {
    .card-columns {
      -webkit-column-count: 3;
      -moz-column-count: 3;
      column-count: 3;
    }
  }

  @media (min-width: 62em) {
    .card-columns {
      -webkit-column-count: 4;
      -moz-column-count: 4;
      column-count: 4;
    }
  }

  @media (min-width: 75em) {
    .card-columns {
      -webkit-column-count: 5;
      -moz-column-count: 5;
      column-count: 5;
    }
  }

  .allKeeps {
    display: flex;
    margin-right: 1.5rem;
    margin-left: 1.5rem;
  }
</style>
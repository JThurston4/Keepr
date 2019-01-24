<template>
  <div class="home container-fluid bg">
    <div class="card-columns">
      <div v-for="keep in gotKeeps">
        <div class="card keepCard">
          <saveButton data-toggle="modal" :data-target="'#'+keep.id" type="button" class="btn btn-primary saveButton">Save</saveButton>
          <!-- modal start -->
          <div class="modal" :id="keep.id" tabindex="-1">
            <div class="modal-dialog" role="dialog">
              <div class="modal-content">
                <div class="modal-header">
                  <h5 class="modal-title">Save to Vault</h5>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="modal-body">
                  <div v-for="vault in gotVaults"><button type="button" data-dismiss="modal" class="btn btn-outline-secondary"
                      @click="saveKeep(keep.id, vault.id)">{{vault.name}}</button></div>
                </div>
              </div>
            </div>
          </div>
          <!-- modal end -->
          <img class="card-img-top" @click="activeKeep(keep.id)" :src="keep.img" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title" @click="activeKeep(keep.id)">{{keep.name}}</h5>
            <i class="far fa-eye"></i> {{keep.views}} {{'\xa0'}}{{'\xa0'}} <i class="fas fa-lock"></i> {{keep.saves}}
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
      },
      gotVaults() {
        return this.$store.state.vaults || {}
      }
    },
    methods: {
      activeKeep(keepId) {
        this.$store.dispatch("activeKeep", keepId)
      },
      saveKeep(keepId, vaultId) {
        // debugger
        this.$store.dispatch("saveKeep", { keepId: keepId, vaultId: vaultId })
      }
    },
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

  .bg {
    background-image: linear-gradient(to bottom left, #42b983, rgb(153, 168, 253));
    padding-top: 90px;
    min-height: 100vh;
  }

  .saveButton {
    display: none;
    z-index: 100;
  }

  .keepCard:hover saveButton {
    display: block;

  }
</style>
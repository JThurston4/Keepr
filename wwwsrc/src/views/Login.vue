<template>
    <div class="login bg">
        <form v-if="loginForm" @submit.prevent="loginUser">
            <div><input type="email" v-model="creds.email" placeholder="email"></div>
            <div><input type="password" v-model="creds.password" placeholder="password"></div>
            <div><button type="submit">Login</button></div>
        </form>
        <form v-else @submit.prevent="register">
            <div><input type="text" v-model="newUser.username" placeholder="name"></div>
            <div><input type="email" v-model="newUser.email" placeholder="email"></div>
            <div><input type="password" v-model="newUser.password" placeholder="password"></div>
            <div><button type="submit">Create Account</button></div>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
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
                        <i class="far fa-eye"></i> {{keep.views}} {{'\xa0'}}{{'\xa0'}} <i class="fas fa-lock"></i>
                        {{keep.saves}}
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        },
        computed: {
            gotKeeps() {
                return this.$store.state.keeps || {}
            }
        },
        mounted() {
            this.$store.dispatch("getKeeps")
        }
    };
</script>
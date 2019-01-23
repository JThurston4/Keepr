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
        }
    };
</script>
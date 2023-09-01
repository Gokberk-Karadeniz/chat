<script setup>
</script>

<template>
    <main>
        <div class="container">

<form action="" >
    <div class="title">Login Menu</div>

    <div class="input-box button">
        <input type="submit" value="Add Room - Delete Room - Login Room" @click="go_to_rooms">
    </div>
    <div class="input-box button">
        <input type="submit" value="Update User Profile" @click="go_to_update_profile">
    </div>
    <div class="input-box button">
        <input type="submit" value="Update User Password" @click="go_to_update_password">
    </div>
    <div class="input-box button">
        <input type="submit" value="Delete My Account" @click="go_to_delete">
    </div>
    <div class="input-box button">
        <input type="submit" value="Log out" @click="exit">
    </div>
</form>

</div>
    </main>
  </template>

<script>
import UserAPI from '../api/user'
export default {
    data() {
        return {

        };
    },
    methods: {
        async go_to_rooms(e) {
            e.preventDefault()
            this.$router.push('/rooms')
        },
        async go_to_delete(e) {
            e.preventDefault()
            this.$router.push('/deleteuser')
        },
        async exit(e) {
            e.preventDefault()
            this.$router.push('/login')
        },
        async go_to_update_password(e) {
            e.preventDefault()
            this.$router.push('/updateuserpassword')
        },
        async go_to_update_profile(e) {
            e.preventDefault()
            this.$router.push('/updateuserprofile')
        }
    }
}
</script>
<style>
*{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: sans-serif;
}

body{
    display:grid;
    height: 100vh;
    place-items: center;
    background: linear-gradient(to right,#dfabc5 0%,#1da1f2 100%);
}

.container{
    background:  #fff;
    max-width: 400px;
    width: 100%;
    padding: 25px 30px;
    border-radius: 5px;
    position: relative;
}
.container form .title{
    font-size: 20px;
    font-weight: bold;
    margin: 10px 0 10px 0;
    position: relative;
}
.container form .input-box{
    width: 100%;
    height: 55px;
    margin-top: 25px;
    position: relative;
}
.container form .input-box input{
    height: 100%;
    width: 100%;
    outline: none;
    font-size: 16px;
    border: none;
}
.container form .input-box input[type="submit"]{
    font-size: 17px;
    color: #fff;
    border-radius: 5px;
    cursor: pointer;
    background: red;
    transition: all 0.3s ease;
}

.container form .input-box input[type="submit"]:hover{
    letter-spacing: 1px;
    background: rgba(0,0,0,0.15);
    color: red;
    font-weight: bold;
    border-radius: 10px;
}
</style>
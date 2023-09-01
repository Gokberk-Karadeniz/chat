<script setup>
</script>

<template>
  <main>
    <div class="container">

        <form action="" >
        <div class="title">Sign Up Page</div>
        <div class="input-box">
            <input v-model="nameInput" id="Name" type="text" placeholder="Enter your name.." required>
            <div class="underline"></div>

        </div>
        <div class="input-box">
            <input v-model="lastnameInput" id="Surname" type="text" placeholder="Enter your last name.." required>
            <div class="underline"></div>

        </div>
        <div class="input-box">
            <input v-model="usernameInput" id="Username" type="text" placeholder="Enter your username.." required>
            <div class="underline"></div>

        </div>
        <div class="input-box">
            <input v-model="passwordInput" id="Password" type="password" placeholder="Enter your password.." required>
            <div class="underline"></div>

        </div>
        <div class="input-box button">
            <input type="submit" value="Register" @click="register">
        </div>
        Already have an account? <a href="http://localhost:5173/login">Login</a>
    </form>
    </div>
  </main>
</template>

<script>
import UserAPI from '../api/user'
export default {
    data() {
        return {
            nameInput:"",
            lastnameInput:"",
            usernameInput: "",
            passwordInput: "",
        };
    },
    methods: {
        async register(e) {
            e.preventDefault()
            try {
                const response = await UserAPI.register(this.nameInput,this.lastnameInput,this.usernameInput, this.passwordInput)
                if (response.status == 200) {
                    alert('Registration Successful')
                    window.location.href = "http://localhost:5173/login"
                } else {
                    const responseText = await response.text();
                    alert(responseText)
                }
            } catch (error) {
                console.error(error)
            }
        }
    }
}
</script>
<style scoped>
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
 .container a{
    font-size: large;
    margin-left: 100px;
 }
 .container form .title{
    font-size: 40px;
    font-weight: bold;
    margin: 10px 0 10px 0;
    position: relative;
}
.container form .input-box{
    width: 100%;
    height: 45px;
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

.container form .underline::before{
    position: absolute;
    content: "";
    height: 2px;
    width: 100%;
    background: #ccc;
    left: 0;
    bottom: 0;
}
.container form .underline::after{

    position: absolute;
    content: "";
    height: 2px;
    width: 100%;
    left: 0;
    bottom: 0;
    background: red;
    transform: scaleX(0);
    transform-origin:left ;
    transition: all 0.3s ease;
}

.container form .input-box input:focus ~ .underline::after,
.container form .input-box input:valid~ .underline::after{
    transform: scaleX(1);
    transform-origin: left;
}

.container form .button{
    margin: 40px 0 20px 0;
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

<script setup>
</script>

<template>
    <main>
        <div class="container">

            <form action="">
                <div class="title">Room Operations</div>
                <div class="input-box">
                    <input v-model="roomnameInput" id="roomname" type="text" placeholder="Enter your roomname.." required>
                    <div class="underline"></div>
                </div>
                <div class="input-box">
                    <input v-model="roompasswordInput" id="roompassword" type="password" placeholder="Enter your roompassword.." required>
                    <div class="underline"></div>
                </div>
                <div class="input-box button">
                    <input type="submit" value="Add Room" @click="addroom">
                </div>
                <div class="input-box button">
                    <input type="submit" value="Delete Room">
                </div>
                <div class="input-box button">
                    <input type="submit" value="Join Room" @click="join">
                </div>
                <ul id="rooms" class="list-box" v-for="room in rooms">
                    <li room-id="id">
                        {{ room.name }}
                    </li>
                </ul>
            </form>

        </div>
    </main>
</template>

<script>
import RoomAPI from '../api/room'
export default {
    data() {
        return {
            roomnameInput:"",
            roompasswordInput: "",
            rooms: []
        };
    },
    mounted() {
        this.getRooms()
    },
    methods: {
        async getRooms() {
            try {
                const response = await RoomAPI.getRooms();
                if(response.status === 200) {
                    const rooms = await response.json()
                    this.rooms = rooms
                }
            } catch (error) {
                console.error(error)
            }
        },
        async addroom(e) {
            e.preventDefault()
            try {
                const response = await RoomAPI.addroom(this.roomnameInput,this.roompasswordInput)
                if (response.status == 200) {
                    
                    this.getRooms()
                    
                } else {
                    const responseText = await response.text();
                    alert(responseText)
                }
            } catch (error) {
                console.error(error)
            }
        },
        async join(e) {
            e.preventDefault()
            try {
                const response = await RoomAPI.join(this.roomnameInput, this.roompasswordInput)
                if (response.status == 200) {
                    this.getRooms()
                    alert('Join successful')
                    this.$router.push('/joinrooms')
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

<style>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: sans-serif;
}

body {
    display: grid;
    height: 00vh;
    place-items: center;
    background: linear-gradient(to right, #dfabc5 0%, #1da1f2 100%);
}

.container a {
    font-size: large;
    margin-left: 140px;
}

.container {
    background: #fff;
    max-width: 500px;
    width: 100%;
    padding: 25px 30px;
    border-radius: 5px;
    position: relative;
}
.container form{
    height: 600px;
}

.container .logo img {
    position: absolute;
    width: 150px;
    height: 90px;
    left: 60%;
    top: 2px;
    border-radius: 50%;
}

.container form .title {
    font-size: 20px;
    font-weight: bold;
    margin: 10px 0 10px 0;
    position: relative;
}

.container form .input-box {
    width: 100%;
    height: 45px;
    margin-top: 25px;
    position: relative;
}

.container form .input-box input {
    height: 100%;
    width: 100%;
    outline: none;
    font-size: 16px;
    border: none;
}

.container form .underline::before {
    position: absolute;
    content: "";
    height: 2px;
    width: 100%;
    background: #ccc;
    left: 0;
    bottom: 0;
}

.container form .underline::after {

    position: absolute;
    content: "";
    height: 2px;
    width: 100%;
    left: 0;
    bottom: 0;
    background: red;
    transform: scaleX(0);
    transform-origin: left;
    transition: all 0.3s ease;
}

.container form .input-box input:focus~.underline::after,
.container form .input-box input:valid~.underline::after {
    transform: scaleX(1);
    transform-origin: left;
}

.container form .button {
    margin: 10px 0 10px 0;
}

.container form .input-box input[type="submit"] {
    font-size: 17px;
    color: #fff;
    border-radius: 5px;
    cursor: pointer;
    background: red;
    transition: all 0.3s ease;
}

.container form .input-box input[type="submit"]:hover {
    letter-spacing: 1px;
    background: rgba(0, 0, 0, 0.15);
    color: red;
    font-weight: bold;
    border-radius: 10px;
}
</style>
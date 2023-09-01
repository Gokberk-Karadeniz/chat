export default {
    addroom: async (roomname,roompassword) =>
    await fetch ('https://localhost:7275/room/addroom',{
        method: 'POST',
        headers: { 'Content-Type': 'application/json' , Authorization: 'Bearer ' + window.localStorage.getItem('token') },
        body: JSON.stringify({roomname,roompassword})
    }),
    getRooms: async () =>
    await fetch ('https://localhost:7275/room/room',{
        method: 'GET',
        headers: { 'Content-Type': 'application/json' , Authorization: 'Bearer ' + window.localStorage.getItem('token') },
    }),
    join: async (roomname,roompassword) =>
    await fetch ('https://localhost:7275/room/join',{
        method: 'POST',
        headers: { 'Content-Type': 'application/json' , Authorization: 'Bearer ' + window.localStorage.getItem('token') },
        body: JSON.stringify({roomname,roompassword})
    }),
    delete: async () =>
    await fetch('https://localhost:7275/room/'+roomId, {
      method: 'DELETE',
      headers: { Authorization: 'Bearer ' + window.localStorage.getItem('token') }
    }),
    validateRoomPassword: async (password) => await fetch('https://localhost:7275/user', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' , Authorization: 'Bearer ' + window.localStorage.getItem('token') },
        body: JSON.stringify({password})
      }),
}

export default {
  login: async (username, password) =>
    await fetch('https://localhost:7275/user/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ username, password })
    }),
  register: async (name, lastname, username, password) =>
    await fetch('https://localhost:7275/user/register', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ name, lastname, username, password })
    }),
  validatePassword: async (password) => await fetch('https://localhost:7275/user', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' , Authorization: 'Bearer ' + window.localStorage.getItem('token') },
    body: JSON.stringify({password})
  }),
  delete: async () =>
    await fetch('https://localhost:7275/user', {
      method: 'DELETE',
      headers: { Authorization: 'Bearer ' + window.localStorage.getItem('token') }
    }),

  updateuserpw: async (newpassword,password) =>
    await fetch('https://localhost:7275/user/password', {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' , Authorization: 'Bearer ' + window.localStorage.getItem('token') },
      body: JSON.stringify({ newpassword, password })
    }),
  updateuserprofil: async (newname,newlastname,newusername,password) =>
  await fetch('https://localhost:7275/user/profile',{
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' , Authorization: 'Bearer ' + window.localStorage.getItem('token') },
    body: JSON.stringify({ newname, newlastname,newusername,password })

  }),
}

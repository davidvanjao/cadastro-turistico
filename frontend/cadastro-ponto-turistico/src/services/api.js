import axios from "axios";

//trocar a porta da api se necessario
const api = axios.create({
    baseURL: 'http://localhost:7108/api'
})

export default api;
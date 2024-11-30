import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7269/api',  // Aquí coloca la URL base de tu API
  headers: {
    'Content-Type': 'application/json',
  },
});

export default axiosInstance;

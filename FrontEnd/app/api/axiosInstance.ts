import axios from "axios";

export const baseURL = "https://localhost:7271";

const instance = axios.create({
  baseURL,
  withCredentials: true,
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
});

export default instance;

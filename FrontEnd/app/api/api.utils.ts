// app/utils/api.ts
import axiosInstance, { baseURL } from "./axiosInstance";
// eslint-disable-next-line import/no-unresolved
import { Api } from "./api";

// Factory function to create API clients
export function createApi(): Api {
  const client = new Api(baseURL, axiosInstance);
  return client;
}

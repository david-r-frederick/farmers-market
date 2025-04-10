import { Api } from "./api";
import { createApi } from "./api.utils";

export function getApi(): Api {
  return createApi();
}

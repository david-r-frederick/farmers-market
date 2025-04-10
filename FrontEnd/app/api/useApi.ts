"use client";

/* eslint-disable no-underscore-dangle */
// app/utils/api.client.ts
import { useMemo } from "react";
import { createApi } from "./api.utils";
import { Api } from "./api";

export function useApi(): Api {
  return useMemo(() => createApi(), []);
}

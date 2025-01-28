/* eslint-disable quotes */
import type { Config } from "tailwindcss";

export default {
  content: [ "./app/**/{**,.client,.server}/**/*.{js,jsx,ts,tsx}" ],
  theme: {
    extend: {
      fontFamily: {
        sans: [
          '"Inter"',
          "ui-sans-serif",
          "system-ui",
          "sans-serif",
          '"Apple Color Emoji"',
          '"Segoe UI Emoji"',
          '"Segoe UI Symbol"',
          '"Noto Color Emoji"',
        ],
      },
      colors: {
        primary: "#9A5F35",
        secondary: "#809165",
        warning: "yellow",
        success: "green",
        danger: "red",
        light: "#F5F6F1",
      }
    },
  },
  plugins: [],
} satisfies Config;

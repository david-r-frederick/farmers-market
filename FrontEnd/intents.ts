/* eslint-disable newline-per-chained-call */
import { ButtonVariant } from "~/components/common/Button";
import {
  dangerHex,
  infoHex,
  lightHex,
  primaryHex,
  secondaryHex,
  successHex,
  warningHex,
} from "./colors.json";
import Color from "color";
import { RecursiveKeyValuePair } from "tailwindcss/types/config";

const intentToHex: { [key in ButtonVariant]: string; } = {
  danger: dangerHex,
  info: infoHex,
  light: lightHex,
  primary: primaryHex,
  secondary: secondaryHex,
  success: successHex,
  warning: warningHex,
};

const getIntentDictionary = (intent: ButtonVariant): RecursiveKeyValuePair<string, string> => {
  const dict = {} as RecursiveKeyValuePair<string, string>;
  const hexValue = intentToHex[intent];
  dict[100] = Color(hexValue).lighten(0.7).hex();
  dict[200] = Color(hexValue).lighten(0.5).hex();
  dict[300] = Color(hexValue).lighten(0.3).hex();
  dict[400] = Color(hexValue).lighten(0.1).hex();
  dict[500] = hexValue;
  dict[600] = Color(hexValue).darken(0.1).hex();
  dict[700] = Color(hexValue).darken(0.3).hex();
  dict[800] = Color(hexValue).darken(0.5).hex();
  dict[900] = Color(hexValue).darken(0.7).hex();
  return dict;
};

export const intents = {
  danger: getIntentDictionary("danger"),
  info: getIntentDictionary("info"),
  light: getIntentDictionary("light"),
  primary: getIntentDictionary("primary"),
  secondary: getIntentDictionary("secondary"),
  success: getIntentDictionary("success"),
  warning: getIntentDictionary("warning"),
};

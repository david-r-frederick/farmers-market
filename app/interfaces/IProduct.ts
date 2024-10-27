import { IBaseModel } from "./IBaseModel";

export interface IProduct extends IBaseModel {
  Name: string;
  Description: string;
  Ingredients?: string;
  Disclaimer?: string;
  Price?: number;
}

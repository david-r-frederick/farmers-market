import { IBaseModel } from "./IBaseModel";

export interface IAddress extends IBaseModel {
  City: string;
  State: string;
  Street1: string;
  Street2: string;
  ZipCode: string;
}

import { IBaseModel } from "./IBaseModel";

export interface IAddress extends IBaseModel {
  Street1: string;
  Street2: string;
  City: string;
  Region: string;
  ZipCode: string;
}

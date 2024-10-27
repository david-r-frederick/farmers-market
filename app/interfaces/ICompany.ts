import { IBaseModel } from "./IBaseModel";

export interface ICompany extends IBaseModel {
  Name: string;
  StartedDate?: string;
}

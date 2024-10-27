import { IBaseModel } from "./IBaseModel";

export interface IUser extends IBaseModel {
  FirstName: string;
  MiddleInitial: string;
  LastName: string;
  Street1: string;
  Street2: string;
  City: string;
  State: string;
  County: string;
  PostalCode: string;
}

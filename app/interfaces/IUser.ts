import { IBaseModel } from "./IBaseModel";

export interface IUser extends IBaseModel {
  City: string;
  County: string;
  FirstName: string;
  LastName: string;
  MiddleInitial: string;
  PostalCode: string;
  State: string;
  Street1: string;
  Street2: string;
}

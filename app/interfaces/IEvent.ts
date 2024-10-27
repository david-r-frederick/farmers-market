import { IAddress } from "./IAddress";
import { IBaseModel } from "./IBaseModel";
import { IUser } from "./IUser";

export interface IEvent extends IBaseModel {
  StartDate: Date;
  EndDate: Date;
  HostUserID: string;
  Users: IUser[];
  Address: IAddress;
}

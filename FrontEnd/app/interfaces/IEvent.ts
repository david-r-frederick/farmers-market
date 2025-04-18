import { IAddress } from "./IAddress";
import { IBaseModel } from "./IBaseModel";
import { IUser } from "./IUser";

export interface IEvent extends IBaseModel {
  StartDate: string;
  EndDate: string;
  HostUserId: number;
  Users: IUser[];
  Address: IAddress;
}

import { IBaseModel } from "./IBaseModel";

export interface IVendorBooth extends IBaseModel {
  ElectricityAvailable: boolean;
  IsInsidePavilion: boolean;
}

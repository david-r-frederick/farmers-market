import { IBaseModel } from "./IBaseModel";

export interface IVendorBooth extends IBaseModel {
  ID: number;
  DoesHaveElectricity: boolean;
  IsInsidePavilion: boolean;
}

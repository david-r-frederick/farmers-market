import { IProduct } from "./IProduct";

export interface IEventRegistration {
  EventDate: string;
  ProductsSelling?: IProduct[];
  SpotNumber: string;
  SpotSizeOrLocation: string;
}

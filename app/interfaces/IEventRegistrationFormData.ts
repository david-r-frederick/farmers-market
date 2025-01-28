import { IProduct } from "./IProduct";

export interface IEventRegistrationFormData {
  AgreeToPayUponArrival: boolean;
  DoesAgreeToTerms: boolean;
  EventDate: string;
  PreferredSpotNumber: string;
  ProductsSelling: IProduct[];
  SpotSizeOrLocation: string;
}

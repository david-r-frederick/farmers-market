import { IProduct } from "./IProduct";

export interface IRegistrationForm {
  FirstName: string;
  MiddleInitial: string;
  LastName: string;
  EventDate: Date;
  ProductsSelling: IProduct[];
  DoesAgreeToTerms: boolean;
}

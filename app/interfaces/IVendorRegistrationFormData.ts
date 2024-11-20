import { IProduct } from "./IProduct";

export interface IVendorRegistrationFormData {
    FirstName: string;
    LastName: string;
    Email: string;
    Phone: string;
    Street1: string;
    Street2: string;
    City: string;
    State: string;
    ZipCode: string;
    BusinessName: string;
    ProductsYouSell: IProduct[];
    PreferredSpotNumber: string;
    SpotSizeOrLocation: string;
    AgreeToPayUponArrival: boolean;
}

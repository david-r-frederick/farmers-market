import { IVendorRegistrationFormData } from "~/interfaces/IVendorRegistrationFormData";

export interface IVendorsService {
  createVendor: (formData: IVendorRegistrationFormData) => Promise<number>;
}

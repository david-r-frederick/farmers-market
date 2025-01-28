import { IVendorRegistrationFormData } from "./IVendorRegistrationFormData";

export interface IVendorRegistrationFormProps {
  onSubmit: (formData: IVendorRegistrationFormData) => void;
}

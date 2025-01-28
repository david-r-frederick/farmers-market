import { IEventRegistrationFormData } from "./IEventRegistrationFormData";

export interface IEventRegistrationFormProps {
  onSubmit: (formData: IEventRegistrationFormData) => void;
}

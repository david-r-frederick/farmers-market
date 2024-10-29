import { useForm } from "react-hook-form";
import { IVendorRegistrationFormData } from "~/interfaces/IVendorRegistrationFormData";

export const VendorRegistrationForm = ():JSX.Element => {
  const {
    register,
    formState,
    handleSubmit,
  } = useForm<IVendorRegistrationFormData>();

  const doSubmit = (data: IVendorRegistrationFormData): void => {
    // Submit form data to back end
    if (!data) {
      return;
    }
    Promise.resolve(data);
  };

  return (
    <form onSubmit={handleSubmit(doSubmit)}>
      <input {...register(
        "FirstName",
        {
          maxLength: 128,
        }
      )} />
      {formState?.errors.FirstName && <div>
        {formState.errors.FirstName.message as string}
      </div>}
    </form>
  );
};

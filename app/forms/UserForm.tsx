import { useForm } from "react-hook-form";
import { IUserFormData } from "~/interfaces/IUserFormData";

export const UserForm = (): JSX.Element => {
  const {
    register,
    formState,
    handleSubmit,
  } = useForm<IUserFormData>();

  const doSubmit = (data: IUserFormData): void => {
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

import { useForm } from "react-hook-form";
import { IProductFormData } from "~/interfaces/IProductFormData";

export const ProductForm = (): JSX.Element => {
  const {
    register,
    formState,
    handleSubmit,
  } = useForm<IProductFormData>();

  const doSubmit = (data: IProductFormData): void => {
    // Submit form data to back end
    if (!data) {
      return;
    }
    Promise.resolve(data);
  };

  return (
    <form onSubmit={handleSubmit(doSubmit)}>
      <input {...register(
        "Name",
        {
          maxLength: 128,
        }
      )} />
      {formState?.errors.Name && <div>
        {formState.errors.Name.message as string}
      </div>}
    </form>
  );
};

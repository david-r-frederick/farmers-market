/* eslint-disable @typescript-eslint/no-unused-vars */
import { useForm } from "react-hook-form";

export const EventForm = (): JSX.Element => {
  const {
    register,
    formState,
    handleSubmit,
  } = useForm();

  const doSubmitForm = (formData: unknown) => {
    // TODO
  };

  return (
    <form onSubmit={handleSubmit(doSubmitForm)}>

    </form>
  );
};

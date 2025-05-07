/* eslint-disable @typescript-eslint/no-unused-vars */
import { useForm } from "react-hook-form";
import { IEventForm } from "~/api/api";

export const EventForm = (): JSX.Element => {
  const {
    register,
    formState,
    handleSubmit,
  } = useForm<IEventForm>();

  const doSubmitForm = (formData: IEventForm) => {
    // TODO
  };

  return (
    <form onSubmit={handleSubmit(doSubmitForm)}>
      {/* address, start date, end date needed */}
    </form>
  );
};

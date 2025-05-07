import { useForm } from "react-hook-form";
import { IRegisterForEventForm } from "~/api/api";
import { Label } from "../common/form/Label";
import TextInput from "../common/form/TextInput";

export interface IEventRegistrationFormProps {
  onSubmit: (formData: IRegisterForEventForm) => void;
}

export const EventRegistrationForm = (props: IEventRegistrationFormProps): JSX.Element => {
  const { onSubmit } = props;

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IRegisterForEventForm>();

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <h2 className="text-2xl font-semibold text-center mb-4">Event Registration</h2>

      <div className="mb-4">
        <Label htmlFor="EventDate">
          Event
        </Label>
        <select {...register("eventId", { required: true })}>
          <option value="1">03/23/2024</option>
        </select>
        {errors.eventId && <p className="text-red-500 text-sm mt-1">
          Event is required
        </p>}
      </div>

      {/* Preferred Spot Number */}
      <div className="mb-4">
        <Label htmlFor="boothId">
          Preferred Spot Number
        </Label>
        <select {...register("boothId", { required: true })}>
          <option value="1">1</option>
        </select>
        {errors.boothId && <p className="text-red-500 text-sm mt-1">
          Spot selection is required
        </p>}
      </div>

      {/* Products You Sell */}
      <div className="mb-4">
        <Label htmlFor="productsSelling">
          Products You Sell (Optional)
        </Label>
        <TextInput
          type="text"
          {...register("productsSelling", { required: false })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
      </div>

      <div className="mb-4 flex items-center">
        <TextInput type="checkbox"
          {...register("agreesToPayUponArrival", { required: true })}
          className="mr-2 w-fit"
        />
        <Label htmlFor="agreesToPayUponArrival">
          I understand I will have to pay upon arrival
        </Label>
        {errors.agreesToPayUponArrival && <p className="text-red-500 text-sm ml-2">
          This field is required
        </p>}
      </div>
    </form>
  );
};

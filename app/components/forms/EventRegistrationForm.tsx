import { useForm } from "react-hook-form";
import { IEventRegistrationFormData } from "~/interfaces/IEventRegistrationFormData";
import { Label } from "../common/form/Label";
import TextInput from "../common/form/TextInput";
import { IEventRegistrationFormProps } from "~/interfaces/IEventRegistrationFormProps";

export const EventRegistrationForm = (props: IEventRegistrationFormProps): JSX.Element => {
  const { onSubmit } = props;

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IEventRegistrationFormData>();

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <h2 className="text-2xl font-semibold text-center mb-4">Event Registration</h2>

      <div className="mb-4">
        <Label htmlFor="EventDate">
          Event Date
        </Label>
        <select {...register("EventDate", { required: true })}>
          <option>03/23/2024</option>
        </select>
        {errors.EventDate && <p className="text-red-500 text-sm mt-1">
          Event Date is required
        </p>}
      </div>

      {/* Preferred Spot Number */}
      <div className="mb-4">
        <Label htmlFor="PreferredSpotNumber">
          Preferred Spot Number
        </Label>
        <TextInput
          type="number"
          {...register("PreferredSpotNumber", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.PreferredSpotNumber && <p className="text-red-500 text-sm mt-1">
          Preferred Spot Number is required
        </p>}
      </div>

      {/* Products You Sell */}
      <div className="mb-4">
        <Label htmlFor="ProductsSelling">
          Products You Sell (Optional)
        </Label>
        <TextInput
          type="text"
          {...register("ProductsSelling")}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
      </div>

      <div className="mb-4 flex items-center">
        <TextInput type="checkbox"
          {...register("AgreeToPayUponArrival", { required: true })}
          className="mr-2 w-fit"
        />
        <Label htmlFor="AgreeToPayUponArrival">
          I understand I will have to pay upon arrival
        </Label>
        {errors.AgreeToPayUponArrival && <p className="text-red-500 text-sm ml-2">
          This field is required
        </p>}
      </div>
    </form>
  );
};

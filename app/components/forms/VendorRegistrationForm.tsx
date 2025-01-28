// Import required libraries and hooks
import { useForm } from "react-hook-form";
import { IVendorRegistrationFormData } from "~/interfaces/IVendorRegistrationFormData";
import { IVendorRegistrationFormProps } from "~/interfaces/IVendorRegistrationFormProps";
import { Label } from "../common/form/Label";
import TextInput from "../common/form/TextInput";

export default function VendorRegistrationForm(props: IVendorRegistrationFormProps): JSX.Element {
  const { onSubmit } = props;

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IVendorRegistrationFormData>({
    mode: "onChange",
    criteriaMode: "all",
  });

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="bg-white shadow-md rounded-lg">
      <h2 className="text-2xl font-semibold text-center mb-4 text-gray-800">Vendor Registration</h2>

      {/* First Name */}
      <div className="mb-4">
        <Label htmlFor="FirstName">
          First Name
        </Label>
        <TextInput
          {...register(
            "FirstName",
            { required: true }
          )}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.FirstName && <p className="text-red-500 text-sm mt-1">
          First Name is required
        </p>}
      </div>

      {/* Last Name */}
      <div className="mb-4">
        <Label htmlFor="LastName">
          Last Name
        </Label>
        <TextInput
          type="text"
          {...register("LastName", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.LastName && <p className="text-red-500 text-sm mt-1">
          Last Name is required
        </p>}
      </div>

      {/* Email */}
      <div className="mb-4">
        <Label htmlFor="Email">
          Email
        </Label>
        <TextInput
          type="email"
          {...register("Email", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.Email && <p className="text-red-500 text-sm mt-1">
          Email is required
        </p>}
      </div>

      {/* Phone Number */}
      <div className="mb-4">
        <Label htmlFor="Phone">Phone Number</Label>
        <TextInput
          type="tel"
          {...register("Phone", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.Phone && <p className="text-red-500 text-sm mt-1">
          Phone Number is required
        </p>}
      </div>

      {/* Address Fields */}
      <div className="mb-4">
        <Label htmlFor="Street1">Street 1</Label>
        <TextInput
          type="text"
          {...register("Street1", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.Street1 && <p className="text-red-500 text-sm mt-1">
          Street 1 is required
        </p>}
      </div>

      <div className="mb-4">
        <Label htmlFor="Street2">Street 2 (Optional)</Label>
        <TextInput
          type="text"
          {...register("Street2")}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
      </div>

      <div className="mb-4">
        <Label htmlFor="City">City</Label>
        <TextInput
          type="text"
          {...register("City", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.City && <p className="text-red-500 text-sm mt-1">
          City is required
        </p>}
      </div>

      <div className="mb-4">
        <Label htmlFor="State">State</Label>
        <TextInput
          type="text"
          {...register("State", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.State && <p className="text-red-500 text-sm mt-1">
          State is required
        </p>}
      </div>

      <div className="mb-4">
        <Label htmlFor="Zip">Zip Code</Label>
        <TextInput
          type="text"
          {...register("ZipCode", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.ZipCode && <p className="text-red-500 text-sm mt-1">
          Zip Code is required
        </p>}
      </div>

      {/* Business Name */}
      <div className="mb-4">
        <Label htmlFor="BusinessName">
          Business Name
        </Label>
        <TextInput
          type="text"
          {...register("BusinessName", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.BusinessName && <p className="text-red-500 text-sm mt-1">
          Business Name is required
        </p>}
      </div>

      {/* Submit Button */}
      <button type="submit" className="w-full bg-blue-500 hover:bg-blue-600 text-white font-medium py-2 rounded-md">
        Register
      </button>
    </form>
  );
}

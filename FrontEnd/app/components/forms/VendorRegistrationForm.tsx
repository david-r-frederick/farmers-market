// Import required libraries and hooks
import { useForm } from "react-hook-form";
import { IVendorRegistrationFormProps } from "~/interfaces/IVendorRegistrationFormProps";
import { Label } from "../common/form/Label";
import TextInput from "../common/form/TextInput";
import PasswordInput from "../common/form/PasswordInput";
import { VendorRegistrationFormData } from "~/api/api";

export default function VendorRegistrationForm(props: IVendorRegistrationFormProps): JSX.Element {
  const { onSubmit } = props;

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<VendorRegistrationFormData>({
    mode: "onChange",
    criteriaMode: "all",
  });

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="bg-white shadow-md rounded-lg pt-4">
      <h2 className="text-2xl font-semibold text-center mb-4 text-gray-800">
        Vendor Registration
      </h2>

      {/* First Name */}
      <div className="mb-4 mx-4">
        <Label htmlFor="firstName">
          First Name
        </Label>
        <TextInput
          {...register(
            "firstName",
            { required: true }
          )}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.firstName && <p className="text-red-500 text-sm mt-1">
          First Name is required
        </p>}
      </div>

      {/* Last Name */}
      <div className="mb-4 mx-4">
        <Label htmlFor="lastName">
          Last Name
        </Label>
        <TextInput
          type="text"
          {...register("lastName", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.lastName && <p className="text-red-500 text-sm mt-1">
          Last Name is required
        </p>}
      </div>

      {/* Email */}
      <div className="mb-4 mx-4">
        <Label htmlFor="email">
          Email
        </Label>
        <TextInput
          type="email"
          {...register("email", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.email && <p className="text-red-500 text-sm mt-1">
          Email is required
        </p>}
      </div>

      {/* Password */}
      <div className="mb-4 mx-4">
        <Label htmlFor="password">
          Password
        </Label>
        <PasswordInput
          {...register("password", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.password && <p className="text-red-500 text-sm mt-1">
          Password is required
        </p>}
      </div>

      {/* Phone Number */}
      <div className="mb-4 mx-4">
        <Label htmlFor="Phone">Phone Number</Label>
        <TextInput
          type="tel"
          {...register("phone", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.phone && <p className="text-red-500 text-sm mt-1">
          Phone Number is required
        </p>}
      </div>

      {/* Address Fields */}
      <div className="mb-4 mx-4">
        <Label htmlFor="Street1">Street 1</Label>
        <TextInput
          type="text"
          {...register("street1", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.street1 && <p className="text-red-500 text-sm mt-1">
          Street 1 is required
        </p>}
      </div>

      <div className="mb-4 mx-4">
        <Label htmlFor="street2">Street 2 (Optional)</Label>
        <TextInput
          type="text"
          {...register("street2")}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
      </div>

      <div className="mb-4 mx-4">
        <Label htmlFor="city">City</Label>
        <TextInput
          type="text"
          {...register("city", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.city && <p className="text-red-500 text-sm mt-1">
          City is required
        </p>}
      </div>

      <div className="mb-4 mx-4">
        <Label htmlFor="county">County</Label>
        <TextInput
          type="text"
          {...register("county", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.county && <p className="text-red-500 text-sm mt-1">
          County is required
        </p>}
      </div>

      <div className="mb-4 mx-4">
        <Label htmlFor="state">State</Label>
        <TextInput
          type="text"
          {...register("state", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.state && <p className="text-red-500 text-sm mt-1">
          State is required
        </p>}
      </div>

      <div className="mb-4 mx-4">
        <Label htmlFor="zipCode">Zip Code</Label>
        <TextInput
          type="text"
          {...register("zipCode", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.zipCode && <p className="text-red-500 text-sm mt-1">
          Zip Code is required
        </p>}
      </div>

      {/* Business Name */}
      <div className="mb-4 mx-4">
        <Label htmlFor="businessName">
          Business Name
        </Label>
        <TextInput
          type="text"
          {...register("businessName", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.businessName && <p className="text-red-500 text-sm mt-1">
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

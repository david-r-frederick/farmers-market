// Import required libraries and hooks
import { useForm } from "react-hook-form";
import { IVendorRegistrationFormData } from "~/interfaces/IVendorRegistrationFormData";

export default function VendorRegistrationForm(): JSX.Element {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IVendorRegistrationFormData>();

  const onSubmit = (data: IVendorRegistrationFormData) => {
    console.log(data);
    // Handle form submission
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="max-w-md mx-auto p-6 bg-white shadow-md rounded-lg">
      <h2 className="text-2xl font-semibold text-center mb-4">Event Registration</h2>

      {/* First Name */}
      <div className="mb-4">
        <label className="block text-sm font-medium mb-1"
          htmlFor="FirstName">
          First Name
        </label>
        <input
          type="text"
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
        <label className="block text-sm font-medium mb-1"
          htmlFor="LastName">
          Last Name
        </label>
        <input
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
        <label className="block text-sm font-medium mb-1"
          htmlFor="Email">
          Email
        </label>
        <input
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
        <label className="block text-sm font-medium mb-1" htmlFor="Phone">Phone Number</label>
        <input
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
        <label className="block text-sm font-medium mb-1" htmlFor="Street1">Street 1</label>
        <input
          type="text"
          {...register("Street1", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.Street1 && <p className="text-red-500 text-sm mt-1">
          Street 1 is required
        </p>}
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium mb-1" htmlFor="Street2">Street 2 (Optional)</label>
        <input
          type="text"
          {...register("Street2")}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium mb-1" htmlFor="City">City</label>
        <input
          type="text"
          {...register("City", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.City && <p className="text-red-500 text-sm mt-1">
          City is required
        </p>}
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium mb-1" htmlFor="State">State</label>
        <input
          type="text"
          {...register("State", { required: true })}
          className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2"
        />
        {errors.State && <p className="text-red-500 text-sm mt-1">
          State is required
        </p>}
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium mb-1" htmlFor="Zip">Zip Code</label>
        <input
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
        <label className="block text-sm font-medium mb-1"
          htmlFor="BusinessName">
          Business Name
        </label>
        <input
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

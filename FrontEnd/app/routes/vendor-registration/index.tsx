import { useState } from "react";
import { VendorRegistrationFormData } from "~/api/api";
import VendorRegistrationForm from "~/components/forms/VendorRegistrationForm";
import { useUIStatus } from "~/hooks/useUIStatus";
import useVendorsService from "~/services/useVendorsService";

const VendorRegistrationPage = (): JSX.Element => {
  const [ didSave, setDidSave ] = useState<boolean>(false);

  const {
    UIStatus,
    beginProcessing,
    endProcessing,
  } = useUIStatus();

  const vendorsService = useVendorsService();

  const handleVendorRegistrationFormSubmit = (formData: VendorRegistrationFormData): void => {
    // a separate function so I can use async/await
    const doSubmit = async () => {
      beginProcessing();
      try {
        await vendorsService!.createVendor(formData);
        setDidSave(true);
        endProcessing();
      } catch (err) {
        endProcessing(err as Error);
      }
    };
    doSubmit();
  };

  return (
    <div className="bg-secondary py-8">
      <div className="max-w-lg mx-auto p-6">
        <VendorRegistrationForm onSubmit={handleVendorRegistrationFormSubmit} />
        {UIStatus.processing && <span>Loading...</span>}
        {didSave && <span>Saved!</span>}
      </div>
    </div>
  );
};

export default VendorRegistrationPage;

/*
  Booths
  - ID
  - LocationID
  - EventID
  - X
  - Y
  - Width
  - Height
  - Number
*/

/*
  Events
  - ID
  - StartDate
  - EndDate
  - MapID
*/

/*
  Maps
  - ID
  - FileName
*/

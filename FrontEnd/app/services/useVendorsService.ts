import { useEffect, useState } from "react";
import { useGeographyService } from "./useGeographyService";
import { VendorRegistrationFormData } from "~/api/api";
import { useApi } from "~/api/useApi";

export interface IVendorsService {
  createVendor: (formData: VendorRegistrationFormData) => Promise<number>;
}

const useVendorsService = (): IVendorsService | undefined => {
  const [ vendorsService, setVendorsService ] = useState<IVendorsService | undefined>();

  const geographyService = useGeographyService();
  const api = useApi();

  useEffect(() => {
    if (!geographyService) {
      return;
    }
    setVendorsService({
      createVendor: async (formData: VendorRegistrationFormData): Promise<number> => {
        const county = await geographyService.getCountyFromZipCode(formData.zipCode as string);
        await api.vendors_RegisterAsVendor(formData);
        return 1;
      }
    });
  }, [ geographyService ]);

  return vendorsService;
};

export default useVendorsService;

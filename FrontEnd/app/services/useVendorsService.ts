import { useEffect, useState } from "react";
import { useGeographyService } from "./useGeographyService";
import { IRegisterAsVendorForm } from "~/api/api";
import { useApi } from "~/api/useApi";

export interface IVendorsService {
  registerAsVendor: (formData: IRegisterAsVendorForm) => Promise<number>;
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
      registerAsVendor: async (formData: IRegisterAsVendorForm): Promise<number> => {
        const county = await geographyService.getCountyFromZipCode(formData.zipCode as string);
        // @ts-ignore, missing init and toJson
        await api.vendors_RegisterAsVendor({
          ...formData,
          county: "Hardin"
        });
        return 1;
      }
    });
  }, [ geographyService ]);

  return vendorsService;
};

export default useVendorsService;

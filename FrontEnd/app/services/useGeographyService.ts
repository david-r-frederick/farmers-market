import { useEffect, useState } from "react";
import { IAddress } from "~/interfaces/IAddress";

export interface IGeographyService {
  getBlankAddress: () => IAddress;
  getCountyFromZipCode: (zipCode: string) => Promise<string>;
}

export const useGeographyService = () => {
  const [ geographyService, setGeographyService ] = useState<IGeographyService | undefined>();

  useEffect(() => {
    setGeographyService({
      getBlankAddress: (): IAddress => {
        return {
          Id: -1,
          CreatedOn: new Date().toISOString(),
          IsActive: true,
          IsDeleted: false,
          Key: "",
          City: "",
          Region: "",
          Street1: "",
          Street2: "",
          ZipCode: "",
        };
      },
    
      getCountyFromZipCode: async (zipCode: string): Promise<string> => {
        // TODO use third-party service to convert zipCode to county name
        await Promise.resolve(zipCode);
        return "";
      },
    });
  }, []);

  return geographyService;
}

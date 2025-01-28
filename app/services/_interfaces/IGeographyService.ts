import { IAddress } from "~/interfaces/IAddress";

export interface IGeographyService {
  getBlankAddress: () => IAddress;
  getCountyFromZipCode: (zipCode: string) => Promise<string>;
}

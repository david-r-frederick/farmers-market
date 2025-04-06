import { IAddress } from "~/interfaces/IAddress";
import { IGeographyService } from "./_interfaces/IGeographyService";

class GeographyService implements IGeographyService {
  getBlankAddress = (): IAddress => {
    return {
      Id: -1,
      CreatedOn: new Date().toISOString(),
      IsActive: true,
      IsDeleted: false,
      Key: "",
      City: "",
      State: "",
      Street1: "",
      Street2: "",
      ZipCode: "",
    };
  };

  getCountyFromZipCode = async (zipCode: string): Promise<string> => {
    // TODO use third-party service to convert zipCode to county name
    await Promise.resolve(zipCode);
    return "";
  };
}

const geographyService = new GeographyService();

export default geographyService;

import { IVendorRegistrationFormData } from "~/interfaces/IVendorRegistrationFormData";
import { IVendorsService } from "./_interfaces/IVendorsService";
import usersService from "./UsersService";
import geographyService from "./GeographyService";

class VendorsService implements IVendorsService {
  createVendor = async (formData: IVendorRegistrationFormData): Promise<number> => {
    const {
      City,
      FirstName,
      LastName,
      State,
      Street1,
      Street2,
      ZipCode
    } = formData;
    const county = await geographyService.getCountyFromZipCode(ZipCode);
    await usersService.addUser({
      ...usersService.getBlankUser(),
      City,
      // TODO: get county from zip code
      County: county,
      FirstName,
      LastName,
      PostalCode: ZipCode,
      State,
      Street1,
      Street2,
    });
    return 1;
  };
}

const vendorsService = new VendorsService();

export default vendorsService;

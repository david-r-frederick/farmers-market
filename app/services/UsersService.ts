import { IUser } from "../interfaces/IUser";
import { IUsersService } from "./_interfaces/IUsersService";

const dummyUsers: IUser[] = [];

class UsersService implements IUsersService {
  addUser = async (user: IUser): Promise<boolean> => {
    await Promise.resolve(user);
    await Promise.resolve(dummyUsers);
    return true;
  };

  deleteUser = async (userID: number): Promise<boolean> => {
    await Promise.resolve(userID);
    return true;
  };

  getAllUsers = async (): Promise<IUser[]> => {
    await Promise.resolve();
    return [];
  };

  getBlankUser = (): IUser => {
    return {
      ID: -1,
      IsActive: true,
      IsDeleted: false,
      City: "",
      County: "",
      CreatedDate: new Date().toISOString(),
      FirstName: "",
      LastName: "",
      MiddleInitial: "",
      PostalCode: "",
      State: "",
      Street1: "",
      Street2: "",
      Key: "",
    };
  };

  getUsersForEvent = async (eventID: number): Promise<IUser[]> => {
    await Promise.resolve(eventID);
    return [];
  };

  updateUser = async (user: IUser): Promise<boolean> => {
    await Promise.resolve(user);
    return true;
  };
}

const usersService = new UsersService();

export default usersService;

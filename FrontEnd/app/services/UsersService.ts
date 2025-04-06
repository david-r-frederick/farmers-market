import { IUser } from "../interfaces/IUser";
import { IUsersService } from "./_interfaces/IUsersService";

const dummyUsers: IUser[] = [];

class UsersService implements IUsersService {
  addUser = async (user: IUser): Promise<boolean> => {
    await Promise.resolve(user);
    await Promise.resolve(dummyUsers);
    return true;
  };

  deleteUser = async (userId: number): Promise<boolean> => {
    await Promise.resolve(userId);
    return true;
  };

  getAllUsers = async (): Promise<IUser[]> => {
    await Promise.resolve();
    return [];
  };

  getBlankUser = (): IUser => {
    return {
      Id: -1,
      IsActive: true,
      IsDeleted: false,
      City: "",
      County: "",
      CreatedOn: new Date().toISOString(),
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

  getUsersForEvent = async (eventId: number): Promise<IUser[]> => {
    await Promise.resolve(eventId);
    return [];
  };

  updateUser = async (user: IUser): Promise<boolean> => {
    await Promise.resolve(user);
    return true;
  };
}

const usersService = new UsersService();

export default usersService;

import { IUser } from "../interfaces/IUser";

interface IUsersService {
  addUser: (user: IUser) => Promise<boolean>;
  deleteUser: (userID: number) => Promise<boolean>;
  getAllUsers: () => Promise<IUser[]>;
  getUsersForEvent: (eventID: number) => Promise<IUser[]>;
  updateUser: (user: IUser) => Promise<boolean>;
}

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

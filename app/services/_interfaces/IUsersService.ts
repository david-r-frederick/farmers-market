import { IUser } from "~/interfaces/IUser";

export interface IUsersService {
  addUser: (user: IUser) => Promise<boolean>;
  deleteUser: (userID: number) => Promise<boolean>;
  getAllUsers: () => Promise<IUser[]>;
  getBlankUser: () => IUser;
  getUsersForEvent: (eventID: number) => Promise<IUser[]>;
  updateUser: (user: IUser) => Promise<boolean>;
}

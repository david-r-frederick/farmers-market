import { IUser } from "~/interfaces/IUser";

export interface IUsersService {
  addUser: (user: IUser) => Promise<boolean>;
  deleteUser: (userId: number) => Promise<boolean>;
  getAllUsers: () => Promise<IUser[]>;
  getBlankUser: () => IUser;
  getUsersForEvent: (eventId: number) => Promise<IUser[]>;
  updateUser: (user: IUser) => Promise<boolean>;
}

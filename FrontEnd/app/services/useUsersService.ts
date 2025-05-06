import { useEffect, useState } from "react";
import { useApi } from "~/api/useApi";
import { IUser } from "~/api/api";

export interface IUsersService {
  addUser: (user: IUser) => Promise<boolean>;
  deleteUser: (userId: number) => Promise<boolean>;
  getAllUsers: () => Promise<IUser[]>;
  getBlankUser: () => IUser;
  getUsersForEvent: (eventId: number) => Promise<IUser[]>;
  updateUser: (user: IUser) => Promise<boolean>;
}

export const useUsersService = (): IUsersService | undefined => {
  const [ usersService, setUsersService ] = useState<IUsersService | undefined>();

  const api = useApi();

  useEffect(() => {
    setUsersService({
      addUser: async (user: IUser): Promise<boolean> => {
        await Promise.resolve(user);
        await Promise.resolve([]);
        return true;
      },
    
      deleteUser: async (userId: number): Promise<boolean> => {
        await Promise.resolve(userId);
        return true;
      },
    
      getAllUsers: async (): Promise<IUser[]> => {
        await Promise.resolve();
        return [];
      },
    
      getBlankUser: (): IUser => {
        return {
          id: -1,
          isActive: true,
          isDeleted: false,
          city: "",
          county: "",
          createdOn: new Date(),
          firstName: "",
          lastName: "",
          middleInitial: "",
          postalCode: "",
          state: "",
          street1: "",
          street2: "",
          key: "",
          userName: "",
        };
      },
    
      getUsersForEvent: async (eventId: number): Promise<IUser[]> => {
        await Promise.resolve(eventId);
        return [];
      },
    
      updateUser: async (user: IUser): Promise<boolean> => {
        await Promise.resolve(user);
        return true;
      },
    });
  }, []);

  return usersService;
}

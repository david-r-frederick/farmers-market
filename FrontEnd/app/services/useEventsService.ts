import { useEffect, useState } from "react";
import { useGeographyService } from "./useGeographyService";
import { IFullEventModel, IListEventModel, IRegisterForEventForm } from "~/api/api";

export interface IEventsService {
  addEvent: (event: IFullEventModel) => Promise<boolean>;
  deleteEvent: (eventId: number) => Promise<boolean>;
  getAllEvents: () => Promise<IListEventModel[]>;
  getBlankEvent: (formData: IRegisterForEventForm) => IFullEventModel;
  getPastEvents: () => Promise<IListEventModel[]>;
  getUpcomingEvents: () => Promise<IListEventModel[]>;
  submitEventRegistration: (eventRegistrationDto: IRegisterForEventForm) => Promise<boolean>;
  updateEvent: (event: IFullEventModel) => Promise<boolean>;
}

export const useEventsService = (): IEventsService | undefined => {
  const [ eventsService, setEventsService ] = useState<IEventsService | undefined>();

  const geographyService = useGeographyService();

  useEffect(() => {
    if (!geographyService) {
      return;
    }
    const service = {
      addEvent: async (event: IFullEventModel): Promise<boolean> => {
        await Promise.resolve(event);
        return true;
      },

      getBlankEvent: (): IFullEventModel => {
        return {
          address: geographyService.getBlankAddress(),
          id: -1,
          endDate: "",
          hostUserId: -1,
          startDate: "",
          key: "",
          addressId: -1,
        };
      },
  
      deleteEvent: async (eventId: number): Promise<boolean> => {
        await Promise.resolve(eventId);
        return true;
      },
  
      getAllEvents: (): Promise<IListEventModel[]> => {
        return Promise.resolve([]);
      },
    
      getPastEvents: (): Promise<IListEventModel[]> => {
        return new Promise((resolve) => {
          const timeout = setTimeout(() => {
            clearTimeout(timeout);
            resolve([]);
          }, 1500);
        });
      },
  
      getUpcomingEvents: (): Promise<IListEventModel[]> => {
        return new Promise((resolve) => {
          const timeout = setTimeout(() => {
            clearTimeout(timeout);
            resolve([]);
          }, 1500);
        });
      },
  
      submitEventRegistration: async (eventRegistrationDto: IRegisterForEventForm): Promise<boolean> => {
        await Promise.resolve(eventRegistrationDto);
        return true;
      },
  
      updateEvent: async (user: IFullEventModel): Promise<boolean> => {
        await Promise.resolve(user);
        return true;
      },
    };
    setEventsService(service);
  }, [ geographyService]);

  return eventsService;
};

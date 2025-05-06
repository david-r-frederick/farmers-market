import { useEffect, useState } from "react";
import { IEventRegistrationFormData } from "~/interfaces/IEventRegistrationFormData";
import { useGeographyService } from "./useGeographyService";
import { IEventRegistration } from "~/interfaces/IEventRegistration";
import { FullEventModel, ListEventModel } from "~/api/api";

export interface IEventsService {
  addEvent: (event: FullEventModel) => Promise<boolean>;
  getEventRegistrationDtoFromFormData: (formData: IEventRegistrationFormData) => IEventRegistration;
  deleteEvent: (eventId: number) => Promise<boolean>;
  getAllEvents: () => Promise<ListEventModel[]>;
  getBlankEvent: (formData: IEventRegistrationFormData) => FullEventModel;
  getPastEvents: () => Promise<ListEventModel[]>;
  getUpcomingEvents: () => Promise<ListEventModel[]>;
  submitEventRegistration: (eventRegistrationDto: IEventRegistration) => Promise<boolean>;
  updateEvent: (event: FullEventModel) => Promise<boolean>;
}

export const useEventsService = (): IEventsService | undefined => {
  const [ eventsService, setEventsService ] = useState<IEventsService | undefined>();

  const geographyService = useGeographyService();

  useEffect(() => {
    if (!geographyService) {
      return;
    }
    const service = {
      addEvent: async (event: FullEventModel): Promise<boolean> => {
        await Promise.resolve(event);
        return true;
      },

      getBlankEvent: (): FullEventModel => {
        return {
          address: geographyService.getBlankAddress(),
          id: -1,
          endDate: "",
          hostUserId: -1,
          startDate: "",
          key: "",
          addressId: -1,
        } as FullEventModel;
      },
    
      getEventRegistrationDtoFromFormData: (formData: IEventRegistrationFormData): IEventRegistration => {
        const { EventDate, ProductsSelling, PreferredSpotNumber, SpotSizeOrLocation } = formData;
        return {
          ...service.getBlankEvent(),
          EventDate,
          ProductsSelling,
          SpotNumber: PreferredSpotNumber,
          SpotSizeOrLocation,
        };
      },
  
      deleteEvent: async (eventId: number): Promise<boolean> => {
        await Promise.resolve(eventId);
        return true;
      },
  
      getAllEvents: (): Promise<ListEventModel[]> => {
        return Promise.resolve([]);
      },
    
      getPastEvents: (): Promise<ListEventModel[]> => {
        return new Promise((resolve) => {
          const timeout = setTimeout(() => {
            clearTimeout(timeout);
            resolve([]);
          }, 1500);
        });
      },
  
      getUpcomingEvents: (): Promise<ListEventModel[]> => {
        return new Promise((resolve) => {
          const timeout = setTimeout(() => {
            clearTimeout(timeout);
            resolve([]);
          }, 1500);
        });
      },
  
      submitEventRegistration: async (eventRegistrationDto: IEventRegistration): Promise<boolean> => {
        await Promise.resolve(eventRegistrationDto);
        return true;
      },
  
      updateEvent: async (user: FullEventModel): Promise<boolean> => {
        await Promise.resolve(user);
        return true;
      },
    };
    setEventsService(service);
  }, [ geographyService]);

  return eventsService;
};

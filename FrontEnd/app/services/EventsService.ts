import { IEventRegistrationFormData } from "~/interfaces/IEventRegistrationFormData";
import { IEvent } from "../interfaces/IEvent";
import { IEventsService } from "./_interfaces/IEventsService";
import geographyService from "./GeographyService";
import { IEventRegistration } from "~/interfaces/IEventRegistration";

const dummyEvents: IEvent[] = [
  {
    Id: 1,
    CreatedOn: new Date().toISOString(),
    StartDate: new Date("10/26/2024 09:00").toISOString(),
    EndDate: new Date("10/26/2024 13:00").toISOString(),
    IsActive: true,
    IsDeleted: false,
    Address: {
      Id: 1,
      CreatedOn: new Date().toISOString(),
      IsActive: true,
      IsDeleted: false,
      Street1: "123 Main St",
      Street2: "",
      City: "Lumberton",
      Region: "Texas",
      ZipCode: "77657",
    },
    HostUserId: 1,
    Users: []
  },
  {
    Id: 2,
    CreatedOn: new Date().toISOString(),
    StartDate: new Date("11/09/2024 09:00").toISOString(),
    EndDate: new Date("11/09/2024 13:00").toISOString(),
    IsActive: true,
    IsDeleted: false,
    Address: {
      Id: 2,
      CreatedOn: new Date().toISOString(),
      IsActive: true,
      IsDeleted: false,
      Street1: "123 Main St",
      Street2: "",
      City: "Lumberton",
      Region: "Texas",
      ZipCode: "77657",
    },
    HostUserId: 1,
    Users: []
  },
  {
    Id: 3,
    CreatedOn: new Date().toISOString(),
    StartDate: new Date("11/23/2024 09:00").toISOString(),
    EndDate: new Date("11/23/2024 13:00").toISOString(),
    IsActive: true,
    IsDeleted: false,
    Address: {
      Id: 3,
      CreatedOn: new Date().toISOString(),
      IsActive: true,
      IsDeleted: false,
      Street1: "123 Main St",
      Street2: "",
      City: "Lumberton",
      Region: "Texas",
      ZipCode: "77657",
    },
    HostUserId: 1,
    Users: []
  },
];

class EventsService implements IEventsService {
  addEvent = async (event: IEvent): Promise<boolean> => {
    await Promise.resolve(event);
    return true;
  };

  getBlankEvent = (): IEvent => {
    return {
      Address: geographyService.getBlankAddress(),
      Id: -1,
      CreatedOn: new Date().toISOString(),
      IsActive: true,
      IsDeleted: false,
      EndDate: "",
      HostUserId: -1,
      StartDate: "",
      Users: [],
      Key: "",
    };
  };

  getEventRegistrationDtoFromFormData = (formData: IEventRegistrationFormData): IEventRegistration => {
    const { EventDate, ProductsSelling, PreferredSpotNumber, SpotSizeOrLocation } = formData;
    return {
      ...this.getBlankEvent(),
      EventDate,
      ProductsSelling,
      SpotNumber: PreferredSpotNumber,
      SpotSizeOrLocation,
    };
  };

  deleteEvent = async (eventId: number): Promise<boolean> => {
    await Promise.resolve(eventId);
    return true;
  };

  getAllEvents = (): Promise<IEvent[]> => {
    return Promise.resolve(dummyEvents);
  };

  getPastEvents = (): Promise<IEvent[]> => {
    return new Promise((resolve) => {
      const timeout = setTimeout(() => {
        clearTimeout(timeout);
        resolve(dummyEvents);
      }, 1500);
    });
  };

  getUpcomingEvents = (): Promise<IEvent[]> => {
    return new Promise((resolve) => {
      const timeout = setTimeout(() => {
        clearTimeout(timeout);
        resolve(dummyEvents);
      }, 1500);
    });
  };

  submitEventRegistration = async (eventRegistrationDto: IEventRegistration): Promise<boolean> => {
    await Promise.resolve(eventRegistrationDto);
    return true;
  };

  updateEvent = async (user: IEvent): Promise<boolean> => {
    await Promise.resolve(user);
    return true;
  };
}

const eventsService = new EventsService();

export default eventsService;

import { IEvent } from "~/interfaces/IEvent";
import { IEventRegistration } from "~/interfaces/IEventRegistration";
import { IEventRegistrationFormData } from "~/interfaces/IEventRegistrationFormData";

export interface IEventsService {
  addEvent: (event: IEvent) => Promise<boolean>;
  getEventRegistrationDtoFromFormData: (formData: IEventRegistrationFormData) => IEventRegistration;
  deleteEvent: (eventId: number) => Promise<boolean>;
  getAllEvents: () => Promise<IEvent[]>;
  getBlankEvent: (formData: IEventRegistrationFormData) => IEvent;
  getPastEvents: () => Promise<IEvent[]>;
  getUpcomingEvents: () => Promise<IEvent[]>;
  updateEvent: (event: IEvent) => Promise<boolean>;
}

import { useEffect, useState } from "react";
import { IEvent } from "../interfaces/IEvent";
import { IUIStatus, useUIStatus } from "./useUIStatus";
import EventsService from "../services/EventsService";

interface IUseUpcomingEventsData {
  upcomingEvents: IEvent[] | null;
  UIStatus: IUIStatus;
}

export const useUpcomingEvents = (): IUseUpcomingEventsData => {
  const [ upcomingEvents, setUpcomingEvents ] = useState<IEvent[] | null>(null);

  const {
    UIStatus,
    beginProcessing,
    endProcessing
  } = useUIStatus();

  useEffect(() => {
    const fetchUpcomingEvents = async () => {
      beginProcessing();
      try {
        const res = await EventsService.getUpcomingEvents();
        setUpcomingEvents(res);
        endProcessing();
      } catch (err: unknown) {
        endProcessing(err as Error);
      }
    };
    fetchUpcomingEvents();
  }, []);

  return {
    upcomingEvents,
    UIStatus
  };
};

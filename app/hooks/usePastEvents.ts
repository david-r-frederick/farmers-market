import { useEffect, useState } from "react";
import { IEvent } from "../interfaces/IEvent";
import { IUIStatus, useUIStatus } from "./useUIStatus";
import eventsService from "../services/EventsService";

interface IUsePastEventsData {
  pastEvents: IEvent[] | null;
  UIStatus: IUIStatus;
}

export const usePastEvents = (): IUsePastEventsData => {
  const [ pastEvents, setPastEvents ] = useState<IEvent[] | null>(null);

  const {
    UIStatus,
    beginProcessing,
    endProcessing
  } = useUIStatus();

  useEffect(() => {
    const loadPastEvents = async () => {
      beginProcessing();
      try {
        const res = await eventsService.getPastEvents();
        setPastEvents(res);
        endProcessing();
      } catch (err: unknown) {
        endProcessing((err as Error)?.message || "Failed to fetch past events");
      }
    };
    loadPastEvents();
  }, []);

  return {
    pastEvents,
    UIStatus,
  };
};

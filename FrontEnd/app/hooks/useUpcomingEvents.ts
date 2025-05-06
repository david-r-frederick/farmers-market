import { useEffect, useState } from "react";
import { IUIStatus, useUIStatus } from "./useUIStatus";
import { useEventsService } from "../services/useEventsService";
import { ListEventModel } from "~/api/api";

interface IUseUpcomingEventsData {
  upcomingEvents: ListEventModel[] | null;
  UIStatus: IUIStatus;
}

export const useUpcomingEvents = (): IUseUpcomingEventsData => {
  const [ upcomingEvents, setUpcomingEvents ] = useState<ListEventModel[] | null>(null);

  const {
    UIStatus,
    beginProcessing,
    endProcessing
  } = useUIStatus();

  const eventsService = useEventsService();

  useEffect(() => {
    if (!eventsService) {
      return;
    }
    const fetchUpcomingEvents = async () => {
      beginProcessing();
      try {
        const res = await eventsService.getUpcomingEvents();
        setUpcomingEvents(res);
        endProcessing();
      } catch (err: unknown) {
        endProcessing(err as Error);
      }
    };
    fetchUpcomingEvents();
  }, [ eventsService ]);

  return {
    upcomingEvents,
    UIStatus
  };
};

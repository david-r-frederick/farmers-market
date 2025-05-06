import { useEffect, useState } from "react";
import { IUIStatus, useUIStatus } from "./useUIStatus";
import { useEventsService } from "../services/useEventsService";
import { ListEventModel } from "~/api/api";

interface IUsePastEventsData {
  pastEvents: ListEventModel[] | null;
  UIStatus: IUIStatus;
}

export const usePastEvents = (): IUsePastEventsData => {
  const [ pastEvents, setPastEvents ] = useState<ListEventModel[] | null>(null);

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
  }, [ eventsService ]);

  return {
    pastEvents,
    UIStatus,
  };
};

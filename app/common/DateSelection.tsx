/* eslint-disable @typescript-eslint/no-unused-vars */
import { useUpcomingEvents } from "../hooks/useUpcomingEvents";

export const DateSelection = (): JSX.Element => {
  const { upcomingEvents, UIStatus } = useUpcomingEvents();

  return (
    <select>
      {}
    </select>
  );
};

import { useState } from "react";
import { EventRegistrationForm } from "~/components/forms/EventRegistrationForm";
import { useUIStatus } from "~/hooks/useUIStatus";
import { IEventRegistrationFormData } from "~/interfaces/IEventRegistrationFormData";
import { useEventsService } from "~/services/useEventsService";

const EventRegistrationPage = (): JSX.Element => {
  const [ didSave, setDidSave ] = useState<boolean>(false);

  const {
    UIStatus,
    beginProcessing,
    endProcessing
  } = useUIStatus();

  const eventsService = useEventsService();

  const handleEventRegistrationFormSubmit = (formData: IEventRegistrationFormData): void => {
    if (!eventsService) {
      return;
    }
    // a separate function so I can use async/await
    const doSubmit = async () => {
      beginProcessing();
      try {
        const eventRegistrationDto = eventsService.getEventRegistrationDtoFromFormData(formData);
        await eventsService.submitEventRegistration(eventRegistrationDto);
        setDidSave(true);
        endProcessing();
      } catch (err) {
        endProcessing(err as Error);
      }
    };
    doSubmit();
  };

  return (
    <div className="bg-secondary py-8">
      <div className="max-w-lg mx-auto p-6">
        <EventRegistrationForm onSubmit={handleEventRegistrationFormSubmit} />
        {UIStatus.processing && <span>Loading...</span>}
        {didSave && <span>Saved!</span>}
      </div>
    </div>
  );
};

export default EventRegistrationPage;

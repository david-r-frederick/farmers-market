import { useState } from "react";

export interface IUIStatus {
  processing?: boolean;
  errorMessage?: string;
}

export interface IUseUIStatusOptions {
  startProcessing?: boolean;
}

const initialUIStatus: IUIStatus = {
  processing: false,
  errorMessage: "",
};

export interface IUseUIStatusData {
  UIStatus: IUIStatus;
  beginProcessing: () => void;
  endProcessing: (errorMessage?: string | Error, useModal?: boolean) => void;
  resetUIStatus: () => void;
}

export const useUIStatus = (options?: IUseUIStatusOptions): IUseUIStatusData => {
  const [ UIStatus, setUIStatus ] = useState<IUIStatus>({
    ...initialUIStatus,
    processing: options?.startProcessing || false,
  });

  const beginProcessing = (): void => {
    setUIStatus({
      ...UIStatus,
      errorMessage: "",
      processing: true,
    });
  };

  const endProcessing = (errorMessage?: string | Error): void => {
    let messageToUse = "";
    if (errorMessage) {
      messageToUse = typeof errorMessage === "string"
        ? errorMessage
        : errorMessage.message;
    }

    setUIStatus({
      ...UIStatus,
      errorMessage: messageToUse,
      processing: false,
    });

    /* if (useModal) {
      const div = document.createElement("div");

      const cleanUp = () => {
        ReactDOM.unmountComponentAtNode(div);
        document.body.removeChild(div);
      };

      document.body.appendChild(div);
    } */
  };

  const resetUIStatus = () => {
    setUIStatus(initialUIStatus);
  };

  return {
    beginProcessing,
    endProcessing,
    resetUIStatus,
    UIStatus,
  };
};

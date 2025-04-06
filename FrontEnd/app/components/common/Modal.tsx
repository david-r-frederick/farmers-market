import React from "react";

export interface IModalProps {
  size?: "sm" | "md" | "lg" | "xl";
  title?: string;
  titleId?: string;
  showHeader?: boolean;
  onCancel: () => void;
  show: boolean;
  children?: React.ReactNode;
  loading?: boolean;
  modalBodyClasses?: string;
}

export const Modal = (props: IModalProps): JSX.Element => {
  const { title, titleId, onCancel, size, show, loading, showHeader, modalBodyClasses, children } = props;

  const onCancelButtonPressed = () => {
    if (onCancel) {
      onCancel();
    }
  };

  return (
    <>
      {show && (
        <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
          <div
            className={`relative bg-white rounded-lg shadow-lg max-w-${size === "sm" ? "xs" : size} w-full`}>
            {showHeader && (
              <div className="flex items-center justify-between p-4 border-b rounded-t bg-gray-800">
                <h5 className="text-lg font-medium text-white" id={titleId ?? ""}>
                  {title ?? "Message"}
                </h5>
                <button
                  type="button"
                  className="text-white bg-transparent hover:bg-gray-700 rounded-lg p-1.5 ml-auto"
                  aria-label="Close"
                  aria-hidden="true"
                  onClick={onCancelButtonPressed}>
                  &times;
                </button>
              </div>
            )}
            <div className={`p-6 ${modalBodyClasses ?? ""}`}>
              {loading ? (
                <div className="flex justify-center">
                  <div className="w-8 h-8 border-4 border-t-transparent border-gray-400 rounded-full animate-spin">
                  </div>
                </div>
              ) : (
                children
              )}
            </div>
          </div>
        </div>
      )}
    </>
  );
};

Modal.defaultProps = {
  showHeader: true,
  size: "lg"
};

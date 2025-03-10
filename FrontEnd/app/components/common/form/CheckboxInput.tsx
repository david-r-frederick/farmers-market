import React from "react";
import utilitiesService from "../../../services/UtilitiesService";

interface CheckboxInputProps extends React.ComponentProps<"input"> {
  _?: string;
}

const CheckboxInput = React.forwardRef<HTMLInputElement, CheckboxInputProps>(
  (props: CheckboxInputProps, ref) => {
    const { className, ...remainingProps } = props;
    return (
      <input
        type="checkbox"
        ref={ref}
        className={
          utilitiesService.mergeClassNames(
            "w-full px-3 py-2 bg-white text-black border rounded-md focus:outline-none focus:ring-2",
            className
          )
        }
        {...remainingProps}
      />
    );
  }
);

CheckboxInput.displayName = "CheckboxInput";

export default CheckboxInput;

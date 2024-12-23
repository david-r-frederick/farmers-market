import React from "react";
import { UtilitiesService } from "../../../services/UtilitiesService";

interface TextInputProps extends React.ComponentProps<"input"> {
  _?: string;
}

const TextInput = React.forwardRef<HTMLInputElement, TextInputProps>(
  (props: TextInputProps, ref) => {
    const { className, ...remainingProps } = props;
    return (
      <input
        type="text"
        ref={ref}
        className={
          UtilitiesService.mergeClassNames(
            "w-full px-3 py-2 bg-white text-black border border-gray-300 rounded-md focus:outline-none focus:ring-2",
            className
          )
        }
        {...remainingProps}
      />
    );
  }
);

TextInput.displayName = "TextInput";

export default TextInput;

import React, { useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEye, faEyeSlash } from "@fortawesome/free-solid-svg-icons";
import utilitiesService from "../../../services/UtilitiesService";
import { Button } from "../Button";

interface PasswordInputProps extends React.ComponentProps<"input"> {
  _?: string;
}

const PasswordInput = React.forwardRef<HTMLInputElement, PasswordInputProps>(
  (props: PasswordInputProps, ref) => {
    const { className, ...remainingProps } = props;
    const [showPassword, setShowPassword] = useState(false);

    const togglePasswordVisibility = () => {
      setShowPassword((prev) => !prev);
    };

    return (
      <div className="relative w-full flex">
        <input
          type={showPassword ? "text" : "password"}
          ref={ref}
          className={utilitiesService.mergeClassNames(
            "w-full px-3 py-2 bg-white text-black border border-gray-300 rounded-md focus:outline-none focus:ring-2 pr-10",
            className
          )}
          {...remainingProps}
        />
        <Button
          type="button"
          intent="light-100"
          onClick={togglePasswordVisibility}
          className="w-fit px-3 text-gray-500 hover:text-gray-700">
          <FontAwesomeIcon icon={showPassword ? faEyeSlash : faEye} />
        </Button>
      </div>
    );
  }
);

PasswordInput.displayName = "PasswordInput";

export default PasswordInput;
import React from "react";
import utilitiesService from "~/services/UtilitiesService";

/* eslint-disable @typescript-eslint/no-empty-interface */
interface LabelProps extends React.ComponentProps<"label"> { }

export const Label = React.forwardRef<HTMLLabelElement, LabelProps>(
  (props: LabelProps, ref): React.ReactNode => {
    const { children, className, ...remainingProps } = props;

    return (
      <label
        className={
          utilitiesService.mergeClassNames(
            "block text-sm font-medium text-gray-800",
            className
          )
        }
        ref={ref}
        {...remainingProps}>
        {children}
      </label>
    );
  }
);

Label.displayName = "Label";

import React from "react";
import utilitiesService from "../../../services/UtilitiesService";

interface H6Props extends React.ComponentProps<"h1"> {
  _?: string;
}

const H6 = React.forwardRef<HTMLHeadingElement, H6Props>(
  (props: H6Props, ref) => {
    const { children, className, ...remainingProps } = props;
    return (
      <h1
        ref={ref}
        className={utilitiesService.mergeClassNames("", className)}
        {...remainingProps}
      >
        {children}
      </h1>
    );
  }
);

H6.displayName = "H6";

export default H6;

import React from "react";
import UtilitiesService from "../../../services/UtilitiesService";

interface H4Props extends React.ComponentProps<"h1"> {
  _?: string;
}

const H4 = React.forwardRef<HTMLHeadingElement, H4Props>(
  (props: H4Props, ref) => {
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

H4.displayName = "H4";

export default H4;

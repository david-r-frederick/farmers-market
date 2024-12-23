import React from "react";
import { UtilitiesService } from "../../../services/UtilitiesService";

interface H3Props extends React.ComponentProps<"h1"> {
  _?: string;
}

const H3 = React.forwardRef<HTMLHeadingElement, H3Props>(
  (props: H3Props, ref) => {
    const { children, className, ...remainingProps } = props;
    return (
      <h1
        ref={ref}
        className={UtilitiesService.mergeClassNames("", className)}
        {...remainingProps}
      >
        {children}
      </h1>
    );
  }
);

H3.displayName = "H3";

export default H3;

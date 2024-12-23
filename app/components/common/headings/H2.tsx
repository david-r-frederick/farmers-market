import React from "react";
import { UtilitiesService } from "../../../services/UtilitiesService";

interface H2Props extends React.ComponentProps<"h1"> {
  _?: string;
}

const H2 = React.forwardRef<HTMLHeadingElement, H2Props>(
  (props: H2Props, ref) => {
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

H2.displayName = "H2";

export default H2;

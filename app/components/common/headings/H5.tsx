import React from "react";
import { UtilitiesService } from "../../../services/UtilitiesService";

interface H5Props extends React.ComponentProps<"h1"> {
  _?: string;
}

const H5 = React.forwardRef<HTMLHeadingElement, H5Props>(
  (props: H5Props, ref) => {
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

H5.displayName = "H5";

export default H5;

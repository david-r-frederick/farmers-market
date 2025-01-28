import React from "react";
import utilitiesService from "../../../services/UtilitiesService";

interface H1Props extends React.ComponentProps<"h1"> {
  _?: string;
}

const H1 = React.forwardRef<HTMLHeadingElement, H1Props>(
  (props: H1Props, ref) => {
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

H1.displayName = "H1";

export default H1;

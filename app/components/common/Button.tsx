import React from "react";
import { cva, type VariantProps } from "class-variance-authority";
import colorsService from "../../services/ColorsService";
import utilitiesService from "../../services/UtilitiesService";

const button = cva(
  [
    "font-semibold",
    "border",
    "rounded",
    "w-full"
  ],
  {
    variants: {
      intent: colorsService.intent,
      size: {
        small: [ "text-sm", "py-1", "px-2" ],
        medium: [ "text-base", "py-2", "px-4" ],
        large: [ "text-lg", "py-3", "px-5" ],
      },
      // `boolean` variants are also supported!
      disabled: {
        false: null,
        true: [ "opacity-50", "cursor-not-allowed" ],
      },
    },
    // compoundVariants: [
    //   {
    //     intent: "primary",
    //     disabled: false,
    //     class: "hover:bg-primary-600",
    //   },
    //   {
    //     intent: "secondary",
    //     disabled: false,
    //     class: "hover:bg-gray-100",
    //   },
    //   {
    //     intent: "primary",
    //     size: "medium",
    //     // **or** if you're a React.js user, `className` may feel more consistent:
    //     className: "uppercase",
    //   },
    // ],
    defaultVariants: {
      intent: "primary-500",
      size: "medium",
      disabled: false,
    },
  }
);

interface ButtonProps extends React.ComponentProps<"button">,
  VariantProps<typeof button> {
  title?: string;
  disabled?: boolean;
}

const Button = React.forwardRef<HTMLButtonElement, ButtonProps>(
  (props: ButtonProps, ref) => {
    const { children, className, disabled, size, title, intent, ...remainingProps } = props;

    return (
      <button
        ref={ref}
        className={utilitiesService.mergeClassNames(
          button({ className, disabled, intent, size })
        )}
        {...remainingProps}>
        {children ?? title}
      </button>
    );
  }
);
Button.displayName = "Button";

export { Button };

import { ButtonVariant } from "~/components/common/Button";
import { IntentSection } from "~/interfaces/IntentSection";

export interface IColorsService {
  printFullIntent: () => void;
  setUpIntent: (intent: ButtonVariant) => IntentSection;
  textWhiteOrBlack: (intent: ButtonVariant, weight: number) => "text-white" | "text-black";
}

import Color from "color";
import { IColorsService } from "./_interfaces/IColorsService";
import { Intent } from "~/components/common/_interfaces/Intent";
import { intents } from "../../intents";
import { IntentSection } from "~/interfaces/IntentSection";

class ColorsService implements IColorsService {
  public textWhiteOrBlack = (intent: Intent, weight: number): "text-white" | "text-black" => {
    const hexColor = intents[intent][weight] as string;
    return Color(hexColor).contrast(Color("white")) >= 4.5 ? "text-white" : "text-black";
  };

  public setUpIntent = (intent: Intent): IntentSection => {
    const intentsWithWeights = {} as IntentSection;
    [ 100, 200, 300, 400, 500, 600, 700, 800, 900 ].forEach(weight => {
      intentsWithWeights[`${intent}-${weight}`] = [
        `bg-${intent}-${weight}`,
        `hover:bg-${intent}-${weight === 900 ? weight - 100 : weight + 100}`,
        this.textWhiteOrBlack(intent, weight),
        `border-${intent}`
      ];
    });
    return intentsWithWeights;
  };

  fullIntent = {
    ...this.setUpIntent("danger"),
    ...this.setUpIntent("info"),
    ...this.setUpIntent("light"),
    ...this.setUpIntent("primary"),
    ...this.setUpIntent("secondary"),
    ...this.setUpIntent("success"),
    ...this.setUpIntent("warning"),
  };

  public intent = {
    "danger-100": [ "bg-danger-100", "hover:bg-danger-200", "text-black", "border-danger" ],
    "danger-200": [ "bg-danger-200", "hover:bg-danger-300", "text-black", "border-danger" ],
    "danger-300": [ "bg-danger-300", "hover:bg-danger-400", "text-black", "border-danger" ],
    "danger-400": [ "bg-danger-400", "hover:bg-danger-500", "text-black", "border-danger" ],
    "danger-500": [ "bg-danger-500", "hover:bg-danger-600", "text-black", "border-danger" ],
    "danger-600": [ "bg-danger-600", "hover:bg-danger-700", "text-white", "border-danger" ],
    "danger-700": [ "bg-danger-700", "hover:bg-danger-800", "text-white", "border-danger" ],
    "danger-800": [ "bg-danger-800", "hover:bg-danger-900", "text-white", "border-danger" ],
    "danger-900": [ "bg-danger-900", "hover:bg-danger-800", "text-white", "border-danger" ],
    "info-100": [ "bg-info-100", "hover:bg-info-200", "text-black", "border-info" ],
    "info-200": [ "bg-info-200", "hover:bg-info-300", "text-black", "border-info" ],
    "info-300": [ "bg-info-300", "hover:bg-info-400", "text-white", "border-info" ],
    "info-400": [ "bg-info-400", "hover:bg-info-500", "text-white", "border-info" ],
    "info-500": [ "bg-info-500", "hover:bg-info-600", "text-white", "border-info" ],
    "info-600": [ "bg-info-600", "hover:bg-info-700", "text-white", "border-info" ],
    "info-700": [ "bg-info-700", "hover:bg-info-800", "text-white", "border-info" ],
    "info-800": [ "bg-info-800", "hover:bg-info-900", "text-white", "border-info" ],
    "info-900": [ "bg-info-900", "hover:bg-info-800", "text-white", "border-info" ],
    "light-100": [ "bg-light-100", "hover:bg-light-200", "text-black", "border-light" ],
    "light-200": [ "bg-light-200", "hover:bg-light-300", "text-black", "border-light" ],
    "light-300": [ "bg-light-300", "hover:bg-light-400", "text-black", "border-light" ],
    "light-400": [ "bg-light-400", "hover:bg-light-500", "text-black", "border-light" ],
    "light-500": [ "bg-light-500", "hover:bg-light-600", "text-black", "border-light" ],
    "light-600": [ "bg-light-600", "hover:bg-light-700", "text-black", "border-light" ],
    "light-700": [ "bg-light-700", "hover:bg-light-800", "text-black", "border-light" ],
    "light-800": [ "bg-light-800", "hover:bg-light-900", "text-black", "border-light" ],
    "light-900": [ "bg-light-900", "hover:bg-light-800", "text-white", "border-light" ],
    "primary-100": [ "bg-primary-100", "hover:bg-primary-200", "text-black", "border-primary" ],
    "primary-200": [ "bg-primary-200", "hover:bg-primary-300", "text-black", "border-primary" ],
    "primary-300": [ "bg-primary-300", "hover:bg-primary-400", "text-black", "border-primary" ],
    "primary-400": [ "bg-primary-400", "hover:bg-primary-500", "text-black", "border-primary" ],
    "primary-500": [ "bg-primary-500", "hover:bg-primary-600", "text-white", "border-primary" ],
    "primary-600": [ "bg-primary-600", "hover:bg-primary-700", "text-white", "border-primary" ],
    "primary-700": [ "bg-primary-700", "hover:bg-primary-800", "text-white", "border-primary" ],
    "primary-800": [ "bg-primary-800", "hover:bg-primary-900", "text-white", "border-primary" ],
    "primary-900": [ "bg-primary-900", "hover:bg-primary-800", "text-white", "border-primary" ],
    "secondary-100": [ "bg-secondary-100", "hover:bg-secondary-200", "text-black", "border-secondary" ],
    "secondary-200": [ "bg-secondary-200", "hover:bg-secondary-300", "text-black", "border-secondary" ],
    "secondary-300": [ "bg-secondary-300", "hover:bg-secondary-400", "text-black", "border-secondary" ],
    "secondary-400": [ "bg-secondary-400", "hover:bg-secondary-500", "text-black", "border-secondary" ],
    "secondary-500": [ "bg-secondary-500", "hover:bg-secondary-600", "text-black", "border-secondary" ],
    "secondary-600": [ "bg-secondary-600", "hover:bg-secondary-700", "text-black", "border-secondary" ],
    "secondary-700": [ "bg-secondary-700", "hover:bg-secondary-800", "text-white", "border-secondary" ],
    "secondary-800": [ "bg-secondary-800", "hover:bg-secondary-900", "text-white", "border-secondary" ],
    "secondary-900": [ "bg-secondary-900", "hover:bg-secondary-800", "text-white", "border-secondary" ],
    "success-100": [ "bg-success-100", "hover:bg-success-200", "text-black", "border-success" ],
    "success-200": [ "bg-success-200", "hover:bg-success-300", "text-black", "border-success" ],
    "success-300": [ "bg-success-300", "hover:bg-success-400", "text-black", "border-success" ],
    "success-400": [ "bg-success-400", "hover:bg-success-500", "text-black", "border-success" ],
    "success-500": [ "bg-success-500", "hover:bg-success-600", "text-white", "border-success" ],
    "success-600": [ "bg-success-600", "hover:bg-success-700", "text-white", "border-success" ],
    "success-700": [ "bg-success-700", "hover:bg-success-800", "text-white", "border-success" ],
    "success-800": [ "bg-success-800", "hover:bg-success-900", "text-white", "border-success" ],
    "success-900": [ "bg-success-900", "hover:bg-success-800", "text-white", "border-success" ],
    "warning-100": [ "bg-warning-100", "hover:bg-warning-200", "text-black", "border-warning" ],
    "warning-200": [ "bg-warning-200", "hover:bg-warning-300", "text-black", "border-warning" ],
    "warning-300": [ "bg-warning-300", "hover:bg-warning-400", "text-black", "border-warning" ],
    "warning-400": [ "bg-warning-400", "hover:bg-warning-500", "text-black", "border-warning" ],
    "warning-500": [ "bg-warning-500", "hover:bg-warning-600", "text-black", "border-warning" ],
    "warning-600": [ "bg-warning-600", "hover:bg-warning-700", "text-black", "border-warning" ],
    "warning-700": [ "bg-warning-700", "hover:bg-warning-800", "text-black", "border-warning" ],
    "warning-800": [ "bg-warning-800", "hover:bg-warning-900", "text-black", "border-warning" ],
    "warning-900": [ "bg-warning-900", "hover:bg-warning-800", "text-white", "border-warning" ]
  };

  public printFullIntent = () => {
    console.log(this.fullIntent);
  };
}

const colorsService = new ColorsService();

export default colorsService;

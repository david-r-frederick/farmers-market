import clsx, { ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";
import { IUtilitiesService } from "./_interfaces/IUtilitiesService";

class UtilitiesServiceClass implements IUtilitiesService {
  public mergeClassNames = (...classNames: ClassValue[]): string => {
    return twMerge(clsx(classNames));
  };
}

const utilitiesService = new UtilitiesServiceClass();

export default utilitiesService;

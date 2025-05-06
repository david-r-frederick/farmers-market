import clsx, { ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";

export interface IUtilitiesService {
  mergeClassNames: (classNames: ClassValue[]) => string;
}

class UtilitiesServiceClass implements IUtilitiesService {
  public mergeClassNames = (...classNames: ClassValue[]): string => {
    return twMerge(clsx(classNames));
  };
}

const utilitiesService = new UtilitiesServiceClass();

export default utilitiesService;

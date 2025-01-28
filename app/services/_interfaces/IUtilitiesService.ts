import { ClassValue } from "clsx";

export interface IUtilitiesService {
  mergeClassNames: (classNames: ClassValue[]) => string;
}

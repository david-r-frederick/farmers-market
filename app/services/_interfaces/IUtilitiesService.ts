import { ClassValue } from "clsx";

export interface IutilitiesService {
  mergeClassNames: (classNames: ClassValue[]) => string;
}

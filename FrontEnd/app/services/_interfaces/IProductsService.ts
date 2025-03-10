import { IProduct } from "~/interfaces/IProduct";

export interface IProductsService {
  addProduct: (product: IProduct) => Promise<boolean>;
  deleteProduct: (productID: number) => Promise<boolean>;
  getAllProducts: () => Promise<IProduct[]>;
  getProductsForEvent: (eventID: number) => Promise<IProduct[]>;
}

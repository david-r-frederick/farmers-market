import { IProduct } from "~/interfaces/IProduct";

export interface IProductsService {
  addProduct: (product: IProduct) => Promise<boolean>;
  deleteProduct: (productId: number) => Promise<boolean>;
  getAllProducts: () => Promise<IProduct[]>;
  getProductsForEvent: (eventId: number) => Promise<IProduct[]>;
}

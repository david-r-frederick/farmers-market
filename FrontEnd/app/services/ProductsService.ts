import { IProduct } from "../interfaces/IProduct";
import { IProductsService } from "./_interfaces/IProductsService";

const dummyProducts: IProduct[] = [];

class ProductsService implements IProductsService {
  addProduct = async (product: IProduct): Promise<boolean> => {
    await Promise.resolve(product);
    await Promise.resolve(dummyProducts);
    return true;
  };

  deleteProduct = async (productID: number): Promise<boolean> => {
    await Promise.resolve(productID);
    return true;
  };

  getAllProducts = async (): Promise<IProduct[]> => {
    await Promise.resolve();
    return [];
  };

  getProductsForEvent = async (eventID: number): Promise<IProduct[]> => {
    await Promise.resolve(eventID);
    return [];
  };
}

const productsService = new ProductsService();

export default productsService;

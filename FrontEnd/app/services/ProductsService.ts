import { IProduct } from "../interfaces/IProduct";
import { IProductsService } from "./_interfaces/IProductsService";

const dummyProducts: IProduct[] = [];

class ProductsService implements IProductsService {
  addProduct = async (product: IProduct): Promise<boolean> => {
    await Promise.resolve(product);
    await Promise.resolve(dummyProducts);
    return true;
  };

  deleteProduct = async (productId: number): Promise<boolean> => {
    await Promise.resolve(productId);
    return true;
  };

  getAllProducts = async (): Promise<IProduct[]> => {
    await Promise.resolve();
    return [];
  };

  getProductsForEvent = async (eventId: number): Promise<IProduct[]> => {
    await Promise.resolve(eventId);
    return [];
  };
}

const productsService = new ProductsService();

export default productsService;

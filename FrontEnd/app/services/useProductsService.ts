import { useEffect, useState } from "react";
import { IProduct } from "../interfaces/IProduct";

export interface IProductsService {
  addProduct: (product: IProduct) => Promise<boolean>;
  deleteProduct: (productId: number) => Promise<boolean>;
  getAllProducts: () => Promise<IProduct[]>;
  getProductsForEvent: (eventId: number) => Promise<IProduct[]>;
}

export const useProductsService = () => {
  const [ productsService, setProductsService ] = useState<IProductsService | undefined>();

  useEffect(() => {
    setProductsService({
      addProduct: async (product: IProduct): Promise<boolean> => {
        await Promise.resolve(product);
        await Promise.resolve([]);
        return true;
      },

      deleteProduct: async (productId: number): Promise<boolean> => {
        await Promise.resolve(productId);
        return true;
      },

      getAllProducts: async (): Promise<IProduct[]> => {
        await Promise.resolve();
        return [];
      },

      getProductsForEvent: async (eventId: number): Promise<IProduct[]> => {
        await Promise.resolve(eventId);
        return [];
      },
    });
  }, []);

  return productsService;
};

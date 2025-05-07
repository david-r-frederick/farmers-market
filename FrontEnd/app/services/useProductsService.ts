import { useEffect, useState } from "react";
import { FullProductModel, IFullProductModel, IListProductModel } from "~/api/api";
import { useApi } from "~/api/useApi";

export interface IProductsService {
  addProduct: (product: IFullProductModel) => Promise<boolean>;
  deleteProduct: (productId: number) => Promise<boolean>;
  getAllProducts: () => Promise<IFullProductModel[]>;
  getProductsForEvent: (eventId: number) => Promise<IFullProductModel[]>;
}

export const useProductsService = () => {
  const [ productsService, setProductsService ] = useState<IProductsService | undefined>();

  const api = useApi();

  useEffect(() => {
    setProductsService({
      addProduct: async (product: IFullProductModel): Promise<boolean> => {
        await api.products_CreateProduct(product as FullProductModel);
        return true;
      },

      deleteProduct: async (productId: number): Promise<boolean> => {
        await Promise.resolve(productId);
        return true;
      },

      getAllProducts: async (): Promise<IListProductModel[]> => {
        // @ts-ignore
        await api.products_GetAllProducts({ pageNumber: 1 });
        return [];
      },

      getProductsForEvent: async (eventId: number): Promise<IFullProductModel[]> => {
        await Promise.resolve(eventId);
        return [];
      },
    });
  }, []);

  return productsService;
};

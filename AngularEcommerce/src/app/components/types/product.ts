export type Product ={
  id: number;
  name: string;
  description: string;
  categoryId: number;
  category: ProductCategory;
  price: number;
  qty: number;
  product_image: string;
  sku: string;
 [key: string]: any;
}

export type ProductCategory= {
  id: number;
  name: string;
  parentCategoryId: number;
  categoryVariations: CategoryVariation[];
  products: Product[];
}

export type CategoryVariation ={
  id: number;
  categoryId: number;
  variationName: string;
  productCategories: ProductCategory[];
}

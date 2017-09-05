import { ProductImageModel } from './../product-image/product-image.model';
import { ProductVariationModel } from './../product-variations/product-variation.model';
import { ProductSpecsModel } from './../product-specs/product-specs.model';
import { ProductCategoryModel } from './../product-category/product-category.model';
export interface ProductModel {
    productId: string;
    productName: string;
    productPrice: number;
    productStock: number;
    productRating: number;
    productFavorite: number;
    productReview: number;
    productDescription: string;
    productLocation: number;
    productFrontImage: string;
    TblProductCategory: ProductCategoryModel[];
    TblProductSpecs: ProductSpecsModel[];
    TblProductVariations: ProductVariationModel[];
    TblProductImage: ProductImageModel[];
}

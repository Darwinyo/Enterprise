import { ProductVariationModel } from './../../models/product/product-variations/product-variation.model';
import { ProductSpecsModel } from './../../models/product/product-specs/product-specs.model';
import { ProductImageModel } from './../../models/product/product-image/product-image.model';
export interface ProductInfoDetailsViewModel {
    productId: string;
    productName: string;
    productPrice: number;
    productRating: number;
    productReview: number;
    productLocation: number;
    productStock: number;
    productFavorite: number;
    productDescription: string;
    stars: string[];
    productImages: ProductImageModel[];
    productSpecs: ProductSpecsModel[];
    productVariations: ProductVariationModel[];
}

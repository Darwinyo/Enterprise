import { CategoryService } from './../../services/category/category.service';
import { ProductCategoryModel } from './../../models/product/product-category/product-category.model';
import { ProductVariationModel } from './../../models/product/product-variations/product-variation.model';
import { ProductSpecsModel } from './../../models/product/product-specs/product-specs.model';
import { CityService } from './../../services/city/city.service';
import { CityModel } from './../../models/city/city.model';
import { ImageModel } from './../../models/image-upload/image.model';
import { ProductService } from './../../services/product/product.service';
import { ProductModel } from './../../models/product/product/product.model';
import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/filter';
import { Observable } from 'rxjs/Rx';
import { Subscription } from 'rxjs/Subscription';
import { NgForm } from '@angular/forms';

declare let $: any;
declare let Dropzone: any;
@Component({
  selector: 'app-product-editor',
  templateUrl: './product-editor.component.html',
  styleUrls: ['./product-editor.component.css']
})
export class ProductEditorComponent implements OnInit {
  productModel: ProductModel;
  inputelement: HTMLInputElement;
  locations: CityModel[];
  productlocation: string;
  imagemodelarray: ImageModel[];
  categories: ProductCategoryModel[];
  dimension: string;
  weight: string;
  manufacturer: string;
  condition: string;
  pagetitle: string;
  constructor(
    private service: ProductService,
    private cityService: CityService,
    private categoryService: CategoryService) {
    this.productModel = <ProductModel>{};
    this.imagemodelarray = [];
    this.locations = [];
    this.categories = [];
    this.dimension = '';
    this.weight = '';
    this.manufacturer = '';
    this.condition = '';
    this.productlocation = '';
  }

  ngOnInit() {
    this.fetchAllCity();
    this.fetchAllCategory();
  }
  fetchAllCity() {
    this.cityService.GetListOfCity().subscribe(
      (result) => this.locations = result,
      (err) => console.log(err),
      () => console.log('CityLoaded')
    );
  }
  fetchAllCategory() {
    this.categoryService.GetAllCategories().subscribe(
      (result) => this.categories = result,
      (err) => console.log(err),
      () => console.log('CategoryLoaded')
    );
  }
  populateImage() {
    this.inputelement = <HTMLInputElement>document.getElementById('imageupload');
    const filelist: FileList = this.inputelement.files;
    let file: File;
    for (let i = 0; i < filelist.length; i++) {
      file = filelist[i];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.imagemodelarray.push(<ImageModel>{
          productImageUrl: reader.result,
          productImageName: file.name,
          productImageSize: file.size
        });
      };
    }
  }
  getCityId(cityname: string): number {
    return this.locations.find(x => x.CityName === cityname).CityId;
  }
  getCategoryId(categoryname: string): string {
    return this.categories.find(x => x.categoryName === categoryname).categoryId;
  }
  convertStringToVariationArray(variationStr: string): ProductVariationModel[] {
    const result: ProductVariationModel[] = [];
    const strArr: string[] = variationStr.split(',');
    strArr.forEach(element => {
      result.push(<ProductVariationModel>{ productVariation: element });
    });
    return result;
  }
  convertArrayToCategoryArray(categoryArray: string[]): ProductCategoryModel[] {
    const productCategoryModel: ProductCategoryModel[] = [];
    categoryArray.forEach(element => {
      productCategoryModel.push(<ProductCategoryModel>{
        categoryId: this.getCategoryId(element),
        categoryName: element
      })
    });
    return productCategoryModel;
  }
  onSubmit(form: NgForm) {
    this.productModel = <ProductModel>{
      productName: form.value['productName'],
      productPrice: form.value['productPrice'],
      productStock: form.value['productStock'],
      productDescription: form.value['productDescription'],
      productLocation: this.getCityId(form.value['location']),
      TblProductCategory: this.convertArrayToCategoryArray(form.value['category']),
      TblProductImage: this.imagemodelarray,
      TblProductSpecs: [
        <ProductSpecsModel>{
          productSpecTitle: 'Dimension',
          productSpecValue: this.dimension
        }, <ProductSpecsModel>{
          productSpecTitle: 'Weight',
          productSpecValue: this.weight
        }, <ProductSpecsModel>{
          productSpecTitle: 'Manufacturer',
          productSpecValue: this.manufacturer
        }, <ProductSpecsModel>{
          productSpecTitle: 'Condition',
          productSpecValue: this.condition
        }
      ],
      TblProductVariations: this.convertStringToVariationArray(form.value['TblProductVariations'])
    }
  }
}

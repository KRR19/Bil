import {CategoryModel} from './category.model';

export interface ProductModel {
  id?: string;
  name?: string;
  category?: CategoryModel;
}

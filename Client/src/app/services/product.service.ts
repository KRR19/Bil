import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ResponseModel} from '../models/response.model';
import {ProductModel} from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private actionCreate = 'Create';
  private actionGetAll = 'GetAll';
  private actionEdit = 'Update';
  private actionDelete = 'Delete';

  constructor(private  http: HttpClient) {
  }

  public async AddCProduct(model: ProductModel) {
    const urlPath = `https://localhost:44310/api/Product/${this.actionCreate}`;
    const response: ResponseModel = await this.http.post<ResponseModel>(urlPath, model).toPromise();
    return response;
  }

  public async GetAll() {
    const urlPath = `https://localhost:44310/api/Product/${this.actionGetAll}`;
    const products: ProductModel[] = await this.http.get<ProductModel[]>(urlPath).toPromise();
    return products;
  }

  async editProduct(changedProduct: ProductModel) {
    const urlPath = `https://localhost:44310/api/Product/${this.actionEdit}`;
    const response: ResponseModel = await this.http.post<ResponseModel>(urlPath, changedProduct).toPromise();
    return response;
  }

  async deleteProduct(model: ProductModel) {
    const urlPath = `https://localhost:44310/api/Product/${this.actionDelete}`;
    const response: ResponseModel = await this.http.post<ResponseModel>(urlPath, model).toPromise();
    return response;
  }
}

import { Injectable } from '@angular/core';
import {CategoryModel} from '../models/category.model';
import {HttpClient} from '@angular/common/http';
import {ResponseModel} from '../models/response.model';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private actionCreate = 'Create';
  private actionGetAll = 'GetAll';
  private actionEdit = 'Update';
  private actionDelete = 'Delete';

  constructor(private  http: HttpClient) { }
  public async AddCategory(model: CategoryModel) {
    const urlPath = `https://localhost:44310/api/Category/${this.actionCreate}`;
    const response: ResponseModel = await this.http.post<ResponseModel>(urlPath, model).toPromise();
    return response;
  }

  public async GetAll() {
    const urlPath = `https://localhost:44310/api/Category/${this.actionGetAll}`;
    const categorys: CategoryModel[] = await this.http.get<CategoryModel[]>(urlPath).toPromise();
    return categorys;
  }

  async editCategory(changedCategory: CategoryModel) {
    const urlPath = `https://localhost:44310/api/Category/${this.actionEdit}`;
    const response: ResponseModel = await this.http.post<ResponseModel>(urlPath, changedCategory).toPromise();
    return response;
  }

  async deleteCategory(changedCategory: CategoryModel) {
    const urlPath = `https://localhost:44310/api/Category/${this.actionDelete}`;
    const response: ResponseModel = await this.http.post<ResponseModel>(urlPath, changedCategory).toPromise();
    return response;
  }
}

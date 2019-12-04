import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {ProductModel} from '../models/product.model';
import {CategoryModel} from '../models/category.model';
import {CategoryService} from '../services/category.service';
import {ProductService} from '../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  public displayedColumns: string[] = ['Id', 'Name', 'Category'];
  public dataSource = new MatTableDataSource<ProductModel>();


  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  private productNameInput: string;
  private message: string;
  private allCategorys: CategoryModel[] = [];
  private allProducts: ProductModel[] = [];
  private selectedCategory: string;
  private selectedProduct: ProductModel;

  constructor(private categoryService: CategoryService, private productService: ProductService) {
  }

  async ngOnInit() {
    this.allCategorys = await this.categoryService.GetAll();
    this.allProducts = await this.productService.GetAll();
    this.dataSource = new MatTableDataSource<ProductModel>(this.allProducts);
  }

  selectProduct(element: ProductModel) {
    this.selectedProduct = element;
    this.productNameInput = element.name;
    this.selectedCategory = element.category.id;
  }

  async AddProduct() {
    if (!this.productNameInput || this.productNameInput == '') {
      this.message = 'Please enter a product name';
      return;
    }

    if (!this.selectedCategory) {
      this.message = 'Please select a category';
      return;
    }
    const newProduct: ProductModel = {};
    newProduct.name = this.productNameInput;
    newProduct.category = {id: this.selectedCategory};
    await this.productService.AddCProduct(newProduct);
    this.allProducts = await this.productService.GetAll();
    this.dataSource = new MatTableDataSource<ProductModel>(this.allProducts);
    this.productNameInput = '';
    this.selectedCategory = '';
  }

  async editProduct() {
    this.productNameInput.trim();
    if (!this.productNameInput || this.productNameInput == '') {
      this.message = 'Please enter a product name';
      return;
    }

    if (!this.selectedProduct) {
      this.message = 'Please select a category';
      return;
    }
    const newProduct: ProductModel = {};
    newProduct.name = this.productNameInput;
    newProduct.id = this.selectedProduct.id;
    newProduct.category = {id: this.selectedCategory};
    await this.productService.editProduct(newProduct);
    this.allProducts = await this.productService.GetAll();
    this.dataSource = new MatTableDataSource<ProductModel>(this.allProducts);
    this.productNameInput = '';
    this.selectedCategory = '';
  }

  async deleteProduct() {
    await this.productService.deleteProduct(this.selectedProduct);
    this.allProducts = await this.productService.GetAll();
    this.dataSource = new MatTableDataSource<ProductModel>(this.allProducts);
    this.productNameInput = '';
    this.selectedCategory = '';
  }
}

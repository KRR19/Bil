import {Component, OnInit} from '@angular/core';
import {CategoryService} from '../services/category.service';
import {CategoryModel} from '../models/category.model';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  private categoryNameInput: string;
  private allCategorys: CategoryModel[];
  private selectedCategory: CategoryModel;
  public displayedColumns: string[] = ['Id', 'Name'];
  public dataSource = new MatTableDataSource<CategoryModel>();
  message: string;

  constructor(private categoryService: CategoryService) {
  }

  async ngOnInit() {
    this.allCategorys = await this.categoryService.GetAll();
    this.dataSource = new MatTableDataSource<CategoryModel>(this.allCategorys);
  }

  async AddCategory() {
    const newCategory: CategoryModel = {};
    newCategory.name = this.categoryNameInput;
    await this.categoryService.AddCategory(newCategory);
    this.allCategorys = await this.categoryService.GetAll();
    this.dataSource = new MatTableDataSource<CategoryModel>(this.allCategorys);
    this.categoryNameInput = '';
  }

  selectCategory(element: CategoryModel) {
    this.selectedCategory = element;
    this.categoryNameInput = element.name;
    this.message = '';
  }

  async editCategory() {
    if (!this.selectedCategory) {
      this.message = 'Select a category!';
      return;
    }
    const changedCategory: CategoryModel = this.selectedCategory;
    changedCategory.name = this.categoryNameInput;
    await this.categoryService.editCategory(changedCategory);
    this.allCategorys = await this.categoryService.GetAll();
    this.dataSource = new MatTableDataSource<CategoryModel>(this.allCategorys);
    this.categoryNameInput = '';
  }

  async deleteCategory() {
    if (!this.selectedCategory) {
      this.message = 'Select a category!';
      return;
    }
    const changedCategory: CategoryModel = this.selectedCategory;
    await this.categoryService.deleteCategory(changedCategory);
    this.allCategorys = await this.categoryService.GetAll();
    this.dataSource = new MatTableDataSource<CategoryModel>(this.allCategorys);
    this.categoryNameInput = '';
  }
}

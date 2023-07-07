import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
@Component({
  selector: 'app-categorylist',
  templateUrl: './categorylist.component.html',
  styleUrls: ['./categorylist.component.css']
})
export class CategorylistComponent implements OnInit {
  categories: any [] = [
    { id: 1, name: 'Electronics' },
    { id: 2, name: 'Clothing' },
    { id: 3, name: 'Home Appliances' },
    { id: 4, name: 'Books' },
    { id: 5, name: 'Sports' }
  ];
  newCategory: any;
  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService.getCategories()
      .subscribe(
        categories => {
          this.categories = categories;
        },
        error => {
          // Handle error
        }
      );
  }

  editCategory(categoryId: number): void {
    // Navigate to the edit category page with the categoryId
  }

  deleteCategory(categoryId: number): void {
    this.categoryService.deleteCategory(categoryId)
      .subscribe(
        () => {
          // Reload the category list 
        },
        error => {
          // Handle error
        }
      );
  }

  addCategory(): void {
    

    this.categoryService.addCategory(this.newCategory)
      .subscribe(
        () => {
          // Reset the newCategory object
          this.newCategory = { id: 0, name: '' };

          // Reload the category list 
          this.loadCategories();
        },
        error => {
          // Handle error
        }
      );
  }

}

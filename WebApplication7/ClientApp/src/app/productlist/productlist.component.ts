import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { ProductService } from '../../services/product.service';


@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {
  product: any = { id: 0, name: '', categoryId: 0, category: null, quantity: 0, price: 0 };
  categories: any[] = [];

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService
  ) { }

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

  saveProduct(): void {
    this.productService.createProduct(this.product)
      .subscribe(
        product => {
          // Handle success (e.g., display success message, navigate to product list)
        },
        error => {
          // Handle error
        }
      );
  }

}

import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product/product.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

interface FormControlConfig {
  key: string;
  label: string;
  value:string;
  maxLength: number;
  validators: any[];
}
@Component({
  selector: 'app-create-product',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.css'
})
export class CreateProductComponent implements OnInit {

  constructor(
    private productService: ProductService,
    private router: Router,
  ) {
    this.formControlsConfig.forEach(control => {
      this.formControls[control.key] = new FormControl('', control.validators);
    });

    this.productForm = new FormGroup(this.formControls);
  }

formControlsConfig: FormControlConfig[] = [
  { key: 'name', label: 'Name',value:'', maxLength: 20, validators: [Validators.maxLength(100), Validators.required] },
  { key: 'description',value:'', label: 'Description', maxLength: 40, validators: [Validators.maxLength(100), Validators.required] },
  { key: 'categoryId',value:'', label: 'Category ID', maxLength: 3, validators: [Validators.max(100), Validators.required] },
  { key: 'price', value:'', label: 'Price', maxLength: 3, validators: [Validators.maxLength(10), Validators.required] },
  { key: 'qty',value:'', label: 'Quantity', maxLength: 3, validators: [Validators.maxLength(4), Validators.required] },
  { key: 'product_image',value:'', label: 'Product Image', maxLength: 100, validators: [Validators.maxLength(1000), Validators.required] },
  { key: 'sku', value:'',label: 'SKU', maxLength: 3, validators: [Validators.max(3)] },
];


formControls: { [key: string]: FormControl } = {};

productForm: FormGroup;
productId!:string;
id!:number; 

  ngOnInit() {

    
  }

  onSubmit() {
    // Access form values
    const formData = this.productForm.value;
    console.log(formData);
    
    this.productService.updateProduct(formData, this.id).subscribe(
        (data) => {
            // Product updated successfully
            console.log("Product updated successfully:", data);
            alert("Product Added successfully");
            this.router.navigate(['/app/products']); // Redirect to products page
        },
        (err) => {
            // Error occurred
            console.error("Error creating product:", err);
            let errorMessage = "An error occurred while updating the product.";
            if (err.status === 404) {
                errorMessage = "Product ID not found. Redirecting to Products page.";
            } else if (err.error && err.error.message) {
                errorMessage = err.error.message;
            }
            alert(errorMessage);
            // this.router.navigate(['/products']); // Redirect to products page
        }
    );
}


}

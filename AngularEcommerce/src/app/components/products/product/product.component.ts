import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../../services/product/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

interface FormControlConfig {
  key: string;
  label: string;
  value:string;
  maxLength: number;
  validators: any[];
}

@Component({
  selector: 'app-product',
  standalone: true,
  imports:[CommonModule,ReactiveFormsModule],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  formControlsConfig: FormControlConfig[] = [
    { key: 'name', label: 'Name',value:'', maxLength: 20, validators: [Validators.maxLength(100), Validators.required] },
    { key: 'description',value:'', label: 'Description', maxLength: 40, validators: [Validators.maxLength(100), Validators.required] },
    { key: 'categoryId',value:'', label: 'Category ID', maxLength: 3, validators: [Validators.max(100), Validators.required] },
    { key: 'price', value:'', label: 'Price', maxLength: 3, validators: [Validators.maxLength(10), Validators.required] },
    { key: 'qty',value:'', label: 'Quantity', maxLength: 3, validators: [Validators.maxLength(4), Validators.required] },
    { key: 'productImage',value:'', label: 'Product Image', maxLength: 100, validators: [Validators.maxLength(100), Validators.required] },
    { key: 'sku', value:'',label: 'SKU', maxLength: 3, validators: [Validators.max(3)] },
  ];

  formControls: { [key: string]: FormControl } = {};

  productForm: FormGroup;
  productId!:string;
  id!:number; 

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router,
  ) {
    this.formControlsConfig.forEach(control => {
      this.formControls[control.key] = new FormControl('', control.validators);
    });

    this.productForm = new FormGroup(this.formControls);
  }
  ngOnInit(): void {

    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if(id!=null){
        this.id=parseInt(id);
        return this.getProduct(this.id);
      }

      alert("Product ID Not Found redirecting to Products Page")
      this.router.navigate(['/products']);
    });
  }

  getProduct(id:number){
    this.productService.getProductById(id).subscribe((data)=>{
      
      Object.keys(data).forEach((key) => {
        // console.log("Data is ",data);
        if (this.productForm.controls[key]) {  
          this.productForm.controls[key].setValue(data[key]);
          // this.productForm.get
        }
      }
      );
    })
  }

  onSubmit() {
    // Access form values
    const formData = this.productForm.value;
    console.log(formData);
    this.productService.postProduct(formData,this.id).subscribe((data)=>{
      alert("Product ID Not Found redirecting to Products Page")
      this.router.navigate(['/products']);
    },(err)=>{
      console.log("Error is ",err);
      
    });
  }

  resetForm() {
  // Reset formZ21wqA
    this.productForm.reset();
  }

}
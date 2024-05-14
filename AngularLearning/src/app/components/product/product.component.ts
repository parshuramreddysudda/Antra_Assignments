import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { product } from "../../Models/product";
import { CommonModule } from '@angular/common';
import { log } from 'console';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
prodCount=9;
@Input()
products:product[]=[]

@Output()demoEvent:EventEmitter<string>= new EventEmitter<string>();
sendData(){
  this.demoEvent.emit(
    "This is the string value passed from the child Compoenent"
  )
}

}
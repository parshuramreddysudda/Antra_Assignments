import { Component, EventEmitter, Input, Output } from '@angular/core';
import { department } from '../../Models/depatment';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-department',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './department.component.html',
  styleUrl: './department.component.css'
})
export class DepartmentComponent {
departmentList:department[]=[{
  id:1,
  name:"Antra",
  location:"Chicago"
},
{
  id:2,
  name:"AWS",
  location:"California"
},
{
  id:3,
  name:"Azure",
  location:"Dallas"
},
{
  id:4,
  name:"GCP",
  location:"Texas"
}
]

updateDepartmentList:department[]=[]

@Input() deparmentLocation:string =""
@Output() totalCount:EventEmitter<any>=new EventEmitter()
filterData(){
  console.log(this.deparmentLocation)

  this.updateDepartmentList=this.departmentList
  if(this.deparmentLocation)
    this.updateDepartmentList=this.departmentList.filter((x)=>this.deparmentLocation==x.location)

  this.totalCount.emit(this.updateDepartmentList.length)

}
}

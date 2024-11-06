import { Component, EventEmitter, Output } from '@angular/core';
import { EmployeeService } from '../../../shared/_services/employee.service';

@Component({
  selector: 'app-employeeform',
  standalone: true,
  imports: [],
  templateUrl: './employeeform.component.html',
  styleUrl: './employeeform.component.css'
})
export class EmployeeformComponent {
  constructor(public service:EmployeeService){

  }
  
  @Output() closeForm = new EventEmitter<void>();

  close() {
    this.closeForm.emit(); 
  }
}

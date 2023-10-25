import { Component } from '@angular/core';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {

  forms: any[] = [];

  constructor(private data: DataService) {

    this.initForms();
  }

  initForms() {
    this.data.getAllForms().subscribe((forms) => {
      console.log(forms);
      this.forms = forms;
    });
  }

  deleteForm(id: number) {
    console.log('Deleting ', id);
    this.data.deleteForm(id).subscribe((result) => {
      console.log(result);
      console.log("Deleted", id);
      this.initForms();
    });
  }
}

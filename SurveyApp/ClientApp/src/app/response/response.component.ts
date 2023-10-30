import { Component } from '@angular/core';
import { DataService } from '../data.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-response',
  templateUrl: './response.component.html',
  styleUrls: ['./response.component.css']
})
export class ResponseComponent {
  id: number = 0;
  formData: any;

  constructor(private data: DataService, private route: ActivatedRoute) {
    // get the id number
    this.route.paramMap.pipe(
      switchMap(params => {
        this.id = Number(params.get('id'));
        return this.data.getQuestionaireById(this.id);
      })
    ).subscribe(result => {
      this.formData = result;
      console.log(this.formData);
    });

    //// replace 2 with the value in the url bar
    //this.data.getFormById(this.id).subscribe((val) => {
    //  console.log(val);
    //});
  }
}

import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { DataService } from '../data.service';

@Component({
  selector: 'app-administrator',
  templateUrl: './administrator.component.html',
  styleUrls: ['./administrator.component.css']
})
export class AdministratorComponent {

  questionaires: any[] = [];

  constructor(private data: DataService) {
    this.data.getAllQuestionaires().subscribe(result => {
      this.questionaires = result;
    });
  }
}

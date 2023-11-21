import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, switchMap } from 'rxjs';
import { DataService } from '../data.service';

@Component({
  selector: 'app-administrator',
  templateUrl: './administrator.component.html',
  styleUrls: ['./administrator.component.css']
})
export class AdministratorComponent {

  questionaires$: BehaviorSubject<any[]>;

  constructor(private data: DataService, private router: Router) {
    this.questionaires$ = this.data.questionaires$;

    this.data.getAllQuestionaires();
  }
}

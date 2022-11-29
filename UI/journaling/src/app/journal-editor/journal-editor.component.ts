import { Journal } from './../models/journal';
import { Component, OnInit } from '@angular/core';
import { JournalService } from '../services/journal.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-journal-editor',
  templateUrl: './journal-editor.component.html',
  styleUrls: ['./journal-editor.component.scss'],
})
export class JournalEditorComponent implements OnInit {
  currentJournal: Journal;
  constructor(
    private journalService: JournalService,
    private route: ActivatedRoute
  ) {
    this.currentJournal = {
      body: '',
      title: '',
      id: 0,
      datedOn: new Date(),
    };
  }

  ngOnInit(): void {
    const journalId = this.route.snapshot.params['id'];
    this.journalService.get(journalId).subscribe((r: any) => {
      this.currentJournal = r;
    });
  }

  submit() {
    var requestObservable =
      this.currentJournal.id !== 0
        ? this.journalService.update(
            this.currentJournal.id,
            this.currentJournal
          )
        : this.journalService.create(this.currentJournal);

    requestObservable.subscribe((res) => {
      alert('Changes changed successfully');
    });
  }
}

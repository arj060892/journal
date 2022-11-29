import { Journal } from './../models/journal';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class JournalService {
  readonly REQUESTURL = 'https://localhost:7212/journal';
  constructor(private httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get(this.REQUESTURL + '/GetAll()');
  }

  get(journalId: string) {
    return this.httpClient.get(this.REQUESTURL + '/' + journalId);
  }

  update(journalId: number, journal: Journal) {
    return this.httpClient.put(this.REQUESTURL + '/' + journalId, journal);
  }

  create(journal: Journal) {
    return this.httpClient.post(this.REQUESTURL, journal);
  }
}

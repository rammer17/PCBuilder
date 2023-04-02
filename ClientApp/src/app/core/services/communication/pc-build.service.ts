import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { PC } from '../../models/pc.model';

@Injectable({
  providedIn: 'root'
})
export class PcBuildService {

  private pc$: BehaviorSubject<PC | null> = new BehaviorSubject<PC | null>(null);

  constructor() { }

  get pc(): Observable<PC | null> {
    return this.pc$.asObservable();
  }

  setPC(data: PC): void {
    this.pc$.next(data);
  }

}

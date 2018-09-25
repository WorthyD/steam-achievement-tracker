import { Component } from '@angular/core';
import { Actions } from './store/actions';
import { NgRedux, select, select$  } from '@angular-redux/store';
import { IAppState } from './store/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @select() steamId: Observable<number>;



  title = 'sat-client-app';
  constructor(private ngRedux: NgRedux<IAppState>) {
  }
  addLogin() {
    this.ngRedux.dispatch({ type: Actions.LOGIN, steamId: 2 });
  }
}

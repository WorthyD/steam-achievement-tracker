import { Injectable } from '@angular/core';
import { Action } from 'redux';

@Injectable()
export class Actions {
  static LOGIN = 'LOGIN';

  login(): Action {
    return { type: Actions.LOGIN };
  }
}

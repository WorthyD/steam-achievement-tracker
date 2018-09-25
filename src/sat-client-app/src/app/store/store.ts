import { Action } from 'redux';
import { Actions } from './actions';

export interface IAppState {
  steamId: number;
}

export const INITIAL_STATE: IAppState = {
  steamId: 0
};

export function rootReducer(lastState: IAppState, action): IAppState {
  switch (action.type) {
    case Actions.LOGIN:
      return Object.assign({}, lastState, {
        steamId: action.steamId
      });
    // return { steamId: 2 };
  }
  return lastState;
}

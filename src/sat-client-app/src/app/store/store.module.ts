import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgReduxModule, NgRedux, DevToolsExtension } from '@angular-redux/store';
import { IAppState, INITIAL_STATE, rootReducer } from './store';

@NgModule({
  imports: [CommonModule, NgReduxModule],
  declarations: []
})
export class StoreModule {
  constructor(ngRedux: NgRedux<IAppState>, devTools: DevToolsExtension) {
    console.log('creating store')
    const storeEnhancers = devTools.isEnabled() ? // <- New
      [devTools.enhancer()] : // <- New
      []; // <- New

    ngRedux.configureStore(rootReducer, INITIAL_STATE, [], storeEnhancers);
  }
}

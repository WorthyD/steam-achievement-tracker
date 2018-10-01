import { TestBed } from '@angular/core/testing';

import { AppTranslationService } from './app-translation.service';

describe('AppTranslationService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppTranslationService = TestBed.get(AppTranslationService);
    expect(service).toBeTruthy();
  });
});

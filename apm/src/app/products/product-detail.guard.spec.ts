import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { IsProductDetailGuard } from './product-detail.guard';

describe('productDetailGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) =>
      TestBed.runInInjectionContext(() => IsProductDetailGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});

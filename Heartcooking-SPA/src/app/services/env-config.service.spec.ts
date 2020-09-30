/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EnvConfigService } from './env-config.service';

describe('Service: EnvConfig', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EnvConfigService]
    });
  });

  it('should ...', inject([EnvConfigService], (service: EnvConfigService) => {
    expect(service).toBeTruthy();
  }));
});

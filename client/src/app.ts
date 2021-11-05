import {Router, RouterConfiguration} from 'aurelia-router';
import {inject, PLATFORM} from 'aurelia-framework';

import { TestPortalAPI } from './api/agent';

@inject(TestPortalAPI) 
export class App {
  router: Router;

  constructor(public api: TestPortalAPI) {}

  configureRouter(config: RouterConfiguration, router: Router){
    config.title = 'Test Booking Portal';
    config.options.pushState = true;
    config.options.root = '/';
    config.map([
      { route: '',               moduleId: PLATFORM.moduleName('./components/users/register-user'), title:'User' },
      { route: 'booking/',       moduleId: PLATFORM.moduleName('./components/bookings/booking-create'), name:'bookings' },
      { route: 'booking/:email', moduleId: PLATFORM.moduleName('./components/bookings/booking-detail'), name:'booking' },
      { route: 'bookingList/',   moduleId: PLATFORM.moduleName('./components/bookings/booking-list'), name:'bookingList' },
      { route: 'report/',        moduleId: PLATFORM.moduleName('./components/reports/reports-list'), name:'reports' },
      { route: 'location/',      moduleId: PLATFORM.moduleName('./components/location/location-create'), name:'locations' },
      { route: 'location/:id',   moduleId: PLATFORM.moduleName('./components/location/location-detail'), name:'location' },
      { route: 'locationList/',  moduleId: PLATFORM.moduleName('./components/location/location-list'), name:'locationList' }
    ]);

    this.router = router;
  }
}

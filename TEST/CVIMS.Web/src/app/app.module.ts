import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Token } from '@caiu/core';
import { EffectsModule } from '@caiu/effects';
import { ErrorsModule, errorsReducer } from '@caiu/errors';
import { EventsModule, EventEffects, eventsReducer } from '@caiu/events';
import { HttpModule, HttpEffects, LookupModule, lookupReducer } from '@caiu/http';
import { routerReducer, RouterModule, RouterEffects } from '@caiu/router';
import { StorageModule, StorageEffects } from '@caiu/storage';
import { StoreModule } from '@caiu/store';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { cartReducer } from './cart/cart.reducer';
import { categoriesReducer } from './categories/categories.reducer';
import { ordersReducer } from './orders/orders.reducer';
import { productsReducer } from './products/products.reducer';
import { CurrentUserEffects } from './shared/effects';
import { currentUserReducer, configReducer, sidenavReducer, siteLocationReducer } from './shared/reducers';
import { SharedModule } from './shared/shared.module';

export function mapToken(state: any): string {
  const token: Token = state['currentUser']['token'];
  return token.expires_in > 0 ? token.access_token : null;
}

export function mapApiBase(s: any): string {
  return s.config.apiBase;
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    EffectsModule.run(CurrentUserEffects),
    EffectsModule.run(EventEffects),
    EffectsModule.run(HttpEffects),
    EffectsModule.run(RouterEffects),
    EffectsModule.run(StorageEffects),
    ErrorsModule.forRoot(),
    EventsModule,
    HttpModule.forRootAsync(mapApiBase, mapToken),
    LookupModule.forRoot(),
    RouterModule.forRoot(),
    SharedModule,
    StorageModule.forRoot('CVIMS_STORE'),
    StoreModule.provideStore({
      cart: cartReducer,
      categories: categoriesReducer,
      config: configReducer,
      currentUser: currentUserReducer,
      errors: errorsReducer,
      events: eventsReducer,
      lookup: lookupReducer,
      orders: ordersReducer,
      products: productsReducer,
      route: routerReducer,
      sidenav: sidenavReducer,
      siteLocation: siteLocationReducer
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

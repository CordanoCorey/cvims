import { NgModule } from '@angular/core';
import {
  MatButtonModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDialogModule,
  MatIconModule,
  MatInputModule,
  MatSidenavModule,
  MatTabsModule,
  MatToolbarModule,
} from '@angular/material';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatRadioModule } from '@angular/material/radio';
import { MatStepperModule } from '@angular/material/stepper';
import { RouterModule } from '@angular/router';
import { CommonModule, AutocompleteModule, GridModule } from '@caiu/common';
import { FormsModule } from '@caiu/forms';

import { ContainerComponent } from './container/container.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { TileComponent } from './tile/tile.component';
import { TotalsComponent } from './totals/totals.component';

@NgModule({
  imports: [
    // AutocompleteModule,
    CommonModule,
    FormsModule,
    GridModule,
    RouterModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDialogModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatMenuModule,
    MatRadioModule,
    MatSidenavModule,
    MatStepperModule,
    MatTabsModule,
    MatToolbarModule,
  ],
  declarations: [
    ContainerComponent,
    FooterComponent,
    HeaderComponent,
    SidebarComponent,
    TileComponent,
    NavbarComponent,
    TotalsComponent,
  ],
  exports: [
    //   AutocompleteModule,
    CommonModule,
    FormsModule,
    GridModule,
    RouterModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDialogModule,
    MatIconModule,
    MatInputModule,
    MatGridListModule,
    MatMenuModule,
    MatRadioModule,
    MatSidenavModule,
    MatStepperModule,
    MatTabsModule,
    MatToolbarModule,
    ContainerComponent,
    FooterComponent,
    HeaderComponent,
    SidebarComponent,
    TileComponent,
    TotalsComponent,
  ]
})
export class SharedModule { }

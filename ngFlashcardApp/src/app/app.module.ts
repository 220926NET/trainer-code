import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestComponent } from './test/test.component';
import { CardViewComponent } from './card-view/card-view.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AddCardComponent } from './add-card/add-card.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CardsComponent } from './cards/cards.component';
import { AboutUsComponent } from './about-us/about-us.component';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    CardViewComponent,
    NavbarComponent,
    AddCardComponent,
    CardsComponent,
    AboutUsComponent
  ],
  imports: [
    // import Modules here, not services/components
    //akin to using directive in C#
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

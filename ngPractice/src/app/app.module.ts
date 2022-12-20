import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { SearchbarComponent } from './searchbar/searchbar.component';
import { HttpClientModule } from '@angular/common/http';
import { BookCardComponent } from './book-card/book-card.component'

//Decorator
@NgModule({
  //Declarations array is where you declare components that belong in this module
  declarations: [
    AppComponent,
    SearchbarComponent,
    BookCardComponent
  ],
  //imports array is to import other modules you depend on
  //This is your dependencies list 
  //analogous to using __insert_namespace_here__
  imports: [
    BrowserModule,
    HttpClientModule
  ],

  //if you want to inject a service at the module level
  providers: [],
  
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";

import { AppComponent} from "./app.component";
import { ProductListComponent } from "./products/product-list.component";
import { ConvertToSpacesPipe } from "./shared/convert-to-spaces.pipe";

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ConvertToSpacesPipe
  ],
  //for foreign directives, components and pipes
  imports: [
    BrowserModule,
    FormsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}

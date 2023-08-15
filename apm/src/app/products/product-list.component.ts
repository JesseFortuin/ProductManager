import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from 'rxjs'
import { IProduct } from "./product";
import { ProductService } from "./product.service";
import { TagContentType } from "@angular/compiler";

@Component({
templateUrl: './product-list.component.html',
styleUrls: ['./product-list.component.css']
})

export class ProductListComponent implements OnInit, OnDestroy {
  //TS can infer type if default is given
  pageTitle: string = 'Product List';
  imageWidth: number = 50;
  imageMargin = 2;
  showImage: boolean = false;
  errorMessage: string = '';
  sub!: Subscription;

  private _listFilter: string = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    console.log('In setter:', value);
    this.filteredProducts = this.performFilter(value);
  }

  filteredProducts: IProduct[] = [];
  products: IProduct[] = [];
  productsControl: IProduct [] = [];

  constructor(private productService: ProductService) {}

  performFilter(filterBy: string): IProduct[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter((product: IProduct) =>
      product.productName.toLocaleLowerCase().includes(filterBy));
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  };

  ngOnInit(): void {
    this.sub = this.productService.getProducts().subscribe({
      next: products => {
        this.products = products;
        this.filteredProducts = this.products;
        this.productsControl = products;
      },
      error: err => this.errorMessage = err
    });
  }

  blob(): void {
    for (let product of this.productsControl){
      const byteCharacters = atob(product.imageUrl);
      const byteNumbers = new Array(byteCharacters.length)
      for (let i = 0; i < byteCharacters.length; i++){
        byteNumbers[i] = byteCharacters.charCodeAt(i);
      }

      const byteArray = new Uint8Array(byteNumbers)

      const blob = new Blob([byteArray], {type: 'image/png'})
      // product.imageUrl = byteNumbers;
    }
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onRatingClicked(message : string): void {
    this.pageTitle = 'Product List: ' + message;
  }
  getExcel(): void {
    this.productService.getExcel()
    .subscribe(response =>
      {
        let fileName = response.headers.get('content-disposition')
        ?.split(';')[1].split('=')[1];

        let blob: Blob = response.body as Blob;

        let a = document.createElement('a');
        // a.download = fileName;

        a.href = window.URL.createObjectURL(blob);

        a.click();
      });
  }
}
